using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Multiplayer.Samples.BossRoom;
using UnityEngine;
using UnityEngine.AI;
using Action = Unity.Multiplayer.Samples.BossRoom.Server.Action;
using Random = UnityEngine.Random;

public class BuildManager : MonoBehaviour
{
    public Skill[] listSkill; //in inspector set the skills
    public GameObject Slot; //set prefab here
    public Transform slotsContent; //set the parent transform of the stuff
    public Action.BuffableValue[] buffables;
    //public ActionLogic[] actionLogic;
    public MovementStatus[] movementStatus;

    public int numberOfTiles;
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            GameObject slot = Instantiate(Slot, slotsContent.position, Quaternion.identity);
            slot.transform.SetParent(slotsContent);
            slot.GetComponent<Slot>().Setup(listSkill[Random.Range(0, listSkill.Length)]);
        }
    }
    public void GiveBuff()
    {
        //insertbuffcrap
    }
}
