using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Multiplayer.Samples.BossRoom;
using Unity.Multiplayer.Samples.BossRoom.Server;
using UnityEngine;

public class SkillPopUp : MonoBehaviour
{
    public GameObject SkillPopUpPanel;
    private int score = 0;

    private void Update()
    {
        //OnLifeStateChanged();
        TriggerSkillPopUp();
    }

    private void Awake()
    {
        score = 0;
    }

    private void OnLifeStateChanged(LifeState lifeState)
    {
        if (lifeState != LifeState.Alive)
        {
            score++;
        }
    }

    public void TriggerSkillPopUp()
    {
        if(score == 20)
        {
            SkillPopUpPanel.SetActive(true);
            score = 0;
        }
    }
}
