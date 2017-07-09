using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {

    private Text text;

    public int section = 1;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>( );
        text.text = "Start here";
	}
	
	// Update is called once per frame
	void Update () {
        if (section == 2)
        {
            text.text = "Now continue";
        }
	}
}
