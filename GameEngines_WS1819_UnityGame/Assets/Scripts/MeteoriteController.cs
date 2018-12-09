using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{

    [SerializeField]
    private GameObject crater;
    [SerializeField]
    private GameObject world;
    
    [SerializeField]
    private GameObject brokenMeteor;

    bool hasCollided;
    ContactPoint2D collPos;

    public WorldController worldScript;


    // Use this for initialization
    void Start()
    {
        worldScript = GameObject.FindObjectOfType(typeof(WorldController)) as WorldController;


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
        if (collider.tag == "Blade")
        {
            Debug.Log("Collided with meteorite");
            Instantiate(brokenMeteor, transform.position,transform.rotation);
            Destroy(gameObject);
        }
        else if (collider.tag == "Earth")
        {
            hasCollided = true;

            Instantiate(crater, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
            worldScript.TakeDamage(10);

        }
    }
}
