using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {
    bool isInRegion;
    public bool isActive;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isInRegion)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isActive = true;
            }
        }
        
    }
    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            isInRegion = true;
        }
    }
}
