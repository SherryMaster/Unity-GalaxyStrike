using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed;
    [SerializeField] float xClampRange = 10f;
    [SerializeField] float yClampRange = 10f;

    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlYawFactor = 20f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float rotationSpeed = 5f;

    Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerMovement();
        HandlePlayerRotation();
    }

    private void HandlePlayerMovement()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void HandlePlayerRotation()
    {
        // Calculate roll (z-axis rotation) based on horizontal movement
        float targetRollAngle = -controlRollFactor * movement.x;

        // Calculate pitch (x-axis rotation) based on vertical movement  
        float targetPitchAngle = controlPitchFactor * movement.y;

        // Get current rotation
        Quaternion currentRotation = transform.localRotation;

        // Create target rotation with both roll and pitch
        Quaternion targetRotation = Quaternion.Euler(targetPitchAngle, 0, targetRollAngle);

        // Smoothly interpolate between current and target rotation
        transform.localRotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        Debug.Log("Movement Input: " + movement);
    }
}
