using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public float scalingspeed = 0.01f;
    public GameObject Target_1;
    bool ScaleUp = false;
    bool ScaleDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ScaleUp == true)
        {
            ScaleUpButton();

        }
        if(ScaleDown == true)
        {
            ScaleDownButton();
        }
    }

    public void ScaleUpButton()
    {
        Target_1.transform.localScale += new Vector3(scalingspeed, scalingspeed, scalingspeed);
    }

    public void ScaleDownButton()
    {
        Target_1.transform.localScale += new Vector3(-scalingspeed, -scalingspeed, -scalingspeed);
    }

    public void Up()
    {
        ScaleUp = true;
        ScaleDown = false;
    }

    public void Down()
    {
        ScaleUp = false;
        ScaleDown = true;
    }

    public void stop()
    {
        ScaleDown = false;
        ScaleUp = false;
    }
}
