using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterSpawner;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("entered square");
        for (int i = 0; i < monsterSpawner.Length; i++)
        {
            monsterSpawner[i].gameObject.SetActive(true);

            //Instantiate(monsterSpawner[i], new Vector3(10,10,10),Quaternion.identity);
            Debug.Log("Monster Spawned");
            this.gameObject.SetActive(false);
            Debug.Log("Is not Inactive");
        }
    }
}
