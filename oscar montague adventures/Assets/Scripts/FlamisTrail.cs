using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamisTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem carParticles;
    [SerializeField] ParticleSystem carParticles2;
    [SerializeField] float startParticleTime = 8f;
    Driver car;


    
    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Driver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (car.getMoveForce().magnitude < startParticleTime)
        {
            carParticles.Play();
            carParticles2.Play();
        }

        else 
        { 
            carParticles.Stop();
            carParticles2.Stop();
        }
    }
}
