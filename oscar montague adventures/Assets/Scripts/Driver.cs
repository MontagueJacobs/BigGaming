using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{       
    [Header("Car stats")]
    [SerializeField] float MoveSpeed = 50;
    [SerializeField] float MaxSpeed = 15;
    [SerializeField] float Drag = 0.98f;
    [SerializeField] float SteerAngle = 20;
    [SerializeField] float IncreasedSteerAngle;
    [SerializeField] Vector3 MoveForce;
    [SerializeField] float Traction;
    private float TractionSave;
    private float DragSave;
    private float MaxSpeedSave;
    
    int MoveDir;
    
    [Header("Slow Time")]
    public TimeManager timeManager;
  
    // Start is called before the first frame update
    void Start()

    {
        MoveDir = 1;
        TractionSave = Traction;
        DragSave = Drag;
        MaxSpeedSave = MaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {   
       move();
    }
    
    void move ()
     {   
    //     if (Input.GetKey(KeyCode.Space))
    //     {    
    //         Debug.Log("sds");
    //         Traction = BreakTraction;
    //         Drag = BreakDrag;  
    //         if (MaxSpeed >= 0)
    //             MaxSpeed-= 0.1f;
    //         else MaxSpeed =0;
    //         Debug.Log(Traction);
    //         Debug.Log(Drag);
    //     }
    //     else
    //     {
    //     //     Traction = TractionSave;
    //     //     Drag = DragSave;
    //     //     MaxSpeed = MaxSpeedSave;
    //     }
        if (Input.GetKey(KeyCode.Space))
        {
            timeManager.SlowMotion();
            SteerAngle = IncreasedSteerAngle;
        }
        else 
        {
            SteerAngle = 20;
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveDir = 1;
        }   
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDir = -1;
        }
        
       // Debug.Log(MoveForce.magnitude);
        MoveForce += transform.up * MoveSpeed * MoveDir * Time.deltaTime;
        transform.position  +=  MoveForce * Time.deltaTime;

        float SteerInput = Input.GetAxis("Horizontal");
       
       transform.Rotate(-Vector3.forward * SteerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);
        
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

      

    	
        Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.up * 3, Color.blue);
       MoveForce = Vector3.Lerp(MoveForce.normalized , transform.up, Traction * Time.deltaTime) * MoveForce.magnitude; 
    
    }

    /* [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] float maxSpeed = 50f;  
    [SerializeField] float Drag = 0.98f;
    // Start is called before the first frame update
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // 
          move();
    }
    
    void move ()
    {
        float moveAmount =  Input.GetAxis("Vertical")*moveSpeed * Time.deltaTime ;
        float steerAmount = Input.GetAxis("Horizontal")*steerSpeed * Time.deltaTime;
        if (moveAmount > maxSpeed){
            if(Input.GetAxis("Vertical")>0)
            {moveAmount+=.01f;}
        }
        
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);

        moveAmount *= Drag;
        

    }*/
}
