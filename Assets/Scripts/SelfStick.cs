using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfStick : MonoBehaviour {

    public float panSpeed = 10f;  // Public so it can be edited as necessary in Unity

    private GameObject player;
    private Vector3 armRotation;  // Camera is childed & positioned at the end of this stick so rotation 

    // Use this for initialization
    void Start( )
    {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles; // Converts the rotation from type Quarternion to Vector3 so it can interact with the joystick input
    }

    // Update is called once per frame
    void Update () {
        armRotation.z += Input.GetAxis("RHoriz")*panSpeed;
        armRotation.y += Input.GetAxis("RVert") * panSpeed;

        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRotation); // Converts back from Vector3 to Quarternion
	}
}
