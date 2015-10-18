using System.Collections;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{

    public GameObject go;
    public int number;
    public bool spawned = false;

    // Use this for initialization
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Application.loadedLevelName != "LevelSelect" && Application.loadedLevelName != "PackageManager")
        {
            if (!spawned)
            {
                spawned = true;
                Debug.LogWarning(number);
                GameObject Go = Instantiate(go);
                Go.transform.position = Go.GetComponent<LevelPosition>().pos;
                Go.GetComponent<LevelPosition>().number = number;
                Destroy(gameObject);
            }
        }
    }

}