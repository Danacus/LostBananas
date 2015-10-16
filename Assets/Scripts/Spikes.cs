using System.Collections;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnCollisionEnter2D()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().RetryLevel();
    }
}