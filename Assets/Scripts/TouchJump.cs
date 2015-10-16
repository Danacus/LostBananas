using UnityEngine;
using System.Collections;

public class TouchJump : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void JumpLeft()
    {
        GameObject.Find("Monkey").GetComponent<MonkeyJump>().TouchLeft();
    }

    public void JumpRight()
    {
        GameObject.Find("Monkey").GetComponent<MonkeyJump>().TouchRight();
    }
}