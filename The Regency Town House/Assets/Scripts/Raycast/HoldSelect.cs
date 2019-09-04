using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// This Script is for raycast selection 
public class HoldSelect : MonoBehaviour
{
    
    public GameObject emptyObject;
    public GameObject hit_Object;
    public Text label_2;
    public Image loading_base;
    public Image loading_front;
    public AudioSource selectSound;

    public LayerMask ignore_mask;

    public GameObject hit_Object_temp;
    // Start is called before the first frame update
    void Start()
    {
        hit_Object = emptyObject;
        hit_Object_temp = emptyObject;
        //int layer_mask = mask;
        //ignore_mask = ~ignore_mask;

    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,Mathf.Infinity,ignore_mask))
            {
                // Check is raycast hit UI
                if (!IsPointerOverUIObject())
                {
                    hit_Object = hit.collider.gameObject;
                    label_2.text = hit_Object.transform.name.ToString();
                    selectSound.Play();
                }
                
            }

        }
		#elif UNITY_IOS

        int touchCount = Input.touchCount;
        // If only one finger touch (exclude rotate and scale)
        if(touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // If finger down (phase: Began) and hit a selectable object
            // Display the 'finger_held' loading image. 
            if(touch.phase == TouchPhase.Began)
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			    RaycastHit hit;
			    if(Physics.Raycast(ray,out hit,Mathf.Infinity,ignore_mask))
			    {   
                    // Check is raycast hit UI
                    if (!IsPointerOverUIObject())
                    {
                        loading_base.gameObject.SetActive(true);
                        loading_base.gameObject.transform.position = touch.position;
                        loading_front.gameObject.SetActive(true);
                        loading_front.rectTransform.sizeDelta = new Vector2(50,50);
                        loading_front.gameObject.transform.position = touch.position;
                        hit_Object_temp = hit.collider.gameObject;
                    }
                    
                }
            }

            // If finger held (phase: Stationary or Moved and deltaPosition is small)
            // Rotate the 'finger_held' loading image.
            if(touch.phase == TouchPhase.Stationary || (touch.phase == TouchPhase.Moved && touch.deltaPosition.magnitude < 1.2f))
            {
                //finger_held.gameObject.SetActive(true);
                loading_base.gameObject.transform.position = touch.position;
                loading_front.gameObject.transform.position = touch.position;
                
                loading_front.rectTransform.sizeDelta +=  new Vector2(150 * Time.deltaTime / 0.3f, 150 * Time.deltaTime / 0.3f );

                //Vector3 v = finger_held.gameObject.transform.eulerAngles;
                //v.z += Time.deltaTime * 180;
                //finger_held.gameObject.transform.eulerAngles = v ;

                // If Raycast doesn't hit on the original target or no hit, break.
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			    RaycastHit hit;
			    if(Physics.Raycast(ray,out hit,Mathf.Infinity,ignore_mask))
			    {   
                    // Check if raycast hit UI
                    if (!IsPointerOverUIObject())
                    {
                        if(hit_Object_temp != hit.collider.gameObject)
                        {
                            loading_base.gameObject.SetActive(false);
                            loading_front.rectTransform.sizeDelta = new Vector2(50,50);
                            loading_front.gameObject.SetActive(false);

                            hit_Object = emptyObject;
                            hit_Object_temp = emptyObject;
                        }

                    }
                    
                }
                else
                {
                    loading_base.gameObject.SetActive(false);
                    loading_front.rectTransform.sizeDelta = new Vector2(50,50);
                    loading_front.gameObject.SetActive(false);
                    hit_Object = emptyObject;
                    hit_Object_temp = emptyObject;
                }


                if((/* touch.deltaTime >= 0.3f || */ loading_front.rectTransform.sizeDelta.x >= 200) && hit_Object_temp != emptyObject)
                {
                    hit_Object = hit_Object_temp;
                    hit_Object_temp = emptyObject;
                    label_2.text = hit_Object.transform.name.ToString();
                    selectSound.Play();
                }
                
            }

            if(touch.phase == TouchPhase.Ended)
            {
                loading_base.gameObject.SetActive(false);
                loading_front.rectTransform.sizeDelta = new Vector2(50,50);
                loading_front.gameObject.SetActive(false);

                if(/* touch.deltaTime >= 0.3f || */ loading_front.rectTransform.sizeDelta.x >= 200)
                {
                    hit_Object = hit_Object_temp;
                    hit_Object_temp = emptyObject;
                    label_2.text = hit_Object.transform.name.ToString();
                    selectSound.Play();
                }
                else
                {
                    hit_Object = emptyObject;
                    hit_Object_temp = emptyObject;
                }
                
                //finger_held.gameObject.SetActive(false);
                //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			    //RaycastHit hit;
			    //if(Physics.Raycast(ray,out hit))
			    //{   
                //    if(hit_Object_temp == hit.collider.gameObj)
                //    {

                //    }
                //    //hit_Object = hit.collider.gameObject;
                //}
            }
        }
        // If touchCount > 1
        else
        {
            loading_base.gameObject.SetActive(false);
            loading_front.rectTransform.sizeDelta = new Vector2(50,50);
            loading_front.gameObject.SetActive(false);
            hit_Object = emptyObject;
            hit_Object_temp = emptyObject;
        }

        #endif
    }

    // When touching UI
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
