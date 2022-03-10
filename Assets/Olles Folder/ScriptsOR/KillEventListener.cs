using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEventListener : MonoBehaviour
{
    private SkillPopUp skillPop = null;
    public void KillEventCaller()
    {
        if (!skillPop)
        {
            skillPop = FindObjectOfType<SkillPopUp>();
        }
        skillPop.EnemyKilled();
    }
}
