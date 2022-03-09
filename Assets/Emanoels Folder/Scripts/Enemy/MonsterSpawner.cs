using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterSpawner;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered room");
    }
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < monsterSpawner.Length; i++)
        {
            monsterSpawner[i].gameObject.SetActive(false);
        }

    }
}
