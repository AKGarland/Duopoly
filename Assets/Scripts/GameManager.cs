using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true; // Indicates whether or not the game is being recording
	
	void Update () {
        if (CrossPlatformInputManager.GetButton("Fire1"))  // Fire1 determined in the input manager, default key is left ctrl key
        {
            recording = false;
        }
        else
        {
            recording = true;
        }
	}

    public void Recording( )
    {
        recording = true;
    }

    public void Playback( )
    {
        recording = false;
    }
}
