using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Multiplayer.Samples.BossRoom;
using Unity.Multiplayer.Samples.BossRoom.Server;
using UnityEngine;

public class SkillPopUp : MonoBehaviour
{
    public ServerCharacter characterState;
    public GameObject SkillPopUpPanel;
    private int score = 0;


    private void Awake()
    {
        //score = 0;
    }

    private void OnLifeStateChanged(LifeState prevLifeState, LifeState lifeState)
    {
        if (lifeState != LifeState.Alive)
        {
          //  score++;
        }
    }

    public void TriggerSkillPopUp()
    {
        for (int score = 0; score < score; score++)
        {
            if ((score % 20) == 0)
            {

            }
        }
    }
}
