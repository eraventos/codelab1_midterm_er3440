using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed of boat and make it editable
    public float moveSpeed = 5f;
    // How quickly it rotates in degrees per second
    public float turnSpeed = 100f;

    void Update()
    {
        // check if player is pressing W/S or A/D to control forward and turning movement 
        float moveInput = Input.GetAxis("Vertical");   // W/S
        float turnInput = Input.GetAxis("Horizontal"); // A/D

        // Move forward/backward in boat's facing direction (custom "forward" = local right because my model is wrong)
        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
    }
}


