using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallPlayer : MonoBehaviour
{
    public HealthBar healthBarScript;

    // Start is called before the first frame update
    void Start()
    {
        healthBarScript = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarScript.health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
