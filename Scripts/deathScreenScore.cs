using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class deathScreenScore : MonoBehaviour
{
    TextMeshProUGUI textComponent;
    public ScoreText scoreText;
    int score;


    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        score = scoreText.score;
        textComponent.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        score = scoreText.score;
        textComponent.text = "Score: " + score;
    }
}
