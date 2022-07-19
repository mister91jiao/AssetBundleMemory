using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Init : MonoBehaviour
{
    private Button _loadAb;
    private Button _loadTexture;
    private Button _instance;
    private Button _destroy;
    private Button _unloadAb;
    void Start()
    {
        _loadAb = GameObject.Find("LoadAB").GetComponent<Button>();
        _loadTexture = GameObject.Find("LoadTexture").GetComponent<Button>();
        _instance = GameObject.Find("Instance").GetComponent<Button>();
        _destroy = GameObject.Find("Destroy").GetComponent<Button>();
        _unloadAb = GameObject.Find("UnLoad").GetComponent<Button>();
        Reg();
    }

    private void Update()
    {
        //Debug.Log("GC 使用大小: " + (DllHelper.il2cpp_gc_get_used_size()/1024) + " kb" + "\t" + "heap 大小: " + (DllHelper.il2cpp_gc_get_heap_size()/1024) + " kb");
    }

    private AssetBundle _assetBundle;
    private GameObject[] _objects;
    private GameObject[] _gameObjects = new GameObject[3];
    void Reg()
    {
        _loadAb.onClick.AddListener(LoadAb);
        _loadTexture.onClick.AddListener(LoadTexture);
        _instance.onClick.AddListener(Instance);
        _destroy.onClick.AddListener(Destroy);
        _unloadAb.onClick.AddListener(UnLoadAb);
    }

    private void LoadAb()
    {
        byte[] data = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "testab.bundle"));
        _assetBundle = AssetBundle.LoadFromMemory(data);
        data = null;
        GC.Collect();
    }
    
    private void LoadTexture()
    {
        _objects = _assetBundle.LoadAllAssets<GameObject>();
    }

    private void Instance()
    {
        _gameObjects[0] = GameObject.Instantiate(_objects[0], Vector3.left, Quaternion.identity);
        _gameObjects[1] = GameObject.Instantiate(_objects[1]);
        _gameObjects[2] = GameObject.Instantiate(_objects[2], Vector3.right, Quaternion.identity);
    }

    private void Destroy()
    {
        GameObject.Destroy(_gameObjects[0]);
        GameObject.Destroy(_gameObjects[1]);
        GameObject.Destroy(_gameObjects[2]);
        _gameObjects = null;
        _objects = null;
    }

    private void UnLoadAb()
    {
        _assetBundle.Unload(true);
        //Resources.UnloadUnusedAssets();
        _objects = null;
    }
    
}
