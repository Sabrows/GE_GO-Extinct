using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject meteorite;

    public float distFromCamera = 10.0f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 1f, 1.5f);
    }

    void SpawnObject()
    {

        Vector3 spawnPos = new Vector3(Random.value, 1.1f, distFromCamera);
        spawnPos = Camera.main.ViewportToWorldPoint(spawnPos);

        Instantiate(meteorite, spawnPos, Quaternion.identity);
        meteorite.GetComponent<Rigidbody2D>().drag = 1f;


    }
}