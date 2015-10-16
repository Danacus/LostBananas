using System.Collections;
using UnityEngine;

using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int number;

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
        Debug.Log(number);
        for (int i = 0; i < LevelLoader.levels.Length; i++)
        {
            if (LevelLoader.levels[i].name == name)
            {
                GameObject.Find("Messenger").GetComponent<LevelSpawner>().go = LevelLoader.levels[i];
                GameObject.Find("Messenger").GetComponent<LevelSpawner>().number = i;
            }
        }
        Application.LoadLevel("OfficialLevels-1");

    }
}