using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {

	[SerializeField]
	private GameObject fruit;
	// Use this for initialization
	void Start () {
		//Coroutine start
		//Instantiate new Fuits to cut
		Instantiate(fruit,new Vector3(0f,0f,0f),Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		// Coroutine -> spawn Fruits in time frame
	}
}
