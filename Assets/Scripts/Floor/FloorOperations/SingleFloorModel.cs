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
        if (controller.gameColor == _colorFloorE)
        {
            GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
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

}
