using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ScoreText scoreScript;
    public HealthBar healthBarScript;
    bool hasCollided = false;
    public int healthAdd = 10;
    public ParticleSystem deathParticles;
    public AudioSource explosion;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<ScoreText>();
        healthBarScript = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        explosion = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        explosion.Play();
        Destroy(gameObject, 0.1f);

        if (collision.CompareTag("Player"))
        {
            if (hasCollided == false)
            {
                scoreScript.score += 3;
                if (healthBarScript.health + healthAdd <= 100)
                {
                    // wont overflow
                    healthBarScript.health += healthAdd;
                } else
                {
                    healthBarScript.health = 100;
                }
                
            }
                
            hasCollided = true;
        }
        if (collision.CompareTag("Chain"))
        {
            if (hasCollided == false)
            {
                scoreScript.score += 1;
                if (healthBarScript.health + healthAdd <= 100)
                {
                    // wont overflow
                    healthBarScript.health += healthAdd;
                }
                else
                {
                    healthBarScript.health = 100;
                }
            }
                
            hasCollided = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
