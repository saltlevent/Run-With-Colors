using System;
using ToolsLevent;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject pauseMenuCanvas;
    public GameObject inGameCanvas;
    public GameObject finishGameCanvas;

    public float gameCountdown = 15;

    public float maxScore = 0;
    private void Start()
    {
        gameState = GameState.Stopped;
        menuCanvas.SetActive(true);
        characterIsGrounded = true;
        maxScore = PlayerPrefs.GetFloat("MaxScore");
    }
    private void Update()
    {
        switch (gameState)
        {
            case GameState.Paused:
                if (!pauseMenuCanvas.activeSelf)
                {
                    pauseMenuCanvas.SetActive(true);
                    inGameCanvas.SetActive(false);

                }
                break;
            case GameState.Stopped:
                if (!menuCanvas.activeSelf)
                {
                    menuCanvas.SetActive(true);
                    inGameCanvas.SetActive(false);
                }
                break;
            case GameState.Playing:
                if (menuCanvas.activeSelf || pauseMenuCanvas.activeSelf)
                {
                    inGameCanvas.SetActive(true);
                    menuCanvas.SetActive(false);
                    pauseMenuCanvas.SetActive(false);
                }

                gameCountdown -= Time.deltaTime;

                scoreAndFloorGenerationSystem();

                if (gameCountdown < 0)
                {
                    gameState = GameState.Finished;
                }
                break;
            case GameState.Finished:
                if (!finishGameCanvas.activeSelf)
                {
                    inGameCanvas.SetActive(false);
                    menuCanvas.SetActive(false);
                    pauseMenuCanvas.SetActive(false);
                    finishGameCanvas.SetActive(true);
                }
                if (maxScore<currentScore)
                {
                    PlayerPrefs.SetFloat("MaxScore",currentScore);
                }
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
            if (characterFloorColor == ColorFloor.None)
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
    public void PauseGame()
    {
        gameState = GameState.Paused;
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}