using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float health = 100;
    float barHealth;
    bool loosingHealth = true;
    public DeathScreen deathScreenUIScript;
    bool killed = false;
    float timeBetweenLoss = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("loseHealth");
        StartCoroutine("waitToLoseMore");
    }

    // Update is called once per frame
    void Update()
    {
        barHealth = health / 100;
        transform.localScale = new Vector3(barHealth, transform.localScale.y, transform.localScale.z);
        if (health <= 0)
        {
            if (killed == false)
                deathScreenUIScript.Die();
            killed = true;
        }
        Debug.Log(timeBetweenLoss);
    }

    IEnumerator waitToLoseMore()
    {
        yield return new WaitForSeconds(10);
        if (timeBetweenLoss > 0.05)
        {
            timeBetweenLoss -= 0.01f;
        }
        StartCoroutine("waitToLoseMore");
    }

    IEnumerator loseHealth()
    {
        if (loosingHealth)
        {
            yield return new WaitForSeconds(timeBetweenLoss);
            if (health > 0)
                health -= 1;
            StartCoroutine("loseHealth");
        }
    }

}
