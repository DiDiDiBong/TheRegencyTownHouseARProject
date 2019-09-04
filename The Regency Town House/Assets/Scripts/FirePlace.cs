using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlace : MonoBehaviour
{
    public GameObject fireEffect ;
    public RayCaster TC;

	private bool isOn;
    private GameObject Fire_dining;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
		Fire_dining = fireEffect;
		Fire_dining.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(TC.hit_Object == gameObject)
        {
            if(isOn == false) 
            {
				Fire_dining.SetActive (true);
				isOn = true;
			} 
			else 
			{
				Fire_dining.SetActive (false);
				isOn = false;
			}
        }
    }
}
