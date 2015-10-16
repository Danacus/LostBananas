using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FolderCloseButton : MonoBehaviour
{

    // Use this for initialization
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => Load());
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void Load()
    {
        if (GameObject.Find("Grid").GetComponent<LevelMenu>().folderOpened)
        {
            GameObject.Find("Grid").GetComponent<LevelMenu>().CloseFolder();
        }
        else
        {
            Application.LoadLevel("MainMenu");
        }
    }
}