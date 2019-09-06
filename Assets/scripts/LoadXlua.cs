using UnityEngine;
using System.Collections;
using XLua;
using System.Text;
using System.IO;

public class LoadXlua : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        //第一种加载lua脚本的方式

        //通过Resources.Load加载Lua脚本，这里用的是文本文档写的lua脚本
        //TextAsset ta = Resources.Load<TextAsset>("XLua.lua.txt");

        //创建xlua虚拟机对象
        LuaEnv env = new LuaEnv();

        //env.DoString(ta.ToString ());
        //这三种格式都能读取到ta里面的内容
        //env.DoString(ta.ToString ()) 
        //env.DoString(ta.text)  
        //env.DoString(ta.bytes);

        //第二种加载lua脚本的方式  通过自定义Loader加载   
        //env.AddLoader(MyLoader);
        env.DoString("require '111'");
        int a=  env.Global.Get<int>("a");//c#访问lua脚本的变量
        print(a);

        env.Dispose();//释放资源
	}
	public byte[] MyLoader(ref string filepath)
    {
        //加载的路径，这里是本地streamingAssetsPath文件夹下加载，你也可以通过其他路径或着在服务器上动态加载
        string saspath = Application.streamingAssetsPath + "/" + filepath + ".lua.txt";
        return Encoding.UTF8.GetBytes(File.ReadAllText(saspath));
        
    }

	// Update is called once per frame
	void Update ()
    {
	
	}
}
