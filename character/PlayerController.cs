using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, sensitivity, jumpHeight = 5;
    private float maxVel, y_offset;
    private Rigidbody rb;
    private Vector2 move, look;
    public CinemachineVirtualCamera cam;
    private CinemachineTransposer transposer;
    public bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
        y_offset = transposer.m_FollowOffset.y;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    private void LateUpdate()
    {
        Look();
    }

    private void Move()
    {
       // Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.y * moveSpeed);

        targetVelocity = transform.TransformDirection(targetVelocity);

       // Vector3 velocityChange = targetVelocity - currentVelocity;

        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z);        
    }
    private void Look()
    {
        transform.Rotate(Vector3.up * look.x * sensitivity);
        y_offset += -look.y * sensitivity * 0.1f;
        y_offset = Mathf.Clamp(y_offset, 0f, 10f);
        transposer.m_FollowOffset.y = y_offset;
    }
    private void jump()
    {
        // calculating jump speed to reach jump height
        float jumpVel = Mathf.Pow(2f * 9.8f * jumpHeight, 0.5f);
        rb.velocity = new Vector3(rb.velocity.x, jumpVel, rb.velocity.z);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        Vector2.ClampMagnitude(move, maxVel);
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }
    public void onJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            jump();
        }
    }
}
