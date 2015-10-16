using System.Collections;
using UnityEngine;

public class SideTrigger : MonoBehaviour
{

    public bool enter = false;
    public GameObject enteredObject;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        enter = true;
        enteredObject = col.gameObject;
    }

    private void OnTriggerExit2D()
    {
        enter = false;
        enteredObject = null;
    }
}