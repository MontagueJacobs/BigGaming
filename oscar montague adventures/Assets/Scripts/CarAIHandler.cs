using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAIHandler : MonoBehaviour
{
    public enum AIMode { followPlayer, followWaypoints};
    //[Header ("All Settings")]

    //Local Variables

    // Start is called before the first frame update
    void Start()
    {
       carController carController = GetComponent<carController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
