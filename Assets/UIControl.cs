using System;
using TMPro;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    private GameController gameController;
    public TextMeshProUGUI inGameText;
    public TextMeshProUGUI finishText;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void FixedUpdate()
    {
        switch (gameController.gameState)
        {
            case ToolsLevent.GameState.Paused:
                inGameText.text = $"Paused";
                break;
            case ToolsLevent.GameState.Stopped:
                inGameText.text = $"";
                break;
            case ToolsLevent.GameState.Playing:
                inGameText.text = $"Score:{String.Format("{0:0.00}", gameController.currentScore)}\n Time:{String.Format("{0:0.00}", gameController.gameCountdown)}";
                break;
            case ToolsLevent.GameState.Finished:
                finishText.text = $"Score:{String.Format("{0:0.00}", gameController.currentScore)}";
                break;
            default:
                break;
        }
    }
}
