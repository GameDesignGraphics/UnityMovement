using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    Rigidbody Rb;

    //Floats for Charecter Height

    public float YProneHeight = 0.25f; //Size while prone
    public float YCrouchHeight = 0.5F; //Size while Crouching
    public float YStandHeight = 1.0F;  //Size while Standing
    public float YHeight;              //Hold Current Height of Charecter
    
    //Floats for Charecter Speed

    public float walkSpeed = 5.0f;      //speed of walking
    public float jumpForce = 2.0f;      //force applied when you jump = height of jump
    public float sprintSpeed = 10f;     //speed of sprinting
    public float crouchSpeed = 2f;      //speed while crouching
    public float proneSpeed = 0.5f;     //speed while prone
    public float turnSpeed = 30f;       // how fast your charecter turns.
    public Vector3 jump;
    public float moveSpeed;             //this holds current speed..either walk,sprint,crouch or prone speed.
    public bool isGrounded;             // holds value for if player is touching the ground or not.



    //SET KEYS FOR MOVEMENT ETC.

    public KeyCode KeyToMoveForward;
    public KeyCode KeyToMoveLeft;
    public KeyCode KeyToMoveRight;
    public KeyCode KeyToMoveBackwards;
    public KeyCode KeyToMoveCrouch;
    public KeyCode KeyToMoveJump;
    public KeyCode KeyToMoveProne;
    public KeyCode KeyToMoveSprint;
    public KeyCode KeyToMoveZoom;
    public KeyCode KeyToMoveTurnSpeedDown;
    public KeyCode KeyToMoveTurnSpeedUp;


    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void OnCollisionExit()
    {
        isGrounded = false;
    }



    // Start is called before the first frame update
    void Start()
    {
       Rb = GetComponent<Rigidbody>();
       jump = new Vector3(0.0f, 2.0f, 0.0f);
       moveSpeed = walkSpeed;                  //Sets the movespeed to walking speed.
       YHeight = YStandHeight;                 //Sets your height to Standing Height.
    }

    // Update is called once per frame
    void Update()
    {
        //Turn left
        if (Input.GetKey(KeyToMoveTurnSpeedDown))
            transform.Rotate(Time.deltaTime * turnSpeed * Vector3.down);

        //Turn right
        if (Input.GetKey(KeyToMoveTurnSpeedUp))
            transform.Rotate(Time.deltaTime * turnSpeed * Vector3.up);

        //MoveBackwards
        if (Input.GetKey(KeyToMoveBackwards))
            transform.position += Time.deltaTime * moveSpeed * transform.right;

        //Move left
        if (Input.GetKey(KeyToMoveLeft))
            transform.position += Time.deltaTime * moveSpeed * -transform.right; // negative right gives us left

        //Move forward
        if (Input.GetKey(KeyToMoveForward))
            transform.position += Time.deltaTime * moveSpeed * transform.forward;

        //Move right
        if (Input.GetKey(KeyToMoveRight))
            transform.position += Time.deltaTime * moveSpeed * -transform.forward; // negative forward gives us backward

        //Jumping
        if (Input.GetKey(KeyToMoveJump) && isGrounded)  // if player is grounded and jump is pressed

        {
            Rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;                         // player is off the ground
        }

        //Sprint


        if (Input.GetKey(KeyToMoveSprint))      // if sprint button pressed 
       
        {
            moveSpeed = sprintSpeed;           //sets move speed to sprintspeed
        }
        
        if (Input.GetKeyUp(KeyToMoveSprint))  // if sprint button released
        
        {
            moveSpeed = walkSpeed;             // sets move speed to walkspeed
        }



        //crouch

        if (Input.GetKey(KeyToMoveCrouch))      // if Crouch button pressed 
        {
            transform.localScale = new Vector3(transform.localScale.x, YHeight = YCrouchHeight, transform.localScale.y);    //sets corrent Height to Crouch Height
            
            moveSpeed = crouchSpeed;            //sets move speed to crouchspeed
        }

        if (Input.GetKeyUp(KeyToMoveCrouch)) // if crouch button released
        {
            transform.localScale = new Vector3(transform.localScale.x, YHeight = YStandHeight, transform.localScale.y);     //sets current Height to StandHeight
            
            moveSpeed = walkSpeed;             // sets move speed to walkspeed
        }



        //prone


        if (Input.GetKey(KeyToMoveProne))      // if Prone button pressed 
        {
            transform.localScale = new Vector3(transform.localScale.x, YHeight = YProneHeight, transform.localScale.y);    //sets current Height to ProneHeight
            
            moveSpeed = proneSpeed;           //sets move speed to Pronespeed
        }

        if (Input.GetKeyUp(KeyToMoveProne)) // if Prone button released
        {
            transform.localScale = new Vector3(transform.localScale.x, YHeight = YStandHeight, transform.localScale.y);   //set current Height to Stand Height
           
            moveSpeed = walkSpeed;             // sets move speed to walkspeed
        }

    }

}




    
