using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float ControlSpeed = 10f;
    [Tooltip("In ms")] [SerializeField] float xRange = 8f;
    [Tooltip("In ms")] [SerializeField] float yRange = 4.5f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;

    [Header("Control-throw Based")]
    [SerializeField] float positionYawFactor = 6.5f;
    [SerializeField] float ControlRollFactor = -20f;

    float xThrow, yThrow;

    bool isControlEnabled = true;
	
	// Update is called once per frame
	void Update ()
    {
        if(isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * ControlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        // Movement
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = xThrow * ControlSpeed * Time.deltaTime;
        float yOffest = yThrow * ControlSpeed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        float rawNewYPos = transform.localPosition.y + yOffest;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        // Update position
        transform.localPosition = new Vector3(clampedXpos, clampedYPos, transform.localPosition.z);
    }

    private void OnPlayerDeath() // Called by string reference
    {
        print("Player dead");
        isControlEnabled = false;
    }
}
