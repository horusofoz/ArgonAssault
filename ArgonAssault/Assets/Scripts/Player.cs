using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("In ms")] [SerializeField] float xRange = 5f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawNewXPos, -5f, 5f);

        transform.localPosition = new Vector3(clampedXpos, transform.localPosition.y, transform.localPosition.z);
	}
}
