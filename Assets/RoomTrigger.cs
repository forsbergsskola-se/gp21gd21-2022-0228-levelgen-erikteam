using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Realtime;
using UnityEngine;
/// <summary>
/// If you came this far into the code. Then OBOY are you in for a treat hahahaha
/// </summary>
public class RoomTrigger : MonoBehaviour
{
    int currentCellx;
    int currentCellz;
    private int oldCellx;
    private int oldCellz;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerPoint")
        {
            if (other.gameObject.transform.name.Contains("+Z"))
            {
                currentCellz--;
                other.gameObject.SetActive(false);
            }
            if (other.gameObject.transform.name.Contains("-Z"))
            {
                currentCellz++;
                other.gameObject.SetActive(false);
            }
            if (other.gameObject.transform.name.Contains("+X"))
            {
                currentCellx++;
                other.gameObject.SetActive(false);
            }
            if (other.gameObject.transform.name.Contains("-X"))
            {
                currentCellx--;
                other.gameObject.SetActive(false);
            }

            var room2 = GameObject.FindGameObjectWithTag("Room"); // Room 0-0
            var testroom = room2; //Room 0-0
            string room3 = room2.name.Replace(room2.name, "Room " + currentCellx.ToString() + "-" + currentCellz.ToString()); // Room 0-1

            var room4 = testroom.name.Replace("Room", "");
            string[] subs = room4.Split('-');

            var number = GameObject.Find(room3).transform.childCount;
            for (int i = 0; i < number; i++)
            {
                GameObject.Find(room3).transform.GetChild(i).gameObject.SetActive(true);
            }

            if (oldCellx < currentCellx)
            {
                oldCellx = currentCellx;
                oldCellz = currentCellz;

                var findchild1 = GameObject.Find(room3);
                var findchild2 = findchild1.transform.Find("exits");
                var findchild3 = findchild2.transform.Find("exit door");
                var findchild4 = findchild3.transform.Find("-X exit");
                var findchild5 = findchild4.transform.Find("-X Trigger Point");
                findchild5.transform.gameObject.SetActive(false);
                var findchild6 = findchild4.transform.Find("+Z exit");
                var findchild7 = findchild6.transform.Find("+Z Trigger Point");
                findchild7.transform.gameObject.SetActive(true);
                var findchild8 = findchild4.transform.Find("-Z exit");
                var findchild9 = findchild8.transform.Find("-Z Trigger Point");
                findchild9.transform.gameObject.SetActive(true);
            }
            if (oldCellx > currentCellx)
            {
                oldCellx = currentCellx;
                oldCellz = currentCellz;

                var findchild1 = GameObject.Find(room3);
                var findchild2 = findchild1.transform.Find("exits");
                var findchild3 = findchild2.transform.Find("exit door");
                var findchild4 = findchild3.transform.Find("+X exit");
                var findchild5 = findchild4.transform.Find("+X Trigger Point");
                findchild5.transform.gameObject.SetActive(false);
                var findchild6 = findchild4.transform.Find("+Z exit");
                var findchild7 = findchild6.transform.Find("+Z Trigger Point");
                findchild7.transform.gameObject.SetActive(true);
                var findchild8 = findchild4.transform.Find("-Z exit");
                var findchild9 = findchild8.transform.Find("-Z Trigger Point");
                findchild9.transform.gameObject.SetActive(true);

            }
            if (oldCellz < currentCellz)
            {
                oldCellx = currentCellx;
                oldCellz = currentCellz;

                var findchild1 = GameObject.Find(room3);
                var findchild2 = findchild1.transform.Find("exits");
                var findchild3 = findchild2.transform.Find("exit door");
                var findchild4 = findchild3.transform.Find("+Z exit");
                var findchild5 = findchild4.transform.Find("+Z Trigger Point");
                findchild5.transform.gameObject.SetActive(false);
                var findchild6 = findchild4.transform.Find("+X exit");
                var findchild7 = findchild6.transform.Find("+X Trigger Point");
                findchild7.transform.gameObject.SetActive(true);
                var findchild8 = findchild4.transform.Find("-X exit");
                var findchild9 = findchild8.transform.Find("-X Trigger Point");
                findchild9.transform.gameObject.SetActive(true);
            }
            if (oldCellz > currentCellz)
            {
                oldCellx = currentCellx;
                oldCellz = currentCellz;

                var findchild1 = GameObject.Find(room3);
                var findchild2 = findchild1.transform.Find("exits");
                var findchild3 = findchild2.transform.Find("exit door");
                var findchild4 = findchild3.transform.Find("-Z exit");
                var findchild5 = findchild4.transform.Find("-Z Trigger Point");
                findchild5.transform.gameObject.SetActive(false);
                var findchild6 = findchild4.transform.Find("+X exit");
                var findchild7 = findchild6.transform.Find("+X Trigger Point");
                findchild7.transform.gameObject.SetActive(true);
                var findchild8 = findchild4.transform.Find("-X exit");
                var findchild9 = findchild8.transform.Find("-X Trigger Point");
                findchild9.transform.gameObject.SetActive(true);
            }
        }
    }
}
