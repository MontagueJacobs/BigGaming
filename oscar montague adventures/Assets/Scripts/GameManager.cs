using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] Delivery delivery;
   [SerializeField] TargetDirection targetDirection;
   [SerializeField] GameObject PickUpObject;
   [SerializeField] GameObject DropOffObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (delivery.hasPackage)
        {
            targetDirection.target = DropOffObject.transform;
        }
        else if (!delivery.hasPackage)
        {
         targetDirection.target = PickUpObject.transform;
        }
    }
}
