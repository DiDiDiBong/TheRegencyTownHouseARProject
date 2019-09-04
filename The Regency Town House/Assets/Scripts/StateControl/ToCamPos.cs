using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCamPos : MonoBehaviour
{
    // Move the Obj to camera position
    public GameObject cam;
    public GameObject Obj;
    // Start is called before the first frame update

    public void MoveToCam()
    {
        Obj.transform.position = cam.transform.position - new Vector3(0,0.2f,0);
    }




}
