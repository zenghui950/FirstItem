using UnityEngine;
using System.Collections;
using XLua;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;
using XLuaTest;

/// <summary>
/// 管理lua
/// </summary>

[LuaCallCSharp]
public class LuaManager : MonoBehaviour
{
    public static LuaManager Instance;
    public  LuaEnv luaEnv = new LuaEnv();

    public TextAsset luaScript;
    public Injection[] injections;

    internal static float lastGCTime = 0;
    internal const float GCInterval = 1;//1 second 

    private Action luaStart;
    private Action luaUpdate;
    private Action luaOnDestroy;

    private LuaTable scriptEnv;


    // Use this for initialization
    void  Awake ()
    {
        Instance = this;
        luaEnv.AddLoader(MyCustomLoader);


        scriptEnv = luaEnv.NewTable();

        // 为每个脚本设置一个独立的环境，可一定程度上防止脚本间全局变量、函数冲突
        LuaTable meta = luaEnv.NewTable();
        meta.Set("__index", luaEnv.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();

        scriptEnv.Set("self", this);
        foreach (var injection in injections)
        {
            scriptEnv.Set(injection.name, injection.value);
        }

        luaEnv.DoString(luaScript.text, "LuaBehaviour", scriptEnv);

        Action luaAwake = scriptEnv.Get<Action>("awake");
        scriptEnv.Get("start", out luaStart);
        scriptEnv.Get("update", out luaUpdate);
        scriptEnv.Get("ondestroy", out luaOnDestroy);

        if (luaAwake != null)
        {
            luaAwake();
        }

    }

    // Use this for initialization
    void Start()
    {
        if (luaStart != null)
        {
            luaStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (luaUpdate != null)
        {
            luaUpdate();
        }
        if (Time.time - LuaBehaviour.lastGCTime > GCInterval)
        {
            luaEnv.Tick();
            LuaBehaviour.lastGCTime = Time.time;
        }
    }


    void OnDestroy()
    {
        if (luaOnDestroy != null)
        {
            luaOnDestroy();
        }
        luaOnDestroy = null;
        luaUpdate = null;
        luaStart = null;
        scriptEnv.Dispose();
        injections = null;
    }


    /// <summary>
    /// string lua脚本文件名
    ///  byte[] lua脚本文件名多对应的内容
    /// </summary>
    Dictionary<string, byte[]> luaDic = new Dictionary<string, byte[]>();


    /// <summary>
    /// 返回lua及脚本内容，返回类型是一个字节数组
    /// </summary>
    /// <param name="filename">lua脚本文件名</param>LuaText.Luatxt文件的名字：LuaText.lua.txt
    /// <returns>文本内容，转换成字节数组的lua脚本的内容</returns>
    byte[] MyCustomLoader(ref string filename)
    {
        //1.
        //lua文件路径
        //string filepath = Application.dataPath + @"/Resources/" + filename + ".lua.txt";
        // return File.ReadAllBytes(filepath);

        //2.
        //获取lua脚本文件夹路径，通过filename在文件夹中去找lua脚本
        string dirpath=  PathTools.GetResourcesPath("Lua");

        ReadLuaScript(new DirectoryInfo(dirpath),filename);
        if (luaDic.ContainsKey(filename))//luaDic.ContainsKey这个方法判断字典里是否有值
        {
            return luaDic[filename];//有就返回
            //byte[] bbs;
            //luaDic.TryGetValue(filename,out bbs);
            //return bbs;
        }
        return null;
    }
    /// <summary>
    /// 根据文件夹路径读取lua文件内容
    /// </summary>
    /// <param name="directoryInfo"> 文件夹信息类</param>
    /// <param name="filename">要找的lua脚本文件名</param>
    void ReadLuaScript(DirectoryInfo directoryInfo,string filename)
    {
       FileSystemInfo []infos=directoryInfo.GetFileSystemInfos();
        foreach (var item in infos)
        {
            FileInfo file = item as FileInfo;
            if (file !=null)
            {//是文件
                //Debug.Log(file.Name);
                //Debug.Log(file.Name.StartsWith(filename));
                if (file.Extension ==".meta"||!file.Name.StartsWith (filename))//过滤隐藏文件
                {
                    continue;
                }
                //Debug.Log(file.FullName);//获取文件路径
                luaDic.Add(filename, File.ReadAllBytes(file.FullName));
              
            }
            else
            {
                //是文件夹
                ReadLuaScript(item as DirectoryInfo ,filename );
            }

        }
       
    }
    /// <summary>
    /// 在c#中调用lua中的方法，将这个封装成一个方法
    /// </summary>
    /// <param name="tab_name">lua脚本中 表名（lua脚本名）</param>
    /// <param name="fun_name">lua脚本中 方法名</param>
    /// <param name="args">方法对应的参数，可以传多个，参数不限定类型</param>
    /// <returns>lua方法中的返回值，有返回值就接收，没有就不接收</returns>
    public object[] CSharpCallLuaFunction(string tab_name, string fun_name, params object[] args)
    {
        LuaTable table = luaEnv.Global.Get<LuaTable>(tab_name);
        LuaFunction fun = table.Get<LuaFunction>(fun_name);
        return fun.Call(args);
    }

    /// <summary>
    /// lua 中加载 AB 包
    /// </summary>
    /// <param name="ab_name">AB包的名字</param>
    /// <param name="target_name">加载的资源的名字</param>
    /// <returns>对应的资源对象</returns>
    public GameObject LoadAssetBundles(string ab_name, string target_name)
    {
        string localpath = PathTools.GetResourcesPath("AssetBundles") + "/" + ab_name;
        AssetBundle ab = AssetBundle.LoadFromFile(localpath);
        GameObject go = ab.LoadAsset<GameObject>(target_name);
        return go;
    }

    public void TTT()//lua调用c#实例方法用冒号：
    {
        print("TTT");
    }
}
