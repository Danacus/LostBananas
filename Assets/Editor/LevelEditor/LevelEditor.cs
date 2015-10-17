using System.Collections;
using UnityEditor;
using UnityEngine;

internal class LevelEditor : EditorWindow
{
    public string levelName;
    public string levelFolder;

    [MenuItem("Lost Bananas/Level Editor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(LevelEditor));
    }

    private void OnGUI()
    {

        GUILayout.Label("New Level", EditorStyles.boldLabel);
        if (GUILayout.Button("New Level"))
        {
            EditorApplication.NewEmptyScene();
            EditorApplication.OpenSceneAdditive("Assets/Templates/LevelScene.unity");
        }

        GUILayout.Label("Save/Open Level", EditorStyles.boldLabel);

        levelFolder = EditorGUILayout.TextField("Level Folder", levelFolder);
        levelName = EditorGUILayout.TextField("Level Name", levelName);

        if (GUILayout.Button("Save Level"))
        {
            //EditorApplication.SaveScene("Assets/Resources/Levels/" + levelFolder + "/" + levelFolder + "-" + levelName + ".unity");
            PrefabUtility.CreatePrefab("Assets/Resources/Levels/" + levelFolder + "/" + levelFolder + "-" + levelName + ".prefab", GameObject.Find("Level"), ReplacePrefabOptions.ConnectToPrefab);
        }

        if (GUILayout.Button("Open Level"))
        {
            EditorApplication.NewEmptyScene();
            EditorApplication.OpenSceneAdditive("Assets/OfficialLevels-1.unity");

            GameObject levelGo = AssetDatabase.LoadAssetAtPath("Assets/Resources/Levels/" + levelFolder + "/" + levelFolder + "-" + levelName + ".prefab", typeof(GameObject)) as GameObject;
            Debug.Log("/Levels/" + levelFolder + "/" + levelFolder + "-" + levelName + ".prefab => " + levelGo);
            Instantiate(levelGo, levelGo.GetComponent<LevelPosition>().pos, Quaternion.identity).name = "Level";
        }

        GUILayout.Label("Test Level", EditorStyles.boldLabel);

        if (GUILayout.Button("Test Level"))
        {
            EditorApplication.isPlaying = true;
        }
    }
}