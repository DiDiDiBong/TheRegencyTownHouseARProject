using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGroundPlaneStage : MonoBehaviour
{
    public GameObject GroundPlane;
    // Start is called before the first frame update
    public void Hide()
    {
        GroundPlane.transform.position = new Vector3(0,0,0);
    }
}
