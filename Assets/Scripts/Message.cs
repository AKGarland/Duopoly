using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {
    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>( );
        text.text = "Start here";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
