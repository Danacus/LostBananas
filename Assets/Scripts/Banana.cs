using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Banana : MonoBehaviour
{
    public bool collision = false;
    public bool finished = false;
    public GameObject canvas;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (collision)
        {
            GameObject.Find("Monkey").gameObject.transform.position = Vector2.Lerp(GameObject.Find("Monkey").transform.position, transform.position, GameObject.Find("Monkey").GetComponent<MonkeyJump>().lerpRate * 2 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Monkey")
        {
            if (!finished)
            {
                collision = true;
                finished = true;
                col.GetComponent<Rigidbody2D>().gravityScale = 0;
                col.GetComponent<MonkeyJump>().newPos = transform.position;
                col.gameObject.transform.position = Vector2.Lerp(col.gameObject.transform.position, transform.position, col.gameObject.GetComponent<MonkeyJump>().lerpRate * Time.deltaTime);
                StartCoroutine(WaitForComplete());
            }
        }
    }

    private IEnumerator WaitForComplete()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(canvas);
        Bananas.bananas += 1;
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
        {
            { "Bananas", Bananas.bananas },
            { "Level", GameObject.FindGameObjectWithTag("Level").GetComponent<LevelPosition>().number }
        });
        Destroy(GameObject.Find("Canvas"));
        //canvas.SetActive(true);
    }
}