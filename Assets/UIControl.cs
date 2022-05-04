using System;
using TMPro;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    private GameController gameController;
    public TextMeshProUGUI inGameText;
    public TextMeshProUGUI finishText;
    public TextMeshProUGUI maxScoreText;

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
                maxScoreText.text = $"High Score \n<b>{String.Format("{0:0.00}", gameController.maxScore)}</b>";
                break;
            case ToolsLevent.GameState.Playing:
                inGameText.text = $"Score:{String.Format("{0:0.00}", gameController.currentScore)}\n Time:{String.Format("{0:0.00}", gameController.gameCountdown)}";
                break;
            case ToolsLevent.GameState.Finished:
                if (gameController.maxScore < gameController.currentScore)
                {
                    finishText.text = $"New High Score\nScore:{String.Format("{0:0.00}", gameController.currentScore)}";
                }
                else
                {
                    finishText.text = $"Score:{String.Format("{0:0.00}", gameController.currentScore)}";
                }
                break;
            default:
                break;
        }
    }
}
