using System;
using ToolsLevent;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject setLastFloor { set { _floorChangeFloor = value; } }
    public GameObject setCharacterFloor { set { _characterFloor = value; } }
    public ColorFloor setCharacterColorFloor { set { characterFloorColor = value; } }

    public GameState gameState = GameState.Stopped;

    public ColorFloor currentGameColor = ColorFloor.None;

    public float currentScore = 0;


    public ColorFloor characterFloorColor;

    public event EventHandler FloorGeneration;

    public float _time = 0;

    public bool characterIsGrounded = false;

    private GameObject _floorChangeFloor;
    private GameObject _characterFloor;

    public GameObject menuCanvas;


    private void Start()
    {
        gameState = GameState.Stopped;
        menuCanvas.SetActive(true);
        characterIsGrounded = true;
    }
    private void Update()
    {
        switch (gameState)
        {
            case GameState.Paused:
                break;
            case GameState.Stopped:
                if (!menuCanvas.activeSelf)
                {
                    menuCanvas.SetActive(true);
                }

                break;
            case GameState.Playing:
                if (menuCanvas.activeSelf)
                {
                    menuCanvas.SetActive(false);
                }
                scoreAndFloorGenerationSystem();
                break;
            case GameState.Finished:
                break;
            default:
                break;
        }

    }

    void addScore(float score)
    {
        currentScore += score;
    }

    void scoreAndFloorGenerationSystem()
    {
        _time -= Time.deltaTime;

        if (_time <= 0)
        {
            currentGameColor = (ColorFloor)UnityEngine.Random.Range(1, 6);
            _time = 5;
        }

        if (_floorChangeFloor != null && _characterFloor != null && _floorChangeFloor.Equals(_characterFloor))
        {
            FloorGeneration?.Invoke(this, EventArgs.Empty);
        }

        if (characterIsGrounded)
        {
            if (characterFloorColor == ColorFloor.None || characterFloorColor == ColorFloor.Black)
            {

            }
            else if (currentGameColor == characterFloorColor)
            {
                addScore(Time.deltaTime * 3);
            }
            else
            {
                addScore(-Time.deltaTime);
            }
        }
    }

    public void StartGame()
    {
        gameState = GameState.Playing;
    }
}