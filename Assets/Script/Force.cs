using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Force : MonoBehaviour
{
    public bool triggred;

    public Vector3 gravity;

    List<GameObject> particlList;
    // Use this for initialization
    void Start()
    {
        triggred = false;
        gravity = new Vector3(0,-9f,0);
        particlList = GetComponent<ObjectSpawner>().group;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggred)
            foreach (GameObject p1 in particlList)
                p1.GetComponent<Particle>().force = p1.GetComponent<Particle>().mass * gravity;

    }
}
