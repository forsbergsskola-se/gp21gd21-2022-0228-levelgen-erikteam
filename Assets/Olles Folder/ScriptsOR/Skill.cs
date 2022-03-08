using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "Skills", order = 0)]
public class Skill : ScriptableObject
{
    public Sprite icon;
    public string description;
}
