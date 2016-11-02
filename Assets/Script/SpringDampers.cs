using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpringDampers : MonoBehaviour {
    //Ks 
    public float springConstatn;
    //Kd
    public float dampingFactor;
    //I0
    public float restLength;

    List<GameObject> particleList ;
	// Use this for initialization
	void Start () {
        particleList = GetComponent<ObjectSpawner>().group;

	}
	
	// Update is called once per frame
	void Update () {
        String();
	}
    void String()
    {

        int nextIndex = 0;

        for (int p = 0; p < particleList.Count; ++p)
        {
            if (p + nextIndex <= particleList.Count - 1 )
            {
                nextIndex = (int)Mathf.Sqrt(particleList.Count) + 1;

                Particle start = particleList[p].GetComponent<Particle>();
                Particle end = particleList[p + nextIndex].GetComponent<Particle>();

                Debug.DrawLine(start.position, end.position);

                start.velocity = start.velocity * Vector3.Dot(start.velocity, SpringDamperForce(start.position, end.position));
                end.velocity = end.velocity * Vector3.Dot(end.velocity, SpringDamperForce(start.position, end.position));
            }
        }
    } 
    void ComputeForce() {

    }
    //Formula for Spring Damper Force 
    Vector3 SpringDamperForce (Vector3 p1,Vector3 p2) {
        Vector3 eStar;
        float l;
        Vector3 e;
        eStar = p2 - p1;
        l = eStar.magnitude;
        e = eStar / l;
        return e;
    }
}


