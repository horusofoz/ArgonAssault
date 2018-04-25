﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
	
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
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
 