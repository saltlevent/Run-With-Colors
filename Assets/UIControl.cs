using System;
using TMPro;
using UnityEngine;

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
        switch (gameController.gameState)
        {
            case ToolsLevent.GameState.Paused:
                textMeshPro.text = $"Paused";
                break;
            case ToolsLevent.GameState.Stopped:
                textMeshPro.text = $"";
                break;
            case ToolsLevent.GameState.Playing:
                textMeshPro.text = $"Color: {gameController.currentGameColor.ToString()}\nScore:{String.Format("{0:0.00}", gameController.currentScore)}";
                break;
            case ToolsLevent.GameState.Finished:
                break;
            default:
                break;
        }
    }
}
