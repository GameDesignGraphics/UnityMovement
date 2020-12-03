using UnityEngine;



public class PlayerLook : MonoBehaviour
{
    public float speedX = 2.0f; //Speed of Horizontal Rotation
    public float speedY = 2.0f; //Speed of Vertical Rotation

    private float yaw = 0.0f;    //Vertical
    private float pitch = 0.0f; //Horizontal

    private void Start()
    {

      
    }


    void Update()
    {
        

        yaw += speedX * Input.GetAxis("Mouse X");
        pitch -= speedY * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }


}