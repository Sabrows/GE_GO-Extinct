using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{

    [SerializeField]
    private GameObject crater;
    bool hasCollided;
    ContactPoint collPos;

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
            Instantiate(crater, collPos.point, Quaternion.identity);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        hasCollided = true;
        collPos = collision.contacts[0];
        worldScript.TakeDamage(10);
        
    }
}
