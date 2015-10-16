using System.Collections;
using UnityEngine;

public enum MovementState
{
    updown, rightleft, circle
}

public class PlatformMovement : MonoBehaviour
{

    public MovementState movementState;
    public Vector2 MovePos;
    public Vector2 startPos;
    public float movementFactor;
    public float lerpRate;
    public float movementChangeTime;
    public float startTime;

    public Transform CenterPoint;
    public float Radius = 3.0f;
    public float Speed = 1.0f;

    // Use this for initialization
    private void Start()
    {
        startPos = transform.position;

        switch (movementState)
        {
            case MovementState.rightleft:
                StartCoroutine(LeftRight());
                break;

            case MovementState.updown:
                StartCoroutine(UpDown());
                break;

            case MovementState.circle:
                StartCoroutine(Circle());
                break;

        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, MovePos, lerpRate * Time.deltaTime);
    }

    private IEnumerator UpDown()
    {
        yield return new WaitForSeconds(startTime);
        MovePos = startPos + new Vector2(0, movementFactor);
        yield return new WaitForSeconds(movementChangeTime);
        MovePos = startPos - new Vector2(0, movementFactor);
        yield return new WaitForSeconds(movementChangeTime);
        StartCoroutine(UpDown());
    }

    private IEnumerator LeftRight()
    {
        yield return new WaitForSeconds(startTime);
        MovePos = startPos + new Vector2(movementFactor, 0);
        yield return new WaitForSeconds(movementChangeTime);
        MovePos = startPos - new Vector2(movementFactor, 0);
        yield return new WaitForSeconds(movementChangeTime);
        StartCoroutine(LeftRight());
    }

    private IEnumerator Circle()
    {
        yield return new WaitForSeconds(0.01f);

        transform.position = new Vector2(CenterPoint.position.x + Mathf.Cos(Time.time * Speed) * Radius, CenterPoint.position.y + Mathf.Sin(Time.time * Speed) * Radius);

        StartCoroutine(Circle());
    }
}