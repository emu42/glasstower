using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class PlaceInCenterOfPlayspace : MonoBehaviour
{
    public GameObject markPlayspaceBorderWithThis;

    public GameObject moveThisToCenterOfPlayspace;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] bps = PXR_Boundary.GetGeometry(BoundaryType.OuterBoundary);

        // for debugging
        if (markPlayspaceBorderWithThis != null)
        {
            foreach (Vector3 bp in bps)
            {
                Instantiate(markPlayspaceBorderWithThis, bp, Quaternion.identity);
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
