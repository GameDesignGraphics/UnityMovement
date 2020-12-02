using UnityEngine;

public class PlayerZoom : MonoBehaviour
{

    public KeyCode KeyToMoveZoom;    // Set Key To Move Zoom in Unity

    
    public float SFieldOfView = 60;  //Starting Field Of View
    public float CFov;               //Current Field Of View
    public float ZFieldOfView = 30;  //Zoom Field Of View
    

    private void Start()
    {
        CFov = SFieldOfView;         //Current Field Of View set to Starting Field Of View
    }
    
    void Update()
    {

            //When Key To Move Zoom is pressed

        if (Input.GetKeyDown(KeyToMoveZoom))
        {                           
            //Change to Zoom Field Of View

              gameObject.transform.GetComponent<Camera>().fieldOfView = ZFieldOfView;

        }

             //When Key To Move Zoom is Released

        if (Input.GetKeyUp(KeyToMoveZoom))
        {                          
            //Change To Start Field Of View

            gameObject.transform.GetComponent<Camera>().fieldOfView = SFieldOfView;

        }
    }

}