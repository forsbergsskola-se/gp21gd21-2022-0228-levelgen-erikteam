using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Skill slotSkill;
    private Button button;
    public Image image;

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    public void Setup(Skill skill)
    {
        slotSkill = skill;
        image.sprite = skill.icon;
        button.onClick.AddListener(GiveBuff);
    }

    public void GiveBuff()
    {
        var giveBuff = 0;
    }
}
