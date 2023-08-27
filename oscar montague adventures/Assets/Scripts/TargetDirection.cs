using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDirection : MonoBehaviour
{
     public Transform target;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Look = transform.InverseTransformPoint(target.transform.position);
        float Angle = Mathf.Atan2(Look.y, Look.x)*Mathf.Rad2Deg -90;

        transform.Rotate(0,0,Angle);
    }
}
