using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class PlaceInCenterOfPlayspace : MonoBehaviour
{
    public GameObject placeThis;

    // Start is called before the first frame update
    void Start()
    {
        List<XRInputSubsystem> lst = new List<XRInputSubsystem>();
        SubsystemManager.GetInstances<XRInputSubsystem>(lst);
        for (int i = 0; i < lst.Count; i++)
        {
            List<Vector3> bps = new List<Vector3>();
            bool v = lst[i].TryGetBoundaryPoints(bps);
            print("boundary found: " + v);
            if (v) { 
                foreach (Vector3 bp in bps)
                {
                    Instantiate(placeThis, bp, Quaternion.identity);
                }
            }
        }

        foreach (Vector3 bp in PXR_Boundary.GetGeometry(BoundaryType.PlayArea))
        {
            Instantiate(placeThis, bp, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
