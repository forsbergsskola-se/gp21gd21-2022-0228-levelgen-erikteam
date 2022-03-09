using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Rule : MonoBehaviour
{
    public GameObject room;
    public Vector2Int minPosition;
    public Vector2Int maxPosition;
    public bool obligatory;

    public int ProbabilityOfSpawning(int x, int y)
    {
        //if returns 0, can't spawn at position, if return 1, can spawn at. if return 2, has to spawn at
        if (x >= minPosition.x && x <= maxPosition.x && y >= minPosition.y && y <= maxPosition.y)
        {
            return obligatory ? 2 : 1;
        }

        return 0;
    }
}
