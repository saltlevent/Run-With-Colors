using UnityEngine;
using ToolsLevent;

public class SingleFloorModel : MonoBehaviour
{
    private ColorFloor _colorFloorE;

    public string colorName = "";
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
