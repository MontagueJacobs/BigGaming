using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamisTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem carParticles;
    [SerializeField] float startParticleTime = 10f;
    Driver car;


    
    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Driver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (car.getMoveForce().magnitude > startParticleTime) 
            carParticles.Play();
        else 
            carParticles.Stop(); 
    }
}
