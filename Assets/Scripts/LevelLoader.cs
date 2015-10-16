using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{

    public List<string> folders;
    public static GameObject[] levels;

    // Use this for initialization
    private void Start()
    {

        CheckFolder("Levels/");

        GameObject.Find("Grid").GetComponent<LevelMenu>().SpawnButtons();
        DontDestroyOnLoad(this.gameObject);
    }

    private void CheckFolder(string path)
    {
        /*
        FileInfo[] fileInfo = path.GetFiles("*.*", SearchOption.AllDirectories);

        foreach (FileInfo file in fileInfo)
        {

            if (file.Extension == ".unity")
            {
                levels.Add(file.Name);
            }
            // etc.

            Debug.Log(file);
        }
        */

        levels = Resources.LoadAll(path, typeof(GameObject)).Cast<GameObject>().ToArray();
        Debug.Log(levels[1]);
    }

    // Update is called once per frame
    private void Update()
    {

    }
}