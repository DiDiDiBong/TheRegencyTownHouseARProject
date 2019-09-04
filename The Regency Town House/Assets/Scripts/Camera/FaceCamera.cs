using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public GameObject camera;
    public GameObject Obj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Obj.transform.LookAt(Obj.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
        
    }
}
