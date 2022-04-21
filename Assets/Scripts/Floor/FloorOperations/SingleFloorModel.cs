using UnityEngine;
using ToolsLevent;

public class SingleFloorModel : MonoBehaviour
{
    private ColorFloor _colorFloorE;

    public string colorName = "";

    GameController controller;

    private void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
    }
    private void Update()
    {
        switch (controller.gameState)
        {
            case GameState.Paused:
                break;
            case GameState.Stopped:
                break;
            case GameState.Playing:
                floorColorChanger();
                break;
            case GameState.Finished:
                break;
            default:
                break;
        }
    }

    public ColorFloor colorFloorE
    {
        set
        {
            colorName = value.ToString();
            _colorFloorE = value;
        }
        get
        {
            return _colorFloorE;
        }
    }
    
    void floorColorChanger()
    {

        if (controller.currentGameColor == _colorFloorE)
        {
            GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            GetComponent<Renderer>().material.SetColor("_EmissionColor", ColorOps.ConvertEnumToColor(_colorFloorE));
        }
        else
        {
            GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }

    }
}
