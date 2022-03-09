using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomBehaviour : MonoBehaviour
{

    public GameObject[] exitWalls; // 0 - UP 1 - Down 2 - Right 3- Left
    public GameObject[] exitDoors; // 0 - UP 1 - Down 2 - Right 3- Left
    public GameObject[] lights;

    public float RoomOffsetX;
    public float RoomOffsetY;

    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            exitDoors[i].SetActive(status[i]);
            exitWalls[i].SetActive(!status[i]);
        }
    }
}
