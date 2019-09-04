using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Material TargetMat;

    public List<Material> OriginalMat = new List<Material>();

    public List<GameObject> ChildrenWithTag = new List<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Material GetMaterial(int i)
    {
        return OriginalMat[i];
    }

    public void ClearMatList()
    {
        OriginalMat.Clear();
    }

    public void AddMat(Material Mat)
    {
        OriginalMat.Add(Mat);
    }
}
