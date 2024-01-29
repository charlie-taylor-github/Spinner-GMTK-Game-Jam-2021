using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    bool isDead = false;
    public GameObject deathScreenCanvas;
    public GameObject gameUICanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        isDead = true;
        deathScreenCanvas.SetActive(true);
        gameUICanvas.SetActive(false);
        Time.timeScale = 0f;
    }
}
