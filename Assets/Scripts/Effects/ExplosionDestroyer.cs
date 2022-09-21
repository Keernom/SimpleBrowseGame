using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyer : MonoBehaviour
{
    float _lifeTime;

    private void Start()
    {
        _lifeTime = GetComponent<ParticleSystem>().main.startLifetime.constantMax;
        Destroy(gameObject, _lifeTime);
    }
}
