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
        TriggerSkillPopUp();
    }

    private void Awake()
    {
        score = 0;
    }

    public void EnemyKilled()
    {
        score++;
        TriggerSkillPopUp();

    }

    public void TriggerSkillPopUp()
    {
        if(score == 1)
        {
            SkillPopUpPanel.SetActive(true);
            score = 0;
        }
    }
}
