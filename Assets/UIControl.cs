using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIControl : MonoBehaviour
{
    private GameController gameController;
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        if (!gameController.gameStarted)
        {
            textMeshPro.text = $"Game Starts in \n{String.Format("{0:0.00}", gameController._time)}";
        }
        else
        {
            textMeshPro.text = $"Color: {gameController.currentGameColor.ToString()}\nScore:{String.Format("{0:0.00}", gameController.currentScore)}";
        }
    }
}
