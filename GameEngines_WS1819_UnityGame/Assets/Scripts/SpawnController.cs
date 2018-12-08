using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject objectReference;
    private Vector3 throwForce = new Vector3(0, -18, 0);

    void Start()
    {
        InvokeRepeating("SpawnObject", 1f, 3);
    }

    void SpawnObject()
    {

        GameObject meteorite = Instantiate(objectReference, new Vector3(Random.Range(-3, 3), 20, 0), Quaternion.identity) as GameObject;
        meteorite.GetComponent<Rigidbody2D>().AddForce(throwForce, ForceMode2D.Impulse);

    }
}