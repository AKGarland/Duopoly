using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true; // Indicates whether or not the game is being recording

    private bool paused = false;
    private float initialFixedDelta;

    private void Start( )
    {
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsLevelUnlocked(2));
        initialFixedDelta = Time.fixedDeltaTime;  // This is set in Project Settings -> Time -> Fixed Timestep
    }

    void Update( ) {
        if (CrossPlatformInputManager.GetButton("Fire1"))  // Fire1 determined in the input manager, default key is left ctrl key
        {
            recording = false;
        }
        else
        {
            recording = true;
        }
        if (Input.GetKeyDown(KeyCode.P) && paused)
        {
            UnPause( );
        } else if (Input.GetKeyDown(KeyCode.P) && !paused)
        {
            PauseGame( );
        }


    }

    void PauseGame( )
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        paused = true;
    }

    void UnPause( )
    {
        paused = false;
        Time.timeScale = 1;
        Time.fixedDeltaTime = initialFixedDelta;
    }
}
