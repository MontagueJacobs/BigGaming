using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
 
   bool hasPackage = false;
   [SerializeField] float delay = 0.5f;

   void Start()
   {
  
   }
   void OnCollisionEnter2D(Collision2D other)
   {
    Debug.Log("Ouch!");
   }
    void OnTriggerEnter2D(Collider2D other)
   {
    //if (the thing we trigger is the package)
    //then print "package picked up" to the console
    if(other.tag == "Package" && !hasPackage){
       hasPackage = true;
       Debug.Log("Package picked up!");
     
       Destroy(other.gameObject,delay); 
    }
    if(other.tag == "DeliveryLoc" && hasPackage){
      hasPackage = false;
      Debug.Log("Package dropped off!");
    }

   }
}
