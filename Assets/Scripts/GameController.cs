using System;
using ToolsLevent;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject setLastFloor { set { _floorChangeFloor = value; } }
    public GameObject setCharacterFloor { set { _characterFloor = value; } }
    public ColorFloor setCharacterColorFloor { set { characterFloorColor = value; } }


    public ColorFloor currentGameColor = ColorFloor.Black;

    public bool gameStarted = false;

    public float currentScore=0;


    public ColorFloor characterFloorColor;

    public event EventHandler FloorGeneration;

    public float _time = 10;

    public bool characterIsGrounded = false;

    private GameObject _floorChangeFloor;
    private GameObject _characterFloor;

    private void FixedUpdate()
    {
        _time -= Time.deltaTime;

        if (_time <= 0)
        {
            currentGameColor = (ColorFloor)UnityEngine.Random.Range(1, 6);
            _time = 5;
            gameStarted = true;
        }

        if (_floorChangeFloor != null && _characterFloor != null && _floorChangeFloor.Equals(_characterFloor))
        {
            FloorGeneration?.Invoke(this, EventArgs.Empty);
        }


        if (characterIsGrounded && gameStarted)
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

    void addScore(float score)
    {
        currentScore += score;
    }
}