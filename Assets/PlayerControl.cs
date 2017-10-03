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
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CharacterController myPlayer = GetComponent<CharacterController>();
       //using chcontroller cuz i don't need actual physics for my player
       
        if (myPlayer.isGrounded)
        {
            playerDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            print("grounded");
            if(Input.GetKeyDown(KeyCode.Space ))
            {
                playerDirection.y = 8f;
                print("Pressed");
            }


            playerDirection = transform.TransformDirection(playerDirection);
            //This line is very important, it adjust the direction of the transformation to the  "forward"

            transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -Input.GetAxis("Horizontal") * zSpeed);
            transform.eulerAngles += new Vector3(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
            // theCamera.transform.localPosition = new Vector3 (Input.GetAxis("Horizontal")* 0.8f, theCamera.transform.localPosition.y, theCamera.transform.localPosition.z);
            playerDirection *= speed * Time.deltaTime;
        }

        playerDirection.y += gravity * Time.deltaTime;
        myPlayer.Move(playerDirection); 


    }
}