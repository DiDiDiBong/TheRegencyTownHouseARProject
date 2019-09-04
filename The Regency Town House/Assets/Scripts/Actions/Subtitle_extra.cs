using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtitle_extra : MonoBehaviour
{
    public GameObject[] text;
    public float TimeDu = 5.0f;

    private float TimeInterval = 0;
    private int Num = -1;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i< text.Length; i++)
        {
            if (text[i] != null)
            {
                text[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (TimeInterval < TimeDu)
        {
            TimeInterval += Time.deltaTime;
            if (Num != GlobalVar.SubtitleCount_extra)
            {
                for (int i = 0; i< text.Length; i++)
                {
                    if (text[i] != null)
                    {
                        text[i].SetActive(false);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i< text.Length; i++)
            {
                if (text[i] != null)
                {
                    text[i].SetActive(false);
                }
            }
        }
    }

    public void ShowSubtitle()
    {
        GlobalVar.SubtitleCount_extra += 1;
        Num = GlobalVar.SubtitleCount_extra;
        for (int i = 0; i< text.Length; i++)
        {
            if (text[i] != null)
            {
                text[i].SetActive(true);
            }
        }
        TimeInterval = 0;
        
    }
}

