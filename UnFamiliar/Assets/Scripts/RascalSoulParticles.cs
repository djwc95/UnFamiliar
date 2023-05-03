using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RascalSoulParticles : MonoBehaviour
{
    public ParticleSystem particles;

    public void InstantiateParticles()
    {
        particles.Play();
    }
}
