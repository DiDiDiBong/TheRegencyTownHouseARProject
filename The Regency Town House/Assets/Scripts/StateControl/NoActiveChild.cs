using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoActiveChild : MonoBehaviour
{
    public GameObject parent;
    // If there is no active child in this Gameobject, deactivate this object
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        for (int i = 0 ; i<parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).gameObject.activeSelf == true) count++;
        }
        if (count > 0) parent.SetActive(true);
        else parent.SetActive(false);
        
    }
}
