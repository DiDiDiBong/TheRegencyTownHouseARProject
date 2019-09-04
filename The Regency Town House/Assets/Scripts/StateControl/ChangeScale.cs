using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    public float scale;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    public void AdjustScale(float newScale)
    {
        scale = newScale;
    }
}
