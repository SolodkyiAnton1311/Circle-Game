using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper 
{
    public const string HealthKey = "Health";
    public const string RangeKey = "Range";
    public static float CalculateDistance(Vector2 a, Vector2 b)
    {
        return Mathf.Sqrt(Mathf.Pow(b.x - a.x, 2) + Mathf.Pow(b.y - a.y, 2));
    }
}
