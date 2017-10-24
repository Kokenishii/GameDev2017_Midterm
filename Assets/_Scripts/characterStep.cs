using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStep : MonoBehaviour {
    public float rotateAdd;
    public float rotateBound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Vertical")!=0)
        {
            transform.Rotate(0f, rotateAdd, 0f);
            if (transform.localEulerAngles.y >= 180 + rotateBound || transform.localEulerAngles.y <= 180-rotateBound)
            {
               rotateAdd = -rotateAdd;
            }
           
        }
        
    }
}
