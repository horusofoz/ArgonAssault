using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        AddNonTriggerBoxCollider();
	}

    private void AddNonTriggerBoxCollider()
    {
        Collider enemgyCollider = gameObject.AddComponent<BoxCollider>();
        enemgyCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        print("Particles collided with enemy " + gameObject.name);
        Destroy(gameObject);
    }
}
 