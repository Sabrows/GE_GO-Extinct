using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private GameObject cutable;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.touchCount == 1){
			Touch touch = Input.GetTouch(0);

			//Länge des Touches bestimmen
			//Touch Richtung bestimmen: aktuelle Position - vorherige Position
		}

		//Collider abfrage
	}
}
