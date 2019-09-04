using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableObj : MonoBehaviour
{
    //public GameObject SelectController;
    public HoldSelect RC;
    public Text label;
    //public Outline OL;

    public UnityEngine.Events.UnityEvent Actions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Outline>() != null)
        {
            if(RC.hit_Object_temp == gameObject)
            {
                GetComponent<Outline>().enabled = true;
            }
            else GetComponent<Outline>().enabled = false;

        }
        //if(RC.hit_Object_temp == gameObject)
        //{
        //    GetComponent<Outline>().enabled = true;
        //}
        //else GetComponent<Outline>().enabled = false;

        if(RC.hit_Object == gameObject)
        {
            label.text = "Selected";
            RC.hit_Object = RC.emptyObject;
            Actions.Invoke();

            //if(isOn == false) 
            //{
				
			//	isOn = true;
			//} 
			//else 
			//{
			//	Fire_dining.SetActive (false);
			//	isOn = false;
			//}
        }
    }
}
