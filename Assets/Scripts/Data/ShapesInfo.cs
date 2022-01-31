using System;
using Vector2 = UnityEngine.Vector2;

public class ShapeInfos
{
    private Vector2[] stickShape =
        {new Vector2(0, -3), new Vector2(0, -2), new Vector2(0, -1), new Vector2(0, 0)};

    private Vector2[] eShape =
        {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, -1), new Vector2(2, -1)};

    private Vector2[] cShape =
        {new Vector2(0, 0), new Vector2(1, 0), new Vector2(-1, 0), new Vector2(-1, 1), new Vector2(1, 1),};

    private Vector2[] plusShape =
        {new Vector2(0, 0), new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, -1), new Vector2(0, 1),};

    private Vector2[] cubeShape =
        {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 1),};

    private Vector2[] lShape =
        {new Vector2(0, 0), new Vector2(0, -1), new Vector2(0, -2), new Vector2(1, -2),};

    private Vector2[] jShape =
        {new Vector2(0, 0), new Vector2(0, -1), new Vector2(0, -2), new Vector2(-1, -2),};

    private Vector2[] sShape =
        {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, -1),};

    private Vector2[] zShape =
        {new Vector2(0, 0), new Vector2(-1, 0), new Vector2(0, -1), new Vector2(1, -1),};

    private Vector2[] tShape =
        {new Vector2(0, 0), new Vector2(0, -1), new Vector2(-1, 0), new Vector2(1, 0),};

    public Vector2[] GetShape(string shapeMark)
    {
        switch (shapeMark)
        {
            case "I":
                return stickShape;
            case "E":
                return eShape;
            case "C":
                return cShape;
            case "+":
                return plusShape;
            case "Cube":
                return cubeShape;
            case "L":
                return lShape;
            case "J":
                return jShape;
            case "S":
                return sShape;
            case "Z":
                return zShape;
            case "T":
                return tShape;
            default:
                throw new ArgumentException("No shape for mark " + shapeMark);

        }
    }
}