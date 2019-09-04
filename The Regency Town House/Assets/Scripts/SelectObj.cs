using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectObj : MonoBehaviour
{
    private Text label;
    private GameObject bgLabel;
	private GameObject Fire_dining;


    // Start is called before the first frame update
    void Start()
    {
        label = GameObject.Find("Text").GetComponent<Text>();
        label.text = "";

        bgLabel = GameObject.Find("Image");
        bgLabel.SetActive(false);

		Fire_dining = GameObject.Find ("Fire_dining");
		Fire_dining.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {	//this is for mouse testing
		#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
				
                bgLabel.SetActive(true);
				label.text = hit.transform.name.ToString();
            }
            else
            {
                bgLabel.SetActive(false);
                label.text = "";
            }
        }
		#elif UNITY_IOS
		//this is for ios devices
		//var particle : GameObject;
		if(Input.GetTouch(0).phase == TouchPhase.Stationary || (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).deltaPosition.magnitude < 1.2f))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit))
			{

				bgLabel.SetActive(true);
				label.text = hit.transform.name.ToString();
				if(hit.transform.name == "fire_place_dining")
				{
					if(Fire_dining.activeSelf == false) Fire_dining.SetActive(true);
					else Fire_dining.SetActive(false);
					
				
				}
			}
			else
			{
				bgLabel.SetActive(false);
				label.text = "";
			}
		}
		#endif
			
    }
}
