using System;
using UnityEngine;
using ToolsLevent;

public class GameController : MonoBehaviour
{
    public GameObject setLastFloor { set { _floorChangeFloor = value; } }
    public GameObject setCharacterFloor { set { _characterFloor = value; } }
    public ColorFloor setCharacterColorFloor { set { _characterFloorColor = value; } }


    public ColorFloor gameColor = ColorFloor.Green;

    public float currentScore;

    public GameObject _floorChangeFloor;
    public GameObject _characterFloor;

    public ColorFloor _characterFloorColor;

    public event EventHandler DenemeEvent;
    
    private void Start()
    {

    }

    private void Update()
    {
        if (_floorChangeFloor != null && _characterFloor != null)
        {
            if (_floorChangeFloor.Equals(_characterFloor))
            {
                DenemeEvent?.Invoke(this, EventArgs.Empty);
            }
        }


        if (gameColor == _characterFloorColor)
        {
            addScore(Time.deltaTime*3);
        }
        else if (_characterFloorColor == ColorFloor.None)
        {

        }
        else
        {
            addScore(-Time.deltaTime);
        }
    }

    void addScore(float score)
    {
        currentScore += score;
    }
}