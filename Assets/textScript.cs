using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textScript : MonoBehaviour
{
    public Text myText;
    [TextArea(3, 10)]
    public string myString;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider myPlayer)
    {
        if (myPlayer.tag == "Player")
        {
            myText.text = myString;
        }
    }
    void OnTriggerExit(Collider myPlayer)
    {
        if (myPlayer.tag == "Player")
        {
            myText.text = "";
        }
    }
}
