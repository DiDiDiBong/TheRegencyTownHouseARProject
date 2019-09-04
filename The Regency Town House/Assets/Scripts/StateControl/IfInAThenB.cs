using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfInAThenB : MonoBehaviour
{
    // If one of the GameObject in A[] is active, B is active
    public GameObject[] A;
    //public GameObject A_2;
    public GameObject B;


    // Start is called before the first frame update
    void Start()
    {
        B.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        for (int i = 0; i< A.Length; i++)
        {
            if (A[i] != null && A[i].activeInHierarchy == true)
            count++;
        }
        if (count > 0) B.SetActive(true);
        else B.SetActive(false);
    }
}
