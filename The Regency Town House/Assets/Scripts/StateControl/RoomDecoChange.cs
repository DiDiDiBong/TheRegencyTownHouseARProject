using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDecoChange : MonoBehaviour
{
    public GameObject[] Room;
    public ObjectShifter OS;
    //public int No = 10;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchRoom()
    {
        for(int i = 0; i<Room.Length; i++)
        {
            if (Room[i].activeSelf == true)
            {
                //Room[i].SetActive(false);

                //No = i;
                //Room[i].SetActive(false);
                if (i<(Room.Length-1)) 
                {
                    Room[i+1].SetActive(true);
                    for(int j = 0; j<OS.WaitingList.Length; j++)
                    {
                        if (OS.WaitingList[j] == Room[i])
                        {
                            OS.WaitingList[j] = Room[i+1];
                        }
                    }
                }
                else
                {
                    Room[0].SetActive(true);
                    for(int j = 0; j<OS.WaitingList.Length; j++)
                    {
                        if (OS.WaitingList[j] == Room[i])
                        {
                            OS.WaitingList[j] = Room[0];
                        }
                    }
                }
                
                Room[i].SetActive(false);
                break;
            }
        }
    }
}
