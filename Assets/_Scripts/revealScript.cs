using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revealScript : MonoBehaviour {
    public GameObject myParticle;
    bool reveal;
    public float life;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(reveal)
        {
            myParticle.transform.position += new Vector3(-10 * Time.deltaTime, 0, 0);
            life-=Time.deltaTime;
        }
        if(life<=0)
        {
            myParticle.SetActive(false);
        }
	}
    void OnTriggerEnter(Collider myPlayer)
    {
        Debug.Log("!!");
        if (reveal==false&&myPlayer.gameObject.tag=="Player")
        {
            reveal = true;
           
        }
    }
}
