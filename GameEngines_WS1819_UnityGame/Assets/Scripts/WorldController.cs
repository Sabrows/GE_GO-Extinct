using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour {
	
	[Header ("Health")]
	private float health;

	[SerializeField]
	private float startHealth = 100f;

	public Image healthBar;

	[Header("Movement")]
	[SerializeField]
	private float rotationSpeed;

	[SerializeField]
	private GameObject jurassicWorld;

	// Use this for initialization
	void Start () {
		health = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(new Vector3(0,-8,0), Vector3.forward, 0.5f * rotationSpeed);
	}

	public void TakeDamage(float dmgValue){

		Debug.Log(dmgValue);
		health -= dmgValue;
		Debug.Log(health);

		healthBar.fillAmount = health/startHealth;
		
		if(health <= 0){
			Debug.Log("Game ends");
			EndGame();
		}
	}

	public void EndGame(){
		//Destroy Earth
		Destroy(jurassicWorld);

		//Add Endscreen
	}
}
