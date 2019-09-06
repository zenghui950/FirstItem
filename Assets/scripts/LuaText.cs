using UnityEngine;
using System.Collections;
using XLua;
using System.Text;
[LuaCallCSharp]
public class LuaText : MonoBehaviour
{
    //创建xlua对象
    //LuaEnv luaEnv = new LuaEnv();

    void Awake()
    {
        LuaManager luaManager = gameObject.GetComponent<LuaManager>();
        if (luaManager == null)
        {
            gameObject.AddComponent<LuaManager>();
        }
    }
    // Use this for initialization
    void Start ()
    {
        //c#调用lua

        //1.通过字符串
        //luaEnv.DoString("print('哈喽 你好')");

        //2.自定义loader
        //luaEnv.AddLoader((ref string filename)
        //    => {

        //    if (filename =="Text")
        //    {
        //        string script = "print ('哈喽 你好')";

        //        return Encoding.UTF8.GetBytes(script);
        //    }
        //    return null;

        //    });
        //luaEnv.DoString("require('Text')");

        //3.通过lua文件   LuaText.lua.txt
      LuaManager.Instance .luaEnv.DoString("require('LuaText')");


    }
  public static void TTTT()//lua调用c#方法用打点.
    {
        print("TTTT");
	}

   
}
