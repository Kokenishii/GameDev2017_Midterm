using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockHandScript : MonoBehaviour {
    public Color colorActivated;
    Color originalColor;
    ParticleSystem myParticle;
	// Use this for initialization
	void Start () {
        originalColor = gameObject.GetComponent<ParticleSystem>().startColor;	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponentInParent<TraceCubeGravity>().underControl==true)
        {
            gameObject.GetComponent<ParticleSystem>().startColor = colorActivated;
            
            
        }
        else
        {
            gameObject.GetComponent<ParticleSystem>().startColor = originalColor;



        }
    }
}
