using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float speed = 10f;
    [Tooltip("In ms")] [SerializeField] float xRange = 8f;
    [Tooltip("In ms")] [SerializeField] float yRange = 5.5f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(-30f, 30f, 0f);
    }

    private void ProcessTranslation()
    {
        // Movement
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffest = yThrow * speed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        float rawNewYPos = transform.localPosition.y + yOffest;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        // Update position
        transform.localPosition = new Vector3(clampedXpos, clampedYPos, transform.localPosition.z);
    }
}
