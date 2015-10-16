using UnityEngine;
using System.Collections;

public class LevelSpawner : MonoBehaviour
{

    public GameObject go;
    public int number;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName != "LevelSelect" && Application.loadedLevelName != "PackageManager")
        {
            Debug.LogWarning(number);
            GameObject Go = Instantiate(go);
            Go.transform.position = Go.GetComponent<LevelPosition>().pos;
            Go.GetComponent<LevelPosition>().number = number;
            Destroy(gameObject);
        }
    }

}