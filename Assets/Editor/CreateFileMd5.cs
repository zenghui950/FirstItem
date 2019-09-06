
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 构建MD5码
/// </summary>
public class CreateFileMd5 {
    
    //构建AB包文件的MD5码
    [MenuItem("Tools/Build AB MD5")]
    static void BuildAssetBundleMD5() {
        BuildFileMD5("AssetBundles", "ABMD5");
    }

    [MenuItem("Tools/Build Lua MD5")]
    static void BuildLuaScriptMD5() {
        BuildFileMD5("Lua","LuaMD5");
    }

    /// <summary>
    /// 构建文件的MD5值
    /// </summary>
    /// <param name="dirname">要构建的文件夹</param>
    /// <param name="filename">MD5值数据的文件名</param>
    static void BuildFileMD5(string dirname, string filename) {
        string outDirPath = PathTools.GetstreamingAssetsPath(dirname);
        string md5FilePath = outDirPath + "/"+ filename +".txt";//保存MD5 数据的文件
        if (File.Exists(md5FilePath)) {
            File.Delete(md5FilePath);
        }

        //获取所有AB包文件的路径
        List<string> pathlist = new List<string>();//存储所有文件的路径
        GetFilePath(new DirectoryInfo(outDirPath), ref pathlist);

        StringBuilder sb = new StringBuilder();
        //存储MD5
        for (int i = 0; i < pathlist.Count; i++) {
            string filepath = pathlist[i];
            //1.过滤隐藏文件
            //获取文件扩展名
            if (Path.GetExtension(filepath) == ".meta") {
                continue;
            }
            string md5 = Tools.GetMD5HashFromFile(filepath);
            //获取文件名
            string name = Path.GetFileName(filepath);

            //C:\Users\Jinxizhen\Desktop\Lesson_AB_MD5\Assets\StreamingAssets\PC\cube.ab
            //字符串截取获取文件名
            //string name = filepath.Substring(filepath.LastIndexOf("\\")+1);
            //字符串分割获取文件名
            //string[] names = filepath.Split('\\');
            //string name = names[names.Length - 1];

            //2.存储MD5值
            //sb.Append(name + "|" + md5 + "\n");
            sb.AppendLine(name + "|" + md5);
        }
        File.WriteAllText(md5FilePath, sb.ToString());
        AssetDatabase.Refresh();
    }
    //FileSystemInfo 文件系统类
    //DirectoryInfo 文件夹信息类  
    //FileInfo 文件信息类
    static void GetFilePath(DirectoryInfo directorinfo, ref List<string> pathlist) {
        //获取文件夹中所有文件的信息：文件夹或文件
        FileSystemInfo[] infos = directorinfo.GetFileSystemInfos();
        foreach (var item in infos) {
            FileInfo file = item as FileInfo;
            if (file != null) {
                //Debug.Log("文件："+ file.Name);
                //是文件
                pathlist.Add(file.FullName);
            } else {
                //是文件夹
                DirectoryInfo dir = item as DirectoryInfo;
                //Debug.Log("文件夹：" + dir.Name);
                //递归
                GetFilePath(dir, ref pathlist);
            }
        }
    }


}
