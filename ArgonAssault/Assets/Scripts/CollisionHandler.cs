using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.name;
        print("Player triggered " + name);
    }
}
