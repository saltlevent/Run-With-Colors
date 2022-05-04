using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolsLevent
{
    public struct GameColor
    {
        public static Color32 none => new Color32(135, 135, 135, 255);
        public static Color32 red => new Color32(255, 87, 51, 255);
        public static Color32 green => new Color32(104, 184, 88, 255);
        public static Color32 blue => new Color32(51, 117, 255, 255);
        public static Color32 yellow => new Color32(255, 216, 51, 255);
    }

    public enum ColorFloor { None, Red, Green, Blue, Yellow};

    public enum GameState {Paused, Stopped, Playing, Finished}

    public static class ColorOps
    {
        public static Color32 ConvertEnumToColor(ColorFloor colorFloor)
        {
            switch (colorFloor)
            {
                case ColorFloor.None:
                    return GameColor.none;
                case ColorFloor.Red:
                    return GameColor.red;
                case ColorFloor.Green:
                    return GameColor.green;
                case ColorFloor.Blue:
                    return GameColor.blue;
                case ColorFloor.Yellow:
                    return GameColor.yellow;
                default:
                    return GameColor.none;
            }
        }
    }
}

