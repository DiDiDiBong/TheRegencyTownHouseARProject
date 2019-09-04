using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Dining : MonoBehaviour
{
    public GameObject character;
    public ShiftMat MatShifter;
    public Fireplace LightFireplace;

    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        character.SetActive(false);
        isOn = false;
    }

    // Update is called once per frame
    public void event_on()
    {
        if (isOn == false)
        {
            character.SetActive(true);
            MatShifter.isShifted = false;
            MatShifter.Shift_Mat();
            LightFireplace.isOn = false;
            LightFireplace.fire_place();
            isOn = true;
        }
        else
        {
            character.SetActive(false);
            MatShifter.isShifted = true;
            MatShifter.Shift_Mat();
            LightFireplace.isOn = true;
            LightFireplace.fire_place();
            isOn = false;
        }
    }
}
