using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfABThenC : MonoBehaviour
{
    // If GameObject A is active, so is B
    public GameObject A_1;
    public GameObject A_2;
    public GameObject B;


    // Start is called before the first frame update
    void Start()
    {
        B.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (A_1.activeSelf == true && A_2.activeSelf == true) B.SetActive(true);
        else B.SetActive(false);
    }
}
