using UnityEngine;
using System.Collections.Generic;
using System;

[ExecuteInEditMode]
[Serializable]
public class MultipleRotationsHP : motor {
    [SerializeField]
    public Transform mainAxis;
    [SerializeField]
    public List<Transform> Axiss = new List<Transform>();
    
   
    public override void Reset()
    {
        if (mainAxis)
        {
            foreach (Transform T in Axiss)
            {
                T.localRotation = mainAxis.localRotation;
            }
        }
    }
    public void tick(float dt)
    {
        if (mainAxis)
        {
            foreach (Transform T in Axiss)
            {
                T.localRotation = mainAxis.localRotation;
            }
        }
    }
}
