using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldMap
{
    public static float minXSpawnArea = -9f;
    public static float maxXSpawnArea = 9f;
    public static float minYSpawnArea = 3.5f;
    public static float maxYSpawnArea = -3.5f;

    public static Vector2 GetNewRandomPostion()
    {
        return new Vector2(Random.Range(minXSpawnArea, maxXSpawnArea), Random.Range(minYSpawnArea, maxYSpawnArea));
    }
}
