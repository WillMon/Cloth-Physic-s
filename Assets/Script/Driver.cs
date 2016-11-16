using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Driver : MonoBehaviour
{

    public List<Particle> particalList;
    public List<GameObject> Spheres;
    public List<SpringDamper> spring;
    public int tracker;
    public int width = 5, hight = 5, desieredMass = 20;
    
    //public Particle p1, p2;
    [Range(0,100)]
    public float KsInput,KdInput,LoInput;

    // Use this for initialization
    void Start()
    {
        KsInput = .10f;
        KdInput = .10f;
        LoInput = .5f;

        particalList = new List<Particle>();
        Spheres = new List<GameObject>();
        spring = new List<SpringDamper>();
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < hight; ++j)
            {

                particalList.Add(new Particle(new Vector3(i * 5, j * 5, 0), 20));
                Spheres.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));
                Spheres[tracker].transform.position = particalList[tracker].position;
                ++tracker;
            }
        }

        particalList[ width - 1].ankred = true;
        particalList[tracker - 1].ankred = true;
        // Sets the dampers for the 
        for (int i = 0; i < tracker; ++i)
        {
            if (i % width != width - 1)
                spring.Add(new SpringDamper(particalList[i], particalList[i + 1]));
            if(i < tracker-width)
                spring.Add(new SpringDamper(particalList[i], particalList[i + width]));
            if (i % width != width - 1 && i < tracker - width)
                spring.Add(new SpringDamper(particalList[i], particalList[i + width + 1]));
            if (i % width != 0 && i < tracker - width)
                spring.Add(new SpringDamper(particalList[i], particalList[i + width - 1]));
        }
        particalList[width - 1 ].ankred = false;
        particalList[tracker - 1].ankred = false;
    }

    // Update is called once per frame
    void Update()  {

    }
    void LateUpdate()
    {
         foreach (Particle p in particalList)
            p.AddForce(new Vector3(0, -1, 0));
        foreach (SpringDamper s in spring) 
            s.ComputeForce();
        foreach (Particle p in particalList)
            p.Update();
        foreach (SpringDamper s in spring)
            Debug.DrawLine(s.p1.position, s.p2.position);
        for (int i = 0; i < tracker; ++i)
            Spheres[i].transform.position = particalList[i].position;
   
    }
} 