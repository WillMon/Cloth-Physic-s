using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour {
    // Game Object that will be duplicated 
    public GameObject clonedObject;
    //Loication where the object will be spawned at
    public Transform spawnLocation;
    //
    public List<GameObject> group;
    // Size of the grid
    public int grid = 5 ;
    // Game Object being cloned
    GameObject clone;



	// Use this for initialization
	void Start () {
        clone = GetComponent<GameObject>();
        spawnLocation = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void Awake() {
        Creat();
    }
    private void Creat() {
       
        for (int i = 0; i < grid; ++i) {
            for(int j = 0;j < grid; ++j) {
                Vector3 spawn = new Vector3(5 * i, 5 * j, 0);
                clone = (GameObject)Instantiate(clonedObject, spawn, Quaternion.identity);
                clone.transform.SetParent(spawnLocation);
                group.Add(clone);
            } 
        }
    }
}
