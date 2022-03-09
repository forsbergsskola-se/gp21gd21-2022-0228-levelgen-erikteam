using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPopUp : MonoBehaviour
{
    public GameObject SkillPopUpPanel;
    public void OnCollisionEnter(Collision collision)
    {
        SkillPopUpPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
