using System.Collections;
using UnityEngine;

public class MonkeyJump : MonoBehaviour
{

    public bool isColliding = false;
    public bool nextJumpLeft = false;
    public bool nextJumpRight = false;
    public bool readyToJump = true;
    public bool changingReadyToJump = false;
    public bool changingNextJumpLeft = false;
    public bool changingNextJumpRight = false;
    public Vector2 newPos;
    public float lerpRate;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        /*
        if (GameObject.Find("Left").GetComponent<SideTrigger>().enter || GameObject.Find("Right").GetComponent<SideTrigger>().enter)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        */

        if (!readyToJump)
        {
            if (!changingReadyToJump)
            {
                changingReadyToJump = true;
                StartCoroutine(ChangeReadyToJump());
            }
        }

        if (nextJumpLeft)
        {
            if (!changingNextJumpLeft)
            {
                changingNextJumpLeft = true;
                StartCoroutine(ChangeNextJumpLeft());
            }
        }

        if (nextJumpRight)
        {
            if (!changingNextJumpRight)
            {
                changingNextJumpLeft = true;
                StartCoroutine(ChangeNextJumpRight());
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!GameObject.Find("Left").GetComponent<SideTrigger>().enter)
                {
                    if (!nextJumpLeft)
                    {
                        if (isColliding)
                        {
                            StartCoroutine(JumpLeft());
                        }
                        else
                        {
                            nextJumpRight = false;
                            nextJumpLeft = true;
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!GameObject.Find("Right").GetComponent<SideTrigger>().enter)
                {
                    if (!nextJumpLeft)
                    {
                        if (isColliding)
                        {
                            StartCoroutine(JumpRight());
                        }
                        else
                        {
                            nextJumpLeft = false;
                            nextJumpRight = true;
                        }
                    }
                }
            }
        }

        if (nextJumpLeft)
        {
            if (isColliding)
            {
                nextJumpLeft = false;
                StartCoroutine(JumpLeft());
            }
        }

        if (nextJumpRight)
        {
            if (isColliding)
            {
                nextJumpRight = false;
                StartCoroutine(JumpRight());
            }
        }

        if (GameObject.Find("Down").GetComponent<SideTrigger>().enter)
        {
            if (GameObject.Find("Down").GetComponent<SideTrigger>().enteredObject.tag == "Walkable")
            {
                newPos = new Vector2(GameObject.Find("Down").GetComponent<SideTrigger>().enteredObject.transform.position.x, transform.position.y);
                transform.position = Vector2.Lerp(transform.position, newPos, lerpRate * Time.deltaTime);
            }
        }

    }

    public void TouchLeft()
    {
        if (!GameObject.Find("Left").GetComponent<SideTrigger>().enter)
        {
            if (!nextJumpLeft)
            {
                if (isColliding)
                {
                    StartCoroutine(JumpLeft());
                }
                else
                {
                    nextJumpRight = false;
                    nextJumpLeft = true;
                }
            }
        }
    }

    public void TouchRight()
    {
        if (!GameObject.Find("Right").GetComponent<SideTrigger>().enter)
        {
            if (!nextJumpLeft)
            {
                if (isColliding)
                {
                    StartCoroutine(JumpRight());
                }
                else
                {
                    nextJumpLeft = false;
                    nextJumpRight = true;
                }
            }
        }
    }

    private IEnumerator ChangeNextJumpRight()
    {
        yield return new WaitForSeconds(0.7f);
        nextJumpRight = false;
        changingNextJumpRight = false;
    }

    private IEnumerator ChangeNextJumpLeft()
    {
        yield return new WaitForSeconds(0.7f);
        nextJumpLeft = false;
        changingNextJumpLeft = false;
    }

    private IEnumerator ChangeReadyToJump()
    {
        yield return new WaitForSeconds(0.1f);
        readyToJump = true;
        changingReadyToJump = false;
    }

    private IEnumerator JumpRight()
    {
        yield return new WaitForSeconds(0.05f);
        if (readyToJump)
        {
            if (isColliding)
            {
                Debug.Log("JumpRight");
                GetComponent<Rigidbody2D>().AddForce(transform.right * 250);
                GetComponent<Rigidbody2D>().AddForce(transform.up * 350);
                readyToJump = false;
                if (transform.localScale.x < 0)
                {
                    //transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }
            }
        }
        else
        {
            StartCoroutine(JumpRight());
        }
    }

    private IEnumerator JumpLeft()
    {
        yield return new WaitForSeconds(0.05f);
        if (readyToJump)
        {
            if (isColliding)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * -250);
                GetComponent<Rigidbody2D>().AddForce(transform.up * 350);
                readyToJump = false;
                if (transform.localScale.x > 0)
                {
                    //transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }
            }
        }
        else
        {
            StartCoroutine(JumpLeft());
        }
    }

    private IEnumerator WaitForStopCollision()
    {
        yield return new WaitForSeconds(0.3f);
        isColliding = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        isColliding = true;
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        isColliding = true;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        isColliding = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        isColliding = false;
    }
}