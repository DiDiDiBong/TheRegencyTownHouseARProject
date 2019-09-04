using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Coded by Jinghuai Lin
public class FirePlaceOn : MonoBehaviour
{
	public GameObject fireEffect ;
	private Text label;
	private GameObject bgLabel;
	private bool isOn;
  private GameObject Fire_dining;
    // Start is called before the first frame update
    void Start()
    {
		label = GameObject.Find("Text").GetComponent<Text>();
		label.text = "";

		bgLabel = GameObject.Find("Image");
		bgLabel.SetActive(false);
		isOn = false;
		Fire_dining = fireEffect;
		Fire_dining.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetTouch(0).phase == TouchPhase.Stationary || (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).deltaPosition.magnitude < 1.2f))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit))
			{

				bgLabel.SetActive(true);
				label.text = hit.transform.name.ToString();

				if(hit.collider.gameObject == gameObject)
				{
					if (isOn == false) {
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
			else
			{
				bgLabel.SetActive(false);
				label.text = "";
			}
		}
    }
}
