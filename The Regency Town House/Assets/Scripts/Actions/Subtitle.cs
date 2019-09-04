using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtitle : MonoBehaviour
{

    public GameObject[] text;

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
        
        if (TimeInterval < 5)
        {
            TimeInterval += Time.deltaTime;
            if (Num != GlobalVar.SubtitleCount)
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
        GlobalVar.SubtitleCount += 1;
        Num = GlobalVar.SubtitleCount;
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
