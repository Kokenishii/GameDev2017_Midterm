using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceCubeGravity : MonoBehaviour {
   public GameObject myPlayer;
    float myAngle;
  //float desiredAngle;
    float transitionTime;
    float rotateIndex=0;
    public float desiredAngle;
    float playerGravity;
	// Use this for initialization
	void Start () {
        rotateIndex = 0;
        playerGravity = myPlayer.GetComponent<PlayerControl>().gravity;

    }
	
	// Update is called once per frame
	void Update () {

 if(desiredAngle<0)
        {
            if (rotateIndex > myAngle)
            {
                myPlayer.transform.RotateAround(myPlayer.transform.position, new Vector3(0, 0, 1), -1);
                rotateIndex--;

                myPlayer.GetComponent<PlayerControl>().gravity = 0;

                //use deltaTime, using float 
                //When it's close enough , snap it
            }
            else
            {
                myPlayer.GetComponent<PlayerControl>().gravity = playerGravity;
            }
        }
 //desireangle>0
        else
        {
            if (rotateIndex < myAngle)
            {
                myPlayer.transform.RotateAround(myPlayer.transform.position, new Vector3(0, 0, 1), 1);
                rotateIndex++;
                myPlayer.GetComponent<PlayerControl>().gravity = 0;
            }
            else
            {
                myPlayer.GetComponent<PlayerControl>().gravity = playerGravity;
            }
        }
        
           
    


   

}
    void OnTriggerStay(Collider myCollider)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (myCollider.tag == "Player")
            {
                //myPlayer = myCollider.gameObject;
               myAngle=desiredAngle;
                //myCollider.GetComponent<PlayerControl>().gravityDirection = 1;
              // myCollider.gameObject.transform.RotateAround(transform.position, new Vector3(0, 0, 1), -90f);

            }
        }
      
    }
 
    
}
