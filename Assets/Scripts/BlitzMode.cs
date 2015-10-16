using UnityEngine;
using System.Collections;

public class BlitzMode : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		Time.timeScale = speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
