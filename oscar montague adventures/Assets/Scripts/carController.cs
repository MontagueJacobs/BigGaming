using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    [Header("Car settings")]
    public float accelerationFactor = 30.0f;
    public float turnFactor = 1.5f;
    public float driftFactor = 0.05f;
    //local variables
    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;
    [SerializeField] public float maxSpeed = 20f;
    float velocityVsUp = 0;
    //Components
    Rigidbody2D carRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        carRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        ApplyEngineForce();

        killOrthogonalVelocity();
        
        ApplySteering();
    }

    void ApplyEngineForce() 
    {
        //Calculate how much "forward" we are going in terms of the direction of our velocity
        velocityVsUp = Vector2.Dot(transform.up, carRigidBody2D.velocity);

        //Limit so we cannot go faster than the max speed in the "forward direction"
        if (velocityVsUp > maxSpeed && accelerationInput > 0)
            return;
        //Limit so we cannot go faster than 50% of the max speed in the "reverse direction"
        if (velocityVsUp < maxSpeed * 0.5f && accelerationInput < 0)
            return;

        if (carRigidBody2D.velocity.magnitude > maxSpeed * maxSpeed && accelerationInput > 0)
            return;

        //Apply Drag if there is no acceleration
        if (accelerationInput == 0)
        {
            carRigidBody2D.drag = Mathf.Lerp(carRigidBody2D.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else 
        {
            carRigidBody2D.drag = 0;
        }

        //create a force for the engine
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        //Apply force and pushes the car forward
        carRigidBody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }
    void ApplySteering() 
    {
        //limit cars ability to rotate while moving slowly
        float minSpeedforAllowTurningFactor = carRigidBody2D.velocity.magnitude / 8;
        minSpeedforAllowTurningFactor = Mathf.Clamp01(minSpeedforAllowTurningFactor);
        //Update the roation angle based on input
        rotationAngle -= steeringInput * turnFactor * minSpeedforAllowTurningFactor;

        //Apply steering by rotating the car object
        carRigidBody2D.MoveRotation(rotationAngle);
    }
    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
    void killOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidBody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidBody2D.velocity, transform.right);
        carRigidBody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
    }
}
