using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] randomObjectSpawner;
    public Vector2 offset;
    public Vector3 parentPrefab;
    private void Start()
    {
        parentPrefab = this.transform.parent.position;
        for (int i = 0; i < randomObjectSpawner.Length; i++)
        {
            //Instantiate(randomObjectSpawner[Random.Range(0, randomObjectSpawner.Length)], new Vector3(0, 0, 0),Quaternion.identity, transform).GetComponent<RoomBehaviour>());
            Instantiate(randomObjectSpawner[Random.Range(0,randomObjectSpawner.Length)],new Vector3(Random.Range(offset.x,offset.y) + parentPrefab.x,1,Random.Range(offset.x,offset.y) + parentPrefab.z),Quaternion.identity, transform).GetComponent<RoomBehaviour>();

        }

        //Instantiate(randomObjectSpawner[Random.Range(0,randomObjectSpawner.Length)]);
        //Instantiate(room[Random.Range(0,room.Length)],new Vector3(i * offset.x, 0, -j * offset.y),Quaternion.identity, transform).GetComponent<RoomBehaviour>();
    }
}
