using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    Vector3 playerDirection = Vector3.zero;
    //Decalre vector3, set it to <0,0,0> to prevent ambuiguity
    public float speed = 0.1f;
    public float rotateSpeed;
    public float zSpeed;
    public GameObject theCamera;
   public float gravity;
    public float gravityAcceleration;
    public int gravityDirection = 0;
    GameObject myRain;
    public float xSpeed = 3f;
    public bool isUnderControl;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        CharacterController myPlayer = GetComponent<CharacterController>();
        //using chcontroller cuz i don't need actual physics for my player


        playerDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        //  print("grounded");
        if (Input.GetKeyDown(KeyCode.Space) && myPlayer.isGrounded)
        {
            playerDirection.y = 20f;
            print("Pressed");
        }



        //This line is very important, it adjust the direction of the transformation to the  "forward"

        //transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -Input.GetAxis("Horizontal") * zSpeed);
        //transform.localEulerAngles +=new Vector3(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0, Space.Self);
        // theCamera.transform.localPosition = new Vector3 (Input.GetAxis("Horizontal")* 0.8f, theCamera.transform.localPosition.y, theCamera.transform.localPosition.z);
        playerDirection *= speed * Time.deltaTime;


        if (gravityDirection == 0)
        {


            playerDirection.y += gravity * Time.deltaTime;

        }
        //  else if(gravityDirection==1|| gravityDirection == -1)
        // {
        //  playerDirection.x+= gravityDirection* gravity * Time.deltaTime;
        // }

        //   playerDirection = transform.TransformDirection(playerDirection);
        playerDirection = transform.TransformDirection(playerDirection);
        myPlayer.Move(playerDirection);
        //  CharacterController myPlayer = GetComponent<CharacterController>();
        //  //using chcontroller cuz i don't need actual physics for my player
        // // gravity -= 9.8f * Time.deltaTime;
        // // gravityAcceleration -= 5f * Time.deltaTime;
        ////  gravity = -5;
        //  if (myPlayer.isGrounded)
        //  {
        //   //   gravity = 0;
        //     // gravityAcceleration = 0;
        //    //  print("isGrounded");
        //  }
        //  if (myPlayer.isGrounded)
        //  {
        //      playerDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        //      //  print("grounded");
        //      //if(Input.GetKeyDown(KeyCode.Space )&& myPlayer.isGrounded)
        //      //{
        //      //  //  playerDirection.y = 20f*Time.deltaTime;
        //      // //   print("Pressed");
        //      //}



        //      //This line is very important, it adjust the direction of the transformation to the  "forward"

        //      //transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -Input.GetAxis("Horizontal") * zSpeed);
        //      //transform.localEulerAngles +=new Vector3(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        //      transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0, Space.Self);
        //      //if (playerDirection.z!=0)
        //      //{

        //      //}
        //      //else
        //      //{
        //      //    playerDirection.x = Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
        //      //}
        //  }


        //  // theCamera.transform.localPosition = new Vector3 (Input.GetAxis("Horizontal")* 0.8f, theCamera.transform.localPosition.y, theCamera.transform.localPosition.z);
        //  playerDirection *= speed * Time.deltaTime;
        //  playerDirection.y = playerDirection.y + gravity * Time.deltaTime;




        //  //+gravityAcceleration*Time.deltaTime;


        //  //  else if(gravityDirection==1|| gravityDirection == -1)
        //  // {
        //  //  playerDirection.x+= gravityDirection* gravity * Time.deltaTime;
        //  // }

        //  //   playerDirection = transform.TransformDirection(playerDirection);
        //  playerDirection = transform.TransformDirection(playerDirection);

        //  myPlayer.Move(playerDirection); 


    }
}