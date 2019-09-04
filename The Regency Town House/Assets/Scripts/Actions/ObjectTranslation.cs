﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTranslation : MonoBehaviour
{
    public GameObject Obj;

    public Vector3 translate_distance;
    public float speed = 1;
    //public int translate_axis;
    //public Vector3 translate_distance;
    //public float translate_speed;

    //public Vector3 current_angle;

    // state 0: original state
    // state 1: changed state
    public bool state;
    public bool isOn = false;
    //public float dd;

    //public bool isOn = false;

    //private Transform original_transform;
    //private Transform target_transform;
    private Vector3 translated_distance;
    //private Vector3 translated_distance;
    // Start is called before the first frame update
    void Start()
    {
        state = false;
        isOn = false;
        //original_transform = Obj.transform;
        //target_transform = Obj.transform;
        //target_transform.localEulerAngles += rotate_angle;
        //target_transform.localPosition += translate_distance;
        translated_distance = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        //dd = Vector3.Distance(-translate_distance, translated_distance);
        // If state 0, rotate/translate Obj to set angle/position
        if (state == false && isOn == true)
        {
            // if obj not rotated to target angle
            //if (Vector3.Distance(rotated_angle, rotate_angle)>1)
            
            if (Vector3.Distance(translate_distance, translated_distance) > 0.01)
            {
                //Obj.transform.localEulerAngles += rotate_angle * speed * Time.deltaTime;
                Obj.transform.localPosition += translate_distance * speed * Time.deltaTime;
                //rotated_angle += rotate_angle * speed * Time.deltaTime;
                translated_distance += translate_distance * speed * Time.deltaTime;
            }
            else
            {
                //rotated_angle = Vector3.zero;
                translated_distance = Vector3.zero;
                isOn = false;
            }

        }
        else if(state == true && isOn == true)
        {
            // if obj not rotated to target angle
            if (Vector3.Distance(-translate_distance, translated_distance) > 0.01)
            {
                //Obj.transform.localEulerAngles += -rotate_angle * speed * Time.deltaTime;
                Obj.transform.localPosition += -translate_distance * speed * Time.deltaTime;
                //rotated_angle += -rotate_angle * speed * Time.deltaTime;
                translated_distance += -translate_distance * speed * Time.deltaTime;
            }
            else
            {
                translated_distance = Vector3.zero;
                //translated_distance = Vector3.zero;
                isOn = false;
            }
        }
        //current_angle = Obj.transform.localEulerAngles;
    }

    public void SwitchState()
    {
        if (state == false && isOn == false)
        {
            isOn = true;
            state = true;
        }
        else if (state == true && isOn == false)
        {
            isOn = true;
            state = false;
        }
    }
}
