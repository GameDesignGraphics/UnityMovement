using UnityEngine;



public class mouseLook : MonoBehaviour 
{
    public float speedX = 2.0f; //Speed of Horizontal Rotation
    public float speedY = 2.0f; //Speed of Vertical Rotation

    //public float MinYaw;      //Minimum Rotation
    //public float MaxYaw;      //Maximum Rotation
    public float MinPitch;      //Minimum Vertical
    public float MaxPitch;      //Maximum Vertical
    public float yaw = 0.0f;    //Vertical
    public float pitch = 0.0f;  //Horizontal

    private void Start()
    {

        Cursor.visible = false; //sets cursor visiblity to negative
        Cursor.lockState = CursorLockMode.Locked; // Locks cursor to center of screen
    }


    void Update()
    { 

        //yaw = Mathf.Clamp(yaw, MinYaw, MaxYaw);
        pitch = Mathf.Clamp(pitch, MinPitch, MaxPitch);

        yaw += speedX * Input.GetAxis("Mouse X");
        pitch -= speedY * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }   


}