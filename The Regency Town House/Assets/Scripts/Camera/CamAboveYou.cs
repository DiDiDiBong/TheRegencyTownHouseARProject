using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAboveYou : MonoBehaviour
{
    public GameObject cam;
    public Material TargetMat;
    public GameObject[] ceiling;
    public List<Material> OriginalMat = new List<Material>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<ceiling.Length; i++)
        {
            if (ceiling[i] != null)
            {
                OriginalMat.Add(ceiling[i].GetComponent<Renderer>().material);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<ceiling.Length; i++)
        {
            if (ceiling[i] != null)
            {
                if(cam.transform.position.y >= ceiling[i].transform.position.y)
                {
                    ceiling[i].GetComponent<Renderer>().material = TargetMat;
                }
                else
                {
                    ceiling[i].GetComponent<Renderer>().material = OriginalMat[i];
                }
            }
        }
    }
}
