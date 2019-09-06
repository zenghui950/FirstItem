using UnityEngine;
using System.Collections;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif 
using XLua;
using System;

public enum DownloadType
{
  AB,
  Lua
}
//封装一个代理(委托)，用于下载完成之后的回调
public delegate void DownloadHandle(DownloadType type);
public class GameInit : MonoBehaviour
{
    //1.下载AB包  http://192.168.1.9:8000/AssetBundles/
    //2.下载lua脚本   http://192.168.1.9:8000/Lua/

    //基础路径
    string url = "http://192.168.43.56:8000/";
   
    // public DownloadHandle dowwnloadHandles;//声明委托变量

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<LuaManager>();
        DownLoadAssetBundles();
    }


    /// <summary>
    /// 下载AB包
    /// </summary>
    void DownLoadAssetBundles()
    {
        StartCoroutine(DownLoadResources("AssetBundles", "ABMD5", DownloadFinished));
    }

    /// <summary>
    /// 下载lua脚本
    /// </summary>
    void DownLoadLuaScript()
    {
        StartCoroutine(DownLoadResources("Lua", "LuaMD5", DownloadFinished));
    }

    /// <summary>
    /// 下载完成之后调用的方法
    /// </summary>
    void DownloadFinished(DownloadType type)
    {

        switch (type)
        {
            case DownloadType.AB:
                //AB包下载完毕
                DownLoadLuaScript();
                print("AB包资源下载完成，开始下载lua脚本");
                break;
            case DownloadType.Lua:
                //Lua脚本下载完毕
                print("Lua资源下载完成，开始加载lua脚本");
                LoadLua();
                break;
        }
    }
    [CSharpCallLua]
    public class LClass
    {
        public string name;
        public int f1;
        public int f2;
    }

    [CSharpCallLua]
    public delegate int  Ldelegate(int a,int b,out LClass lc);
   
    /// <summary>
    ///加载lua
    /// </summary>
    void LoadLua()
    {
        LuaManager.Instance.luaEnv.DoString("require('LuaGameInit')");

        //加载lua脚本
        //LuaManager.Instance.luaEnv.DoString("require('LuaTest')");
        //LuaEnv luaEnv = LuaManager.Instance.luaEnv;
        //调用lua脚本中的方法  LuaGameInit.lua
        LuaManager.Instance.CSharpCallLuaFunction("LuaGameInit", "init");

        //1.c#访问lua脚本里的变量
        //int a = luaEnv.Global.Get<int>("a");
        //Debug.Log("a===" + a);

        //2.访问表 对象
        //LClass lc = luaEnv.Global.Get<LClass>("d");
        //Debug.Log(lc.f1);

        //LuaTable dddd = luaEnv.Global.Get<LuaTable>("d");
        //Debug.Log("f1=" + dddd.Get<int>("f1"));

        //访问表中的方法
        //LuaFunction addd = dddd.Get<LuaFunction>("add");
        //object []aa=  addd.Call(111,112);
        //Debug.Log(aa [0]);//打印索引为零的

        //Ldelegate LD = dddd.Get<Ldelegate>("add");//用委托
        //LClass lc;
        //int a1 = LD(111,112,out lc);
        //Debug.Log(a1);
        //Debug.Log(lc.name);

        //3.访问方法
        //Action mm = luaEnv.Global.Get<Action>("m");
        //mm();//不能传参数

        //LuaFunction mf = luaEnv.Global.Get<LuaFunction>("m");
        //mf.Call();//可以传参数

        //LuaFunction  ff = luaEnv.Global.Get<LuaFunction>("f");
        //ff.Call(111,112);

        //ff.Call(111, "呵呵呵");

        //object[]res=  ff.Call(111, "呵呵呵");
        //foreach (var item in res)
        //{
        //    Debug.Log(item);
        //}
    }
    /// <summary>
    /// 公共资源下载的协程
    /// </summary>
    /// <param name="dirname">要下载文件夹路径的名字</param>
    /// <param name="filename">下载的MD5文件的名字</param>
    /// <param name="callback">下载完成后的回调函数</param>
    /// <returns></returns>
    IEnumerator DownLoadResources(string dirname,string filename,DownloadHandle callback)
    {
        //下载到本地文件夹的路径
        string DownLoadpath = PathTools.GetResourcesPath(dirname);


        //下载MD5码文件
        string md5url = url + dirname+"/"+filename +".txt";
        WWW md5www = new WWW(md5url);
        yield return md5www;
        if (md5www.error !=null)
        {
            Debug.Log(md5www .error);
            yield break;
        }
        //Debug.Log(md5www .text);
        string[] md5Values = md5www.text.Split('\n');
        for (int i = 0; i < md5Values.Length; i++)
        {
            //Debug.Log(md5Values[i]);
            if (string.IsNullOrEmpty(md5Values[i]))
            {
                continue;//如果数组中元素为空跳过本次循环
            }
            //然后分别得到每个文件的文件名和MD5码值

            //获取某个文件的名字和MD5值 AssetBundles|ada69d1e023dce5d83f5077d0dad4f5b
            string[] values = md5Values[i].Split('|');//["cube.ab",aad509ba04624cf27d695bb715073be5]
            //Debug.Log(values[0]+":"+values[1]);
            string name = values[0];//文件名cube.ab
            //string name = values[1];//文件MD5码值
     
            //拼接本地AB包资源的路径
            //C: \Users\Jinxizhen\Desktop\Liesson_xLua\Assets\Resources\Assetbundles\cube.ab
            string localFilePath = (DownLoadpath + "/" + name).Trim();

            if (File.Exists(localFilePath))
            {
                //本地有AB包，比较MD5值
                string md5 = values[1].Trim();//从服务端获取的MD5 值
                string localMD5 = Tools.GetMD5HashFromFile(localFilePath);//本地MD5值
                //Debug.Log(localMD5 + ":" + md5);
                if (localMD5.Equals(md5))
                {
                    Debug.Log("本地已有最新的资源包，不用更新");
                    continue;
                }
                else
                {
                    Debug.Log("本地有资源包，但不是最新的，删除本地旧的资源包，从服务器下载最新的资源包");
                    File.Delete(localFilePath);
                }
            }
            else
            {
                Debug.Log("本地没有资源包");
            }

            //下载AB包
            Debug.Log("下载最新的资源包：" + dirname + ":" + name);
            //http://192.168.15.246:8000/AssetBundles/cube.ab
            string ABurl = url + dirname + "/" + name;
            //print(ABurl);
            WWW abwww = new WWW(ABurl);
            yield return abwww;
            if (abwww.error != null)
            {
                Debug.Log(abwww.error);
                yield break;
            }
            //保存下载的AB包到本地
            File.WriteAllBytes(localFilePath, abwww.bytes);
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif 
        }
        print("下载完成");
        switch (dirname)
        {
            case "AssetBundles":
                callback(DownloadType.AB);
                break;
            case "Lua":
                callback(DownloadType.Lua);
                break;
        }

    }
}

