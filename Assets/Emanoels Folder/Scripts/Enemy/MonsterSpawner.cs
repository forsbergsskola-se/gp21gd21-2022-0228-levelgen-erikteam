using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using Unity.Mathematics;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject impPrefab;

    public int impSpawnMin = 1;
    public int impSpawnMax = 5;

    private bool hasSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasSpawned == false)
        {
            /*int randomSpawner = UnityEngine.Random.Range(impSpawnMin, impSpawnMax);
            for (int i = 0; i < randomSpawner; i++)
            {
                Instantiate(impPrefab, new Vector3(i + transform.position.x, 0, i + transform.position.z), Quaternion.identity, transform);
                Instantiate(impPrefab, new Vector3(i * _roomOffsetX, 0, -j * _roomOffsetY), Quaternion.identity, transform).GetComponent<RoomBehaviour>();
            }
            hasSpawned = true;*/
        }
    }
}
