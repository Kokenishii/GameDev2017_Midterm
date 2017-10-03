using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCube : MonoBehaviour {
    public GameObject myBtn;
    public float desiredPosition=0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool btnActive = myBtn.GetComponent<TriggerScript>().isActive;
        if (btnActive)
        {
            if (transform.localPosition.y >= -1.31)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, desiredPosition, transform.localPosition.z);
            }

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, desiredPosition, transform.localPosition.z), 0.1f);
        }
    }
}
