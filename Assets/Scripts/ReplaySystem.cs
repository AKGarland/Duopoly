using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 100;  // Creating the circular buffer with 100 frames
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;
    private GameManager gameManager;

	void Start () {
        rigidBody = GetComponent<Rigidbody>( );
        gameManager = FindObjectOfType<GameManager>( );
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.recording == true) 
        {
            Record( );
        }
        else  // Pressing ctrl begins playback
        {
            Playback( );
        }
	}

    public void Record( )
    {
        rigidBody.isKinematic = false;  // Allows input to control the object during Playback
        int frame = Time.frameCount % bufferFrames;  // Sets the circular buffer
        float time = Time.time;

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }

    public void Playback( )
    {
        rigidBody.isKinematic = true;  // Prevents input from controlling the object during Playback
        int frame = Time.frameCount % bufferFrames;
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }
}

/// <summary>
/// A structure for storing time, rotation, & position  
/// </summary>
public class MyKeyFrame
{
    public float frameTime;
    public Vector3 position;  // public so that keyFrames[frame].position is accessible in Playback()
    public Quaternion rotation;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        frameTime = time;
        position = pos;
        rotation = rot;
    }

   
}
