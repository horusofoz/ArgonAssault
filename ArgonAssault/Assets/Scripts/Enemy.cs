using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerKill = 100;
    [SerializeField] int hits = 3;

    ScoreBoard scoreBoard;
	
	void Start ()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}

    private void AddBoxCollider()
    {
        Collider enemgyCollider = gameObject.AddComponent<BoxCollider>();
        enemgyCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        hits = hits - 1;
        if(hits <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        scoreBoard.ScoreKill(scorePerKill);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
 