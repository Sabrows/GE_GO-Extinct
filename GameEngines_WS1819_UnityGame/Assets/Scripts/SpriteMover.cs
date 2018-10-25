using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMover : MonoBehaviour {

	// Use this for initialization
	IEnumerator WaitandMove () {
		yield return new WaitForSeconds(2);
		transform.position = new Vector3(Random.Range(-5,5),Random.Range(-5,5),0f);
		Start();
	}
	
	void Start(){
		StartCoroutine("WaitandMove");
	}
}
