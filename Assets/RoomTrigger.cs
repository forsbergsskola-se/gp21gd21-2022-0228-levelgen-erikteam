using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Realtime;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    int currentCellx;
    int currentCellz;
    private void Start()
    {
        currentCellx = 0;
        currentCellz = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerPoint")
        {
            Debug.Log("COLLISION DETECTED");
            if (other.gameObject.name.Contains("+Z"))
            {
                Debug.Log("Xakzi is Awesome!Top");
                currentCellz--;
                other.GetComponent<Collider>().enabled = false;
            }
            if (other.gameObject.name.Contains("-Z"))
            {
                Debug.Log("Xakzi is Awesome!Bottom");
                currentCellz++;
                other.GetComponent<Collider>().enabled = false;
            }
            if (other.gameObject.name.Contains("+X"))
            {
                Debug.Log("Xakzi is Awesome!Right");
                currentCellx++;
                other.GetComponent<Collider>().enabled = false;
            }
            if (other.gameObject.name.Contains("-X"))
            {
                Debug.Log("Xakzi is Awesome!Left");
                currentCellx--;
                other.GetComponent<Collider>().enabled = false;
            }


            //if(currentCellz == i && currentCellx == j)
            //{
            //generator.transform.FindChild(i.ToString()+"-"+j.ToString()).gameObject.SetActive(true);


                var room2 = GameObject.FindGameObjectWithTag("Room");
                string room3 = room2.name.Replace(room2.name, "Room " + currentCellx.ToString()+"-"+currentCellz.ToString());
                Debug.Log($"New Room Name: {room3}, currentcellx: {currentCellx}, currentcellz: {currentCellz}");

                var number = GameObject.Find(room3).transform.GetChild(0).childCount;

                for (int i = 0; i < number; i++)
                {
                    GameObject.Find(room3).transform.GetChild(i).gameObject.SetActive(true);

                }

                other.enabled = false;

                /*
                 *
                 * for (int i = 1; i < _board.Count; i++)
            {
                count = this.transform.GetChild(i).childCount;
                for (int j = 0; j < count; j++)
                {
                    this.transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(false);
                }
            }
                 */
                //}

        }
    }
}
