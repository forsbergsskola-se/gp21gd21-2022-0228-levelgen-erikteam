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

    private bool m_HasSpawned = false;

    private float m_RoomOffsetX;
    private float m_RoomOffsetY;

    private void OnTriggerEnter(Collider other)
    {
        if (m_HasSpawned == false)
        {
            m_RoomOffsetX = gameObject.GetComponent<BoxCollider>().size.x;
            m_RoomOffsetY = gameObject.GetComponent<BoxCollider>().size.z;
            m_RoomOffsetX /= 2;
            m_RoomOffsetY /= 2;
            int randomSpawner = UnityEngine.Random.Range(impSpawnMin, impSpawnMax);

            {
                for (int i = 0; i < randomSpawner; i++)
                {
                    Instantiate(impPrefab, new Vector3(UnityEngine.Random.Range(-m_RoomOffsetX, m_RoomOffsetX) + transform.position.x, 0, UnityEngine.Random.Range(-m_RoomOffsetY, m_RoomOffsetY) + transform.position.z), Quaternion.identity, transform);
                    //Instantiate(impPrefab, new Vector3(i * _roomOffsetX, 0, -j * _roomOffsetY), Quaternion.identity, transform).GetComponent<RoomBehaviour>();
                }
                m_HasSpawned = true;
            }
        }
    }
}
