using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
   [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
   [SerializeField] Color32 noPackageColor = new Color32(2,2,2,2);
   SpriteRenderer spriteRenderer;
   bool package = false;
   [SerializeField] float delay = 0.5f;

   void Start()
   {
      spriteRenderer = GetComponent<SpriteRenderer>();
   }
   void OnCollisionEnter2D(Collision2D other)
   {
    Debug.Log("Ouch!");
   }
    void OnTriggerEnter2D(Collider2D other)
   {
    //if (the thing we trigger is the package)
    //then print "package picked up" to the console
    if(other.tag == "Package" && !package){
       package = true;
       Debug.Log("Package picked up!");
       spriteRenderer.color = hasPackageColor;
       Destroy(other.gameObject,delay); 
    }
    if(other.tag == "DeliveryLoc" && package){
      package = false;
      Debug.Log("Package dropped off!");
      spriteRenderer.color = noPackageColor;
    }

   }
}
