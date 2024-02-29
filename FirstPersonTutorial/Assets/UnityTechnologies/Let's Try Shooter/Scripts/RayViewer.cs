using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour
{
    public float weaponRange = 50;
    private Camera fpscam;
    void Start()
    {
        fpscam = GetComponentInParent<Camera>();
    }

    void Update()
    {
        Vector3 lineOrigin = fpscam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrigin, fpscam.transform.forward * weaponRange, Color.yellow); 
    }
}
