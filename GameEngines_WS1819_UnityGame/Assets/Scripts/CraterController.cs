using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraterController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Destroy(this.gameObject, 5f);

    }

}
