﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallVisibility_3 : MonoBehaviour
{
    public GameObject Cam;
    public MatManager Mat_Manager;
    public float cam_y;
    public float cam_z;
    public float control_parent_y;
    public float control_parent_z;
    public float relative_angle;
    public float relative_angle_z;
    public GameObject control_parent;
    public GameObject[] parent;
    //public GameObject parent_2;
    public List<GameObject> ChildrenWithTag = new List<GameObject>();
    //public List<Material> OriginalMat = new List<Material>();
    
    public string search_tag_1;
    public string search_tag_2;

    public Text txt1;
    public Text txt2;
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
        for (int i = 0; i<ChildrenWithTag.Count; i++)
            {
                //Material CurrentMat = ChildrenWithTag[i].GetComponent<Renderer>().material;
                Mat_Manager.OriginalMat.Add(ChildrenWithTag[i].GetComponent<Renderer>().material);
                //ChildrenWithTag[i].GetComponent<Renderer>().material = Mat_Manager.TargetMat;
               ////ChildrenWithTag[i].SetActive(false);
            }
            search_tag_1 = "st";
            search_tag_2 = "st";
            txt1.text = search_tag_1;
            txt2.text = search_tag_2;
    }

    // Update is called once per frame
    void Update()
    {
        string search_tag_1_new;
        string search_tag_2_new;
        search_tag_1_new = null;
        search_tag_2_new = null;
        cam_y = Cam.transform.eulerAngles.y;
        cam_z = Cam.transform.eulerAngles.x;
        control_parent_y = control_parent.transform.eulerAngles.y;
        control_parent_z = control_parent.transform.eulerAngles.x;

        relative_angle = cam_y - 90 - control_parent_y;
        relative_angle_z = cam_z - 90 - control_parent_z;

        if (relative_angle < 0) relative_angle = 360 + relative_angle;
        if (relative_angle_z < 0) relative_angle_z = 360 + relative_angle_z;

        if (relative_angle <= 15 || relative_angle > 345)  
        {
            search_tag_1_new = "wall_1";
            if (relative_angle_z < 180)  search_tag_2_new = "Ceiling";
            else search_tag_2_new = "floor";
        }
        else if (relative_angle > 15 && relative_angle <= 165) 
        {
            search_tag_1_new = "wall_2";
            if (relative_angle_z < 180)  search_tag_2_new = "Ceiling";
            else search_tag_2_new = "floor";
        }
        else if (relative_angle > 165 && relative_angle <= 195) 
        {
            search_tag_1_new = "wall_3";
            if (relative_angle_z < 180)  search_tag_2_new = "Ceiling";
            else search_tag_2_new = "floor";
        }
        else 
        {
            search_tag_1_new = "wall_4";
            if (relative_angle_z < 180)  search_tag_2_new = "Ceiling";
            else search_tag_2_new = "floor";
        }

        
        if (search_tag_1_new != search_tag_1)
        {
            for (int i = 0; i<ChildrenWithTag.Count; i++)
            {
                if(ChildrenWithTag[i] != null)
                {
                    ChildrenWithTag[i].GetComponent<Renderer>().material = Mat_Manager.OriginalMat[i];
                }

                

                
                //ChildrenWithTag[i].SetActive(true);
            }
            // update children with new tag
            ChildrenWithTag.Clear();
            for(int i = 0; i<parent.Length; i++)
            {
                if (parent[i] != null)
                {
                    GetChildrenWithTag(parent[i], search_tag_1_new);
                    GetChildrenWithTag(parent[i], search_tag_2_new);
                }
            }
            Mat_Manager.OriginalMat.Clear();
            //if (ChildrenWithTag.Count > 0) firstchildInTag = ChildrenWithTag[0];
            for (int i = 0; i<ChildrenWithTag.Count; i++)
            {
                Material CurrentMat = ChildrenWithTag[i].GetComponent<Renderer>().material;
                Mat_Manager.OriginalMat.Add(CurrentMat);
                ChildrenWithTag[i].GetComponent<Renderer>().material = Mat_Manager.TargetMat;
               ////ChildrenWithTag[i].SetActive(false);
            }
        }
        search_tag_1 = search_tag_1_new;
        search_tag_2 = search_tag_2_new;
        txt1.text = search_tag_1;
        txt2.text = search_tag_2;
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
                    ChildrenWithTag.Add(child.gameObject);
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
                ChildrenWithTag.Add(child.gameObject);
            }
                
        }
    }
}
