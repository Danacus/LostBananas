using System.Collections;
using UnityEngine;

public class Sea : MonoBehaviour
{

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter2D()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().RetryLevel();
    }
}