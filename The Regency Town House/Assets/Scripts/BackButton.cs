using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    public ObjectShifter objectShifter;
    public string tag;


    void Start()
    {
        tag = "whole";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickBack()
    {
        if(tag == "whole")
        {
            // Do nothing
        }
        else if(tag == "each_floor" )
        {
            // Back to whole building
            for(int i =0; i < objectShifter.WaitingList.Length; i++)
            {
                if ( objectShifter.WaitingList[i] != null)
                {
                    if(objectShifter.WaitingList[i].tag == "whole")
                    {
                        objectShifter.WaitingList[i].SetActive(true);
                    }
                    else
                    {
                        objectShifter.WaitingList[i].SetActive(false);
                    }
                }
            }
            tag = "whole";
        }
        else if(tag == "base_room")
        {
            // Back to basement
        }
        else if(tag == "ground_room")
        {
            //Back to ground floor
        }
    }
}
