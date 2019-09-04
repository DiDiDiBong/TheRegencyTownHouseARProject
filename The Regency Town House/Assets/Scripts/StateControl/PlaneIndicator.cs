using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x >= 0.015)
        {
            transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
        }
        else
        {
            transform.localScale += new Vector3(0.01f * Time.deltaTime * 0.6f, 0.01f * Time.deltaTime * 0.6f, 0.01f * Time.deltaTime * 0.6f);
        }
    }
}
