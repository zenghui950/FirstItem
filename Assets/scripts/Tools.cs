using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif 
using System.IO;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// 工具类：获取路径、获取MD5码等
/// </summary>
public class Tools {
   
    /// <summary>
    /// 获取文件的MD5码
    /// </summary>
    /// <param name="filePath">文件的绝对路径</param>
    /// <returns></returns>
    /// 
    // C:\Users\Jinxizhen\Desktop\Lesson_AB_MD5\Assets\StreamingAssets\PC\cube.ab
    public static string GetMD5HashFromFile(string filePath) {
        FileStream file = new FileStream(filePath, FileMode.Open);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] retVal = md5.ComputeHash(file);
        file.Close();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < retVal.Length; i++) {
            sb.Append(retVal[i].ToString("x2"));
        }
        return sb.ToString();
    }

}



/// <summary>
/// 获取路径
/// </summary>
public class PathTools
{
    /// <summary>
    /// 获取Resources文件夹的路径
    /// </summary>
    /// <returns>返回路径</returns>Resources
    public static string GetResourcesPath(string name)
    {
        string outPath = GetPlatformResourcesPath() + "/" + name;
        if (!Directory.Exists(outPath))
        {
            Directory.CreateDirectory(outPath);
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }
        return outPath;
    }

    /// <summary>
    /// 获取streamingAssets文件夹的路径
    /// </summary>
    /// <returns>返回路径</returns>streamingAssets
    public static string  GetstreamingAssetsPath(string name)
    {
        string outPath = GetPlatformstreamingAssetsPath() + "/" + name;
        if (!Directory.Exists(outPath))
        {
            Directory.CreateDirectory(outPath);
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }
        return outPath;
    }



    /// <summary>
    /// 获取平台的名字
    /// </summary>
    /// <returns></returns>
    public static string GetPlatformName()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        return "PC";
#elif UNITY_IOS || UNITY_ANDROID
        return "Mobile";
#endif
    }

    /// <summary>
    /// 获取不同平台的路径
    /// </summary>
    /// <returns></returns>
    public static string GetPlatformResourcesPath()
    {

#if UNITY_EDITOR || UNITY_STANDALONE
        return Application.dataPath + "/Resources";
#elif UNITY_IOS || UNITY_ANDROID
        return Application.persistentDataPath;
#endif

    }

    public static string GetPlatformstreamingAssetsPath()
    {

#if UNITY_EDITOR || UNITY_STANDALONE
        return Application.streamingAssetsPath;
#elif UNITY_IOS || UNITY_ANDROID
        return Application.persistentDataPath;
#endif
    }


}