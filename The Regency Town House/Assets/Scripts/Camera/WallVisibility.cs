﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVisibility : MonoBehaviour
{
    public GameObject Cam;
    public MatManager Mat_Manager;
    public float cam_y;
    public float control_parent_y;
    public float relative_angle;
    public GameObject control_parent;
    public GameObject[] parent;
    //public GameObject parent_2;
    //public List<GameObject> ChildrenWithTag = new List<GameObject>();
    //public List<Material> OriginalMat = new List<Material>();
    
    public string search_tag;
    //public int child_count;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<parent.Length; i++)
        {
            if (parent[i] != null)
            {
                GetChildrenWithTag(parent[i], null);
            }
        }
        //GetChildrenWithTag(parent_1, null);
        //GetChildrenWithTag(parent_2, null);
        Mat_Manager.OriginalMat.Clear();
        Mat_Manager.ChildrenWithTag.Clear();
        for (int i = 0; i<Mat_Manager.ChildrenWithTag.Count; i++)
            {
                //Material CurrentMat = ChildrenWithTag[i].GetComponent<Renderer>().material;
                Mat_Manager.OriginalMat.Add(Mat_Manager.ChildrenWithTag[i].GetComponent<Renderer>().material);
                //ChildrenWithTag[i].GetComponent<Renderer>().material = Mat_Manager.TargetMat;
               ////ChildrenWithTag[i].SetActive(false);
            }
    }

    void OnEnable()
    {
        // return the original Mat to objects
        for (int i = 0; i<Mat_Manager.ChildrenWithTag.Count; i++)
            {
                //Material CurrentMat = ChildrenWithTag[i].GetComponent<Renderer>().material;
                Mat_Manager.ChildrenWithTag[i].GetComponent<Renderer>().material = Mat_Manager.OriginalMat[i];
                //Mat_Manager.OriginalMat.Add(Mat_Manager.ChildrenWithTag[i].GetComponent<Renderer>().material);
                //ChildrenWithTag[i].GetComponent<Renderer>().material = Mat_Manager.TargetMat;
               ////ChildrenWithTag[i].SetActive(false);
            }
    }

    // Update is called once per frame
    void Update()
    {
        string search_tag_new = null;
        cam_y = Cam.transform.eulerAngles.y;
        control_parent_y = control_parent.transform.eulerAngles.y;
        relative_angle = cam_y - 90 - control_parent_y;
        if (relative_angle < 0) relative_angle = 360 + relative_angle;

        if (relative_angle <= 15 || relative_angle > 345 ) search_tag_new = "wall_1";
        else if (relative_angle > 15 && relative_angle <= 165) search_tag_new = "wall_2";
        else if (relative_angle > 165 && relative_angle <= 195) search_tag_new = "wall_3";
        else search_tag_new = "wall_4";
        
        if (search_tag_new != search_tag)
        {
            for (int i = 0; i<Mat_Manager.ChildrenWithTag.Count; i++)
            {

                Mat_Manager.ChildrenWithTag[i].GetComponent<Renderer>().material = Mat_Manager.OriginalMat[i];

                
                //ChildrenWithTag[i].SetActive(true);
            }
            // update children with new tag
            Mat_Manager.ChildrenWithTag.Clear();
            for(int i = 0; i<parent.Length; i++)
            {
                if (parent[i] != null)
                {
                    GetChildrenWithTag(parent[i], search_tag_new);
                }
            }
            Mat_Manager.OriginalMat.Clear();
            //if (ChildrenWithTag.Count > 0) firstchildInTag = ChildrenWithTag[0];
            for (int i = 0; i<Mat_Manager.ChildrenWithTag.Count; i++)
            {
                Material CurrentMat = Mat_Manager.ChildrenWithTag[i].GetComponent<Renderer>().material;
                Mat_Manager.OriginalMat.Add(CurrentMat);
                Mat_Manager.ChildrenWithTag[i].GetComponent<Renderer>().material = Mat_Manager.TargetMat;
               ////ChildrenWithTag[i].SetActive(false);
            }
        }
        search_tag = search_tag_new;
    }



    public void GetChildrenWithTag(GameObject parent, string _tag)
    {
        //ChildrenWithTag.Clear();
        //child_count = parent.transform.childCount;
        for (int i =0; i < parent.transform.childCount; i++ )
        {
            Transform child = parent.transform.GetChild(i);
            if (child.tag == _tag)
            {
                if (child.childCount>0)
                {
                    GetAllLastNode(child.gameObject);
                }
                else
                {
                    Mat_Manager.ChildrenWithTag.Add(child.gameObject);
                }
                
            }
            //digui
            //if (child.childCount > 0)
            //{
            //    GetChildrenWithTag(child.gameObject, _tag);
            //}
        }
    }

    public void GetAllLastNode(GameObject parent)
    {
        for (int i =0; i < parent.transform.childCount; i++ )
        {
            Transform child = parent.transform.GetChild(i);
            if(child.childCount>0)
            //recursive
            {
                GetAllLastNode(child.gameObject);
            }
            else
            {
                Mat_Manager.ChildrenWithTag.Add(child.gameObject);
            }
                
        }
    }
}

