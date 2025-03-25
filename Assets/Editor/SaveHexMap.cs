#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class SaveHexMap : EditorWindow
{
    private GameObject mapParent;
    private string savePath = "Assets/Resources/Prefabs/Map/HexMapPrefab.prefab";

    [MenuItem("Tools/Save Hex Map")]
    public static void ShowWindow()
    {
        GetWindow<SaveHexMap>("Save Hex Map");
    }

    void OnGUI()
    {
        GUILayout.Label("Save Hex Map as Prefab", EditorStyles.boldLabel);
        mapParent = (GameObject)EditorGUILayout.ObjectField("Map Parent", mapParent, typeof(GameObject), true);
        savePath = EditorGUILayout.TextField("Save Path", savePath);

        if (GUILayout.Button("Save Prefab"))
        {
            SaveMapAsPrefab();
        }
    }

    void SaveMapAsPrefab()
    {
        if (mapParent == null)
        {
            Debug.LogError("�� �θ� ������Ʈ�� �������ּ���!");
            return;
        }

        PrefabUtility.SaveAsPrefabAsset(mapParent, savePath);
        Debug.Log($"������ ���� �Ϸ�: {savePath}");
    }
}
#endif
