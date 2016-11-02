using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Particle : MonoBehaviour {
    //Particle Position Tracker
    public Vector3 position ;
    //Gravity 
    public Vector3 gravity;
    //Mass 
    public int mass;
    //velocity 
    public Vector3 velocity;
    //SetGRavity on or off
    bool trigger;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        position = transform.position;
        velocity = transform.position.normalized;
        gravity =  ActiveGravity();
        mass = 90;
    }
 

    private void LateUpdate() {
        velocity /= mass;
        velocity += gravity;
        transform.position = position  + velocity * Time.deltaTime;
    }

    Vector3 ActiveGravity() {
        if ( Input.GetKeyDown(KeyCode.Z))
            return new Vector3(0, -10, 0);
        else if (Input.GetKeyUp(KeyCode.Z))
            return Vector3.zero;
        return new Vector3(0, -10, 0);
    }
}
