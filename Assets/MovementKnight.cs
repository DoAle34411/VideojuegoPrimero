using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementKnight : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player movement
    public float rotationSpeed = 100f; // Speed of player rotation
    public float jumpForce = 7f; // Force of the player jump
    public Transform groundCheck; // Reference to an empty GameObject to check if the player is grounded
    public LayerMask groundMask; // Layer mask to determine what is considered ground
    public float groundDistance = 0.2f; // Distance to check for ground
    private Rigidbody rb; // Reference to the Rigidbody component
    private bool isGrounded; // Flag to check if the player is grounded
    private bool hasJumped; // Flag to check if the player has already jumped

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the reference to the Rigidbody component attached to the player
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Reset the jump flag if the player is grounded
        if (isGrounded)
        {
            hasJumped = false;
        }

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !hasJumped)
        {
            // Apply jump force
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJumped = true; // Set the jump flag to true
        }

        // Rotation input
        float rotationInput = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationInput);
    }

    void FixedUpdate()
    {
        // Movement input
        float horizontalInput = Input.GetAxis("HorizontalArrow");
        float verticalInput = Input.GetAxis("VerticalArrow");
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Perform a raycast to check if the character is on the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundDistance + 0.1f, groundMask))
        {
            // If the character is on the ground, adjust its position to stay on top of the terrain
            Vector3 targetPosition = hit.point + Vector3.up * groundDistance;
            rb.MovePosition(targetPosition);
        }

        // Move the character based on the input
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
    }


}