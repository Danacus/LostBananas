using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BananaText : MonoBehaviour
{

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<Text>().text = Bananas.bananas + " x";
    }
}