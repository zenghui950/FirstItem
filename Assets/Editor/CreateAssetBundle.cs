using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// 构建AB包
/// </summary>
public class CreateAssetBundle : EditorWindow{

    public static EditorWindow window;

    [MenuItem("Tools/Build Asset Bundle")]
    static void BuildAssetBundle() {
        window = GetWindow<CreateAssetBundle>("Build Asset Bundle");
        window.Show();
    }

    [SerializeField]
    protected List<Object> _assetList = new List<Object>();
    protected SerializedObject _serializedObject;//序列化对象
    protected SerializedProperty _assetListProperty;//序列化属性

    protected void OnEnable() {
        //初始化序列化对象
        _serializedObject = new SerializedObject(this);
        //获取当前类中可以序列化的属性
        _assetListProperty = _serializedObject.FindProperty("_assetList");
    }

    private void OnGUI() {
        _serializedObject.Update();//更新
        EditorGUI.BeginChangeCheck();//检查是否有更新
        EditorGUILayout.PropertyField(_assetListProperty, true);//显示属性

        //结束检查时是否有修改
        if (EditorGUI.EndChangeCheck()) {
            //如果有修改提交修改
            _serializedObject.ApplyModifiedProperties();
        }

        if (GUILayout.Button("Build")) {
            //Debug.Log("开始构建AB包：" + _assetList.Count);
            for (int i = 0; i < _assetList.Count; i++) {
                //string name = _assetList[i].name;
                //获取物体的相对路径（相对于工程Assets下的文件路径）
                string filepath = AssetDatabase.GetAssetPath(_assetList[i]);
                //Debug.Log(filepath); //  Assets/Prefabs/Cube.prefab
                string subName = Path.GetExtension(filepath); // .prefab
                string filename = Path.GetFileName(filepath); // Cube.prefab
                string name = filename.Replace(subName, string.Empty); //Cube
                Debug.Log(name);

                //AssetImporter 资源导入器
                AssetImporter ai = AssetImporter.GetAtPath(filepath);
                //设置AB包的名字和后缀
                ai.assetBundleName = name;
                ai.assetBundleVariant = "ab";
                //ai.SetAssetBundleNameAndVariant("名字", 后缀);

                //构建AB包 PathTools
                string outpath = PathTools.GetstreamingAssetsPath("AssetBundles");
                BuildPipeline.BuildAssetBundles(outpath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
            }

            window.Close();
        }
    }
}
