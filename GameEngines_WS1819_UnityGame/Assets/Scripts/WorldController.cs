using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	[SerializeField]
	private float rotationSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(new Vector3(0,-8,0), Vector3.forward, 0.5f * rotationSpeed);
	}
}
