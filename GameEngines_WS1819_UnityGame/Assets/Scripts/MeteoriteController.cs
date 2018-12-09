using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeteoriteController : MonoBehaviour
{

    //[SerializeField]
    //private GameObject crater;
    [SerializeField]
    private ParticleSystem boom;

    [SerializeField]
    private GameObject brokenMeteor;

    [SerializeField]
    private GameObject blade;

    bool hasCollided;

    public WorldController worldScript;

    // Use this for initialization
    void Start()
    {
        worldScript = GameObject.FindObjectOfType(typeof(WorldController)) as WorldController;
        blade = GameObject.FindGameObjectWithTag("Blade") as GameObject;

    }
    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -20)
        {
            Destroy(this.gameObject);

        }
        else if (hasCollided)
        {
            Destroy(this.gameObject);
            // Instantiate(crater, collPos.point, Quaternion.identity);
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (blade.GetComponent<CircleCollider2D>() != null)
        {
            if (collider.tag == "Blade")
            {
                //Debug.Log("Collided with meteorite");
                Instantiate(brokenMeteor, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else if (collider.tag == "Earth")
            {
                hasCollided = true;

                //Instantiate(crater, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                Instantiate(boom, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);

                worldScript.TakeDamage(10);
            }
        }
        else
        {
            Debug.Log("Destroyed Component in Blade GameObject");
        }
    }
}

