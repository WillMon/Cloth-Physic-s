using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Particle
{
    Particle() { }

    Vector3 particle;
    Vector3 velocity;
    Vector3 acceleration;
    Vector3 force;
    float mass;
    Particle(Vector3 pos, Vector3 vel, float m) {
        particle = pos;
        velocity = vel;
        mass = m;
    }

    void Particle::Update()


};