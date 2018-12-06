using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private GameObject crater;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(new Vector3(0, -7.37f, 0), Vector3.forward, 0.5f * rotationSpeed);
    }
}
