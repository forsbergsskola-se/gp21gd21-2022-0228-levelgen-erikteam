using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviourOR : MonoBehaviour
{
    public GameObject[] walls; // 0 - UP 1 - Down 2 - Right 3- Left
    public GameObject[] doors; // 0 - UP 1 - Down 2 - Right 3- Left
    public GameObject[] lights;

    public float RoomOffsetX;
    public float RoomOffsetY;

    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }
    }
}