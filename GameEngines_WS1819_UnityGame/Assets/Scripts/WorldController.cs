using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldController : MonoBehaviour
{

    [Header("Health")]
    [SerializeField]
    private float health;
    [SerializeField]
    private float currCountdownValue;

    [SerializeField]
    private float startHealth = 100f;

    public Image healthBar;

    [Header("Movement")]
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private GameObject jurassicWorld;
    [SerializeField]
    private GameObject spawnController;

    [Header("Boss")]
    [SerializeField]
    private GameObject bossMeteorite;
    [SerializeField]
    private GameObject blade;

    // Use this for initialization
    void Start()
    {
        health = startHealth;
        StartCoroutine(StartCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(new Vector3(0, -7.37f, 0), Vector3.forward, 0.5f * rotationSpeed);
    }

    public IEnumerator StartCountdown(float countdownValue = 60)
    {
        currCountdownValue = countdownValue;

        while (currCountdownValue >= 0)
        {
            if (currCountdownValue == 0 && healthBar.fillAmount > 0)
            {
                Destroy(spawnController);
                Destroy(jurassicWorld);
                LoadGameWinScene();

            }
            else if (currCountdownValue == 0 && healthBar.fillAmount == 0)
            {
                Destroy(spawnController);
                Destroy(jurassicWorld);
                LoadGameOverScene();
            }

            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
    }

    public void TakeDamage(float dmgValue)
    {

        //Debug.Log(dmgValue);
        health -= dmgValue;
        //Debug.Log(health);

        healthBar.fillAmount = health / startHealth;

        if (health == 0)
        {
            //Debug.Log("Game ends");
            SpawnBoss(bossMeteorite);
        }
        if (healthBar.fillAmount <= 0.5 && healthBar.fillAmount > 0.3)
        {
            Color orange = new Color(1, 1, 0);
            healthBar.color = orange;
        }
        else if (healthBar.fillAmount <= 0.3)
        {
            healthBar.color = Color.red;
        }

    }

    private void SpawnBoss(GameObject bM)
    {
        Destroy(spawnController);
        Instantiate(bossMeteorite, new Vector3(0, 8, 0), Quaternion.identity);
        bossMeteorite.GetComponent<Rigidbody2D>().drag = 1f;
        Destroy(blade.GetComponent<CircleCollider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "BossMeteorite")
        {

            Destroy(jurassicWorld);

            LoadGameOverScene();
        }
    }

    public void LoadGameOverScene()
    {
        //Add Endscreen
        SceneManager.LoadScene("GameOver");
    }

    public void LoadGameWinScene()
    {
        //Add Endscreen
        SceneManager.LoadScene("GameWin");
    }
}
