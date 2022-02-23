
using UnityEngine;

public static class Helper
{
    public static Vector3 RadianToVector3(float radian)
    {
        return new Vector3(Mathf.Cos(radian), 0.0f, Mathf.Sin(radian));
    }
      
    public static Vector3 DegreeToVector3(float degree)
    {
        return RadianToVector3((degree) * Mathf.Deg2Rad);
    }

    public static Color TrophyTypeToColor(TrophyTypes type)
    {
        switch (type)
        {
            case TrophyTypes.Green:
                return Color.green;
            case TrophyTypes.Red:
                return Color.red;
            case TrophyTypes.Yellow:
                return Color.yellow;
            default:
                return Color.black;
        };
    }
}