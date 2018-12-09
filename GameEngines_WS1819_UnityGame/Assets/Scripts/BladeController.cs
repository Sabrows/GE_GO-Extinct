using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour
{

    bool isCutting = true;

    Rigidbody2D rb;
    Camera cam;
    private GameObject currentBladeTrail;

    Vector2 previousPos;
    public float minCuttingVelocity = 0.001f;

    CircleCollider2D circleCollider;

    [SerializeField]
    public GameObject bladeTrailPrefab;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCut();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCut();
        }
        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        if (this.gameObject.GetComponent<CircleCollider2D>() != null)
        {
            Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            rb.position = newPosition;

            float velocity = (newPosition - previousPos).magnitude * Time.deltaTime;
            if (velocity > minCuttingVelocity)
            {
                circleCollider.enabled = true;
            }
            else
            {
                circleCollider.enabled = false;
            }
            previousPos = newPosition;
        }
        else
        {
            Debug.Log("Destroyed Component in Blade GameObject");
        }

    }

    void StartCut()
    {
        if (this.gameObject.GetComponent<CircleCollider2D>() != null)
        {
            isCutting = true;
            currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
            circleCollider.enabled = false;
        }
        else
        {
            Debug.Log("Destroyed Component in Blade GameObject");
        }

    }

    void StopCut()
    {
        if (this.gameObject.GetComponent<CircleCollider2D>() != null)
        {
            isCutting = false;
            currentBladeTrail.transform.SetParent(null);
            Destroy(currentBladeTrail, 0.5f);
            circleCollider.enabled = false;
        }
        else
        {
            Debug.Log("Destroyed Component in Blade GameObject");
        }
    }
}
