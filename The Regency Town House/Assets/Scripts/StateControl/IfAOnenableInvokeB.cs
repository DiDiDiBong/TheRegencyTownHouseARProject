using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfAOnenableInvokeB : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent Actions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        Actions.Invoke();
    }
}
