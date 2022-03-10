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
    public Transform slotsContent1;
    public Transform slotsContent2; //set the parent transform of the stuff
    public Action.BuffableValue[] buffables;
    public ActionLogic[] actionLogic;
    public MovementStatus[] movementStatus;

    public int numberOfTiles = 2;
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            Transform parentSkill;
            if (i == 0)
                parentSkill = slotsContent1;
            else
                parentSkill = slotsContent2;
            GameObject slot = Instantiate(Slot);
            slot.transform.SetParent(parentSkill, false);
            slot.transform.localPosition = Vector3.zero;
            slot.GetComponent<Slot>().Setup(listSkill[Random.Range(0, listSkill.Length)], this);
        }
    }
    public void GiveBuff(Skill skill)
    {
        Debug.Log("Hey, Listen!");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        CharacterClassContainer classContainer = player.GetComponent<CharacterClassContainer>();
        CharacterClass _class = classContainer.CharacterClass;
        //ScriptableObject.CreateInstance<CharacterClass>(_class)
        _class.BaseHP = new IntVariable(){Value = _class.BaseHP.Value + 50};
        classContainer.SetCharacterClass(_class);
    }
}
