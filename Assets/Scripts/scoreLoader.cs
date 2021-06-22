using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreLoader : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameSession gameSession;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameSession.getScore().ToString();
    }
}
