using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public Transform myPlayer;
Vector3 moveTo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        moveTo = myPlayer.position - 10 * myPlayer.forward + 5*myPlayer.up;

        transform.position = moveTo;

        //transform.position = Vector3.Slerp(transform.position, moveTo, 0.4f);
      
        transform.LookAt(myPlayer);
        //transform.Rotate(new Vector3(0, 0, myPlayer.eulerAngles.z - transform.eulerAngles.z), Space.Self);
        transform.localRotation = myPlayer.localRotation;

    }
    void FixedUpdate()
    {
       
      
    
    }
}
