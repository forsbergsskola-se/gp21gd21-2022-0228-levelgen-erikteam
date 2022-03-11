using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public DungeonGenerator dg;
    public GameObject generator;
    int currentCellx;
    int currentCellz;
    private void Start()
    {
        dg = GameObject.Find("Generator").GetComponent<DungeonGenerator>();
        generator = GameObject.Find("Generator");
        currentCellx = 0;
        currentCellz = 0;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLISION DETECTED");
        if (other.gameObject.name.Contains("+Z"))
        {
            Debug.Log("Xakzi is Awesome!Top");
            currentCellz++;
        }
        if (other.gameObject.name.Contains("-Z"))
        {
            Debug.Log("Xakzi is Awesome!Bottom");
            currentCellz--;
        }
        if (other.gameObject.name.Contains("+X"))
        {
            Debug.Log("Xakzi is Awesome!Right");
            currentCellx++;
        }
        if (other.gameObject.name.Contains("-X"))
        {
            Debug.Log("Xakzi is Awesome!Left");
            currentCellx--;
        }

        for (int i = 0; i < dg._board.Count; i++)
        {
            for (int j = 0; j < dg._board.Count; j++)
            {
                if(currentCellz == i && currentCellx == j)
                {
                    generator.transform.FindChild(i.ToString()+"-"+j.ToString()).gameObject.SetActive(true);
                }
            }
        }
    }
}
