using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShifter : MonoBehaviour
{
    //private int ListCount = 20;
    public GameObject[] WaitingList;
    //public BackButton backButton;

    public string tag = "whole";

    public void ShiftObject(string shiftnumber)
    {
        int CharIndex = shiftnumber.IndexOf("_");

        string str1 = shiftnumber.Substring(0,CharIndex);
        string str2 = shiftnumber.Substring(CharIndex+1);
        int current = int.Parse(str1);
        int target = int.Parse(str2);
        // First, exclude the current Obj;
        // Then, deactivate all;
        // Then activate target obj;
        // Last deactivate current Obj;
        
        for (int i = 0; i < WaitingList.Length; i++)
        {
            if (i != current && WaitingList[i] != null)
            {
                WaitingList[i].SetActive(false);
            }
        }

        WaitingList[target].SetActive(true);
        tag = WaitingList[target].tag;

        // Need to deactivate the current obj(the hitted selectable obj), or the following code wont be execute
        WaitingList[current].SetActive(false);
        
    }

    public void ClickBack()
    {
        if(tag == "whole")
        {
            // Do nothing
        }
        else if(tag == "floor_ground" || tag == "floor_base" || tag == "floor_first" || tag == "floor_second" || tag == "floor_third")
        {
            // Back to whole building
            for(int i =0; i < WaitingList.Length; i++)
            {
                tag = "whole";
                if ( WaitingList[i] != null)
                {
                    if(WaitingList[i].tag == "whole")
                    {
                        WaitingList[i].SetActive(true);
                    }
                    else
                    {
                        WaitingList[i].SetActive(false);
                    }
                }
            }
            
        }
        else if(tag == "base_room")
        {
            // Back to basement
        }
        else if(tag == "ground_room")
        {
            tag = "floor_ground";
            //Back to ground floor
            for(int i =0; i < WaitingList.Length; i++)
            {
                if ( WaitingList[i] != null)
                {
                    if(WaitingList[i].tag == "floor_ground")
                    {
                        WaitingList[i].SetActive(true);
                    }
                    else
                    {
                        WaitingList[i].SetActive(false);
                    }
                }
            }
        }
        else if(tag == "first_room")
        {
            tag = "floor_first";
            //Back to ground floor
            for(int i =0; i < WaitingList.Length; i++)
            {
                if ( WaitingList[i] != null)
                {
                    if(WaitingList[i].tag == "floor_first")
                    {
                        WaitingList[i].SetActive(true);
                    }
                    else
                    {
                        WaitingList[i].SetActive(false);
                    }
                }
            }
        }
    }
}
