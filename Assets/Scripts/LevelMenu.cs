using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public GameObject prefab;
    public GameObject folderPrefab;
    public int numLevels;
    public List<string> folders;
    public List<GameObject> folderGo;
    public List<GameObject> levels;
    public bool folderOpened = false;

    // Use this for initialization
    private void Start()
    {
        /*
        for (int i = 1; i <= GameObject.Find("LevelManager").GetComponent<LevelLoader>().levels.Count; i++)
        {
            GameObject go = Instantiate(prefab);
            go.transform.SetParent(transform, false);
            go.name = "Level" + i;
            go.transform.GetChild(0).GetComponent<Text>().text = "Level " + i;
            go.GetComponent<LevelButton>().number = i;
        }
        */

    }

    private void AddFolder(string s)
    {
        folders.Add(s);
    }

    public void OpenFolder(string s)
    {
        foreach (GameObject go in levels)
        {
            if (go.name.Split("-"[0])[0] == s)
            {
                go.SetActive(true);
            }
        }

        foreach (string str in folders)
        {
            GameObject.Find(str).SetActive(false);
        }

        folderOpened = true;
    }

    public void CloseFolder()
    {
        foreach (GameObject go in levels)
        {
            go.SetActive(false);
        }

        foreach (GameObject folder in folderGo)
        {
            folder.SetActive(true);
        }

        folderOpened = false;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void SpawnButtons()
    {
        foreach (GameObject s in LevelLoader.levels)
        {

            string modString = s.name.Replace(".prefab", "");

            Debug.Log(modString.Split("-"[0])[0]);

            int number;

            if (!int.TryParse(modString.Split("-"[0])[0], out number))
            {
                if (!folders.Contains(modString.Split("-"[0])[0]))
                {
                    AddFolder(modString.Split("-"[0])[0]);
                }
            }
        }

        foreach (string s in folders)
        {
            GameObject go = Instantiate(folderPrefab);
            go.transform.SetParent(transform, false);
            go.name = s;
            go.transform.GetChild(0).GetComponent<Text>().text = s;
            folderGo.Add(go);
        }

        foreach (GameObject s in LevelLoader.levels)
        {
            string modString = s.name.Replace(".prefab", "");
            Debug.Log(modString.Split("-"[0])[1].Substring(0, 1));
            if (modString.Split("-"[0])[1].Substring(0, 1) == "0")
            {
                if ((modString.Split("-"[0])[1]).Substring(0, 2) == "00")
                {
                    modString = (modString.Split("-"[0])[1]);
                    modString = modString.Substring(2, modString.Length - 2);
                    Debug.Log("00 ///// " + modString);
                }
                else
                {
                    modString = (modString.Split("-"[0])[1]);
                    modString = modString.Substring(1, modString.Length - 1);
                    Debug.Log("0 ///// " + modString);
                }
            }
            GameObject go = Instantiate(prefab);
            go.transform.SetParent(transform, false);
            go.name = s.name.Replace(".prefab", "");
            go.transform.GetChild(0).GetComponent<Text>().text = modString;

            levels.Add(go);
            go.SetActive(false);
        }
    }
}