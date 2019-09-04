using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTwoStateSwitch : MonoBehaviour
{
    
// Move the Obj to camera position
    public GameObject cam;
    public GameObject Obj;
    public float MiniScale;
    public float ImmerScale;
    public GameObject Wall_Vis;
    public UnityEngine.Events.UnityEvent Mini_Actions;
    public UnityEngine.Events.UnityEvent Immer_Actions;

    // Start is called before the first frame update
    private Vector3 OriginPos;
    private bool Mode;

    void start()
    {
        OriginPos = Obj.transform.localPosition;
        Mode = false;
    }

    public void MiniState()
    {
        Obj.transform.localPosition = OriginPos;
        Obj.transform.localScale = new Vector3(MiniScale, MiniScale, MiniScale);
        Mode = true;
        Wall_Vis.GetComponent<WallVisibility>().enabled = false;
        Wall_Vis.GetComponent<WallVisibility_2>().enabled = true;
    }

    public void ImmerState()
    {
        Obj.transform.position = cam.transform.position - new Vector3(0,0.2f,0);
        Obj.transform.localScale = new Vector3(ImmerScale, ImmerScale, ImmerScale);
        Mode = false;
        Wall_Vis.GetComponent<WallVisibility>().enabled = true;
        Wall_Vis.GetComponent<WallVisibility_2>().enabled = false;
    }

    public void switchMode()
    {
        if(Mode == false)
        {
            //switch to mini model
            MiniState();
            Mini_Actions.Invoke();
            //Mode = true;
        }
        else
        {
            //switch to Immer model
            ImmerState();
            Immer_Actions.Invoke();
            //Mode = false;
        }

    }
}
