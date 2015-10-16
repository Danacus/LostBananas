using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject canvas;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }

    public void AutoLoadLevel()
    {
        int num = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelPosition>().number + 1;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Level"))
        {
            Destroy(go.GetComponent<LevelPosition>().cam);
            Destroy(go);

        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("LevelCompleted"))
        {
            Destroy(go);
        }

        try
        {
            GameObject newGo = Instantiate(LevelLoader.levels[num]);
            newGo.GetComponent<LevelPosition>().number = num;
            newGo.transform.position = newGo.GetComponent<LevelPosition>().pos;
            Instantiate(canvas).name = "Canvas";
        }
        catch (System.IndexOutOfRangeException ex)
        {
            Application.LoadLevel("LevelSelect");
        }
    }

    public void RetryLevel()
    {

        int num = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelPosition>().number;
        Debug.Log(num);
        GameObject oldGo = GameObject.FindGameObjectWithTag("Level");
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Level"))
        {
            Destroy(go.GetComponent<LevelPosition>().cam);
            Destroy(go);

        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("LevelCompleted"))
        {
            Destroy(go);
        }

        Debug.Log(LevelLoader.levels[num]);

        GameObject newGo = Instantiate(LevelLoader.levels[num]);
        newGo.GetComponent<LevelPosition>().number = num;
        newGo.transform.position = newGo.GetComponent<LevelPosition>().pos;
    }
}