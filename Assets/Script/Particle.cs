using UnityEngine;
using System.Collections.Generic;
using System;


[Serializable]
public class Particle
{
    public Particle() { }

    public Vector3 position;
    
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 force;
    public float mass;
    public bool ankred;
    int indexY, indexX; 
    public Particle(Vector3 pos, float m) {
        position = pos;
        velocity = position.normalized;
        mass = m;
        force = Vector3.zero;
        ankred = true;

    }

    public void AddForce(Vector3 forced)
    {
        if(ankred)
            force += forced;
    }

    public void Update() {
      
            acceleration = (1 / mass) * force;
            velocity += acceleration ;
            position += velocity * Time.deltaTime;
        
    }
};

[Serializable]
public class SpringDamper
{
    public SpringDamper() { }

    public Particle p1;
    public Particle p2;
    Vector3 SpringForce;
    public float Ks;
    public float Kd;
    public float Lo;


    public SpringDamper(Particle Particle1, Particle Particle2) {
        p1 = Particle1;
        p2 = Particle2;
    }
    Vector3 DamperForce(Particle p1,Particle p2) {
        Vector3 eStar = p2.position - p1.position;
        float length = eStar.magnitude;
        return eStar / length;

    }
    public void  ComputeForce()
    {
        Vector3 dist = p2.position - p1.position;//Set the distance from one point to another 

        Vector3 direction = dist.normalized;   //Gets the direction of the positions 

        float velocity1DP1 = Vector3.Dot(direction, p1.velocity);   //First Dimention value of the velocity of the starting position 

        float velocity1DP2 = Vector3.Dot(direction, p2.velocity);  //First Dimention value of the velocity of the ending position 

        float Fs = -Ks * (Lo - dist.magnitude);  //Spring Force liner

        float Fd = -Kd * (velocity1DP1 = velocity1DP2);   //demping force liner

        SpringForce = (Fs + Fd) * direction;   //Set the 1Dimetional Velocity  back to 3 Dimention

        p1.AddForce(SpringForce);
    }
};             