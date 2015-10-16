using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FolderButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => Load());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Load()
    {
        GameObject.Find("Grid").GetComponent<LevelMenu>().OpenFolder(name);
    }
}