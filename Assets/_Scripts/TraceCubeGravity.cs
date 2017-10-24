using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceCubeGravity : MonoBehaviour {
    public AudioClip[] mySound;
    AudioSource myAudio;
    bool hasRotated;
   public GameObject myPlayer;
    float myAngle;
  //float desiredAngle;
    float transitionTime;
    float rotateIndex=0;
   float desiredAngle;
    float playerGravity;
   public float rotateSpeed;
    ParticleSystem myRain;
    public bool underControl;
    int controlStatus = 0;
    public GameObject clockHand;
    // Use this for initialization
    void Start () {
        myAudio = gameObject.GetComponent<AudioSource>();
        underControl = myPlayer.GetComponent<PlayerControl>().isUnderControl;
        underControl = false;
        rotateIndex = 0;
        playerGravity = myPlayer.GetComponent<PlayerControl>().gravity;
        myRain = GameObject.Find("ParticleRain").GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        clockHand.transform.localEulerAngles = new Vector3((controlStatus + 1) * 90,90,0);
        //if (controlStatus >= 4)
        //{
        //    controlStatus = 0;
        //}
        //if (controlStatus <= -1)
        //{
        //    controlStatus = 3;
        //}
        if (desiredAngle<0)
        {
            if (rotateIndex > myAngle)
            {
                //if (myPlayer.transform.localEulerAngles.z - myAngle >= -0.1 || myPlayer.transform.localEulerAngles.z - myAngle <= 0.1)
                //{
                //    myPlayer.transform.localEulerAngles = new Vector3(myPlayer.transform.localEulerAngles.x,
                //          myPlayer.transform.localEulerAngles.y,
                //          desiredAngle
                //        );
                //    rotateIndex = desiredAngle;
                //    //hasRotated = true;
                //}

                myPlayer.transform.RotateAround(myPlayer.transform.position, new Vector3(0, 0, 1), -rotateSpeed);
                rotateIndex-=rotateSpeed;
               // myPlayer.GetComponent<PlayerControl>().gravity = 0;


                //use deltaTime, using float 
                //When it's close enough , snap it
            }
            else
            {
           
             //   myPlayer.GetComponent<PlayerControl>().gravity = playerGravity;
                
            }
        }
 //desireangle>0
        else 
        {
            
            if (rotateIndex < myAngle)
            {
                //if (myPlayer.transform.localEulerAngles.z - myAngle >= -0.1 || myPlayer.transform.localEulerAngles.z - myAngle <= 0.1)
                //{
                //    myPlayer.transform.localEulerAngles = new Vector3(myPlayer.transform.localEulerAngles.x,
                //          myPlayer.transform.localEulerAngles.y,
                //          desiredAngle
                //        );
                //    rotateIndex = desiredAngle;
                //    //hasRotated = true;
                //}
                myPlayer.transform.RotateAround(myPlayer.transform.position, new Vector3(0, 0, 1), rotateSpeed );
                rotateIndex+= rotateSpeed;
                // myPlayer.GetComponent<PlayerControl>().gravity = 0;
               // myPlayer.GetComponent<PlayerControl>().gravity = 0;


            }
            else
            {
                
               // myPlayer.GetComponent<PlayerControl>().gravity = playerGravity;
                //myPlayer.GetComponent<PlayerControl>().gravity = playerGravity;
            }
        }
        
           
    


   

}
    void OnTriggerStay(Collider myCollider)
    {
       
    if(underControl)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                controlStatus = 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                controlStatus = -1;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                controlStatus = 2;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                controlStatus = 0;
            }
        }
        
           
        if (underControl && Input.GetKeyDown(KeyCode.E))
        {
            if (myCollider.tag == "Player")
            {
              

                //myRain.playbackSpeed = Mathf.Lerp(myRain.playbackSpeed,0.1f,0.8f);
                myRain.playbackSpeed = 0.1f;
                //myPlayer = myCollider.gameObject;
                StartCoroutine(GravityBack());
                StartCoroutine(ChangeAngle(controlStatus));
                underControl = false;


                //myCollider.GetComponent<PlayerControl>().gravityDirection = 1;
                // myCollider.gameObject.transform.RotateAround(transform.position, new Vector3(0, 0, 1), -90f);

            }
        }
        if (underControl == false && Input.GetKeyUp(KeyCode.E))
        {
            if (myCollider.tag == "Player")
            {
                myAudio.clip = mySound[0];
                myAudio.Play();
                underControl = true;          
                //StartCoroutine(ChangeAngle());


                //myCollider.GetComponent<PlayerControl>().gravityDirection = 1;
                // myCollider.gameObject.transform.RotateAround(transform.position, new Vector3(0, 0, 1), -90f);

            }
        }
        
       // print(underControl);
    }
   private IEnumerator ChangeAngle(int myDesiredAngle)
    {
        yield return new WaitForSeconds(1.5f);
     
        myAudio.clip = mySound[1];
        myAudio.Play();
        myPlayer.GetComponent<PlayerControl>().gravity = 0;
        desiredAngle = -90f * (myDesiredAngle);
        myAngle = desiredAngle;

        myRain.playbackSpeed = 1f;


    }
    private IEnumerator GravityBack()
    {
        yield return new WaitForSeconds(3f);
      myPlayer.GetComponent<PlayerControl>().gravity = playerGravity; ;
    }



}
