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
            Debug.LogError("맵 부모 오브젝트를 선택해주세요!");
            return;
        }

        PrefabUtility.SaveAsPrefabAsset(mapParent, savePath);
        Debug.Log($"프리팹 저장 완료: {savePath}");
    }
}
#endif
