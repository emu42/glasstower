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
        /*
        List<XRInputSubsystem> lst = new List<XRInputSubsystem>();
        SubsystemManager.GetInstances<XRInputSubsystem>(lst);
        for (int i = 0; i < lst.Count; i++)
        {
            List<Vector3> bps = new List<Vector3>();
            bool v = lst[i].TryGetBoundaryPoints(bps);
            print("boundary found: " + v);
            if (v)
            {
                foreach (Vector3 bp in bps)
                {
                    Instantiate(placeThis, bp, Quaternion.identity);
                }
            }
        }
        */
        Vector3[] bps = PXR_Boundary.GetGeometry(BoundaryType.OuterBoundary);

        // for debugging
        if (placeThis != null)
        {
            foreach (Vector3 bp in bps)
            {
                Instantiate(placeThis, bp, Quaternion.identity);
            }
        }

        float minX = bps[0].x;
        float maxX = minX;
        float minZ = bps[0].z;
        float maxZ = minZ;
        foreach (Vector3 bp in bps)
        {
            minX = Mathf.Min(minX, bp.x);
            maxX = Mathf.Min(maxX, bp.x);
            minZ = Mathf.Min(minZ, bp.z);
            maxZ = Mathf.Min(maxZ, bp.z);
        }

        float centerX = (minX + maxX) / 2.0f;
        float centerZ = (minZ + maxZ) / 2.0f;

        // centering in placespace
        print("moving origin by " + centerX + "," + centerZ);
        transform.position = new Vector3(transform.position.x + centerX, transform.position.y, transform.position.z - centerZ);
    } 
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
