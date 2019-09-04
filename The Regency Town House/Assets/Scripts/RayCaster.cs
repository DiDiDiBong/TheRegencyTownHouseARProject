using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    //public GameObject Object_1;
    //public GameObject Object_2;
    public GameObject emptyObject;
    public GameObject hit_Object;
    // Start is called before the first frame update
    void Start()
    {
        hit_Object = emptyObject;

    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
				
                hit_Object = hit.collider.gameObject;
            }

        }
		#elif UNITY_IOS

        if(Input.GetTouch(0).phase == TouchPhase.Stationary || (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).deltaPosition.magnitude < 1.2f))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit))
			{
                hit_Object = hit.collider.gameObject;
            }
        }
        #endif
        else
        {
            hit_Object = emptyObject;
        }
    }
}
