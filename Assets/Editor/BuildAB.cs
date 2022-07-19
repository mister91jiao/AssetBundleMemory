using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildAB : EditorWindow
{
    [MenuItem("构建测试AB/Build")]
    public static void BuildAssetBundle()
    {
        List<string> files = new List<string>();
        files.Add(Path.Combine("Assets", "Bundles", "CubeTexture_1.prefab"));
        files.Add(Path.Combine("Assets", "Bundles", "CubeTexture_2.prefab"));
        files.Add(Path.Combine("Assets", "Bundles", "CubeTexture_3.prefab"));
        files.Add(Path.Combine("Assets", "Bundles", "Mat_1"));
        files.Add(Path.Combine("Assets", "Bundles", "Mat_2"));
        files.Add(Path.Combine("Assets", "Bundles", "Mat_3"));
        files.Add(Path.Combine("Assets", "Bundles", "bds.png"));
        files.Add(Path.Combine("Assets", "Bundles", "ylzy.jpg"));
        files.Add(Path.Combine("Assets", "Bundles", "zfnp.jpg"));
        
        List<AssetBundleBuild> allAssetBundleBuild = new List<AssetBundleBuild>();
        //开始打包
        AssetBundleBuild testBundle = new AssetBundleBuild();
        testBundle.assetBundleName = "TestAB";
        testBundle.assetNames = files.ToArray();
        testBundle.assetBundleVariant = "bundle";
        allAssetBundleBuild.Add(testBundle);
        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, allAssetBundleBuild.ToArray(), 
            BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.StrictMode, EditorUserBuildSettings.activeBuildTarget);
    }
}
