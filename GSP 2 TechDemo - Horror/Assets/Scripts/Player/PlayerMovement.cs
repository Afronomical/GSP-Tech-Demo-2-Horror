using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private float currentMoveSpeed;
    public float groundDrag = 10;
    public float airDrag = 10;

    [Header("Sprinting")]
    public float sprintMultiplier = 1.25f;
    private float stamina;
    public float maxStamina = 1000;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool canJump;

    Vector3 moveDirection;
    [SerializeField]KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField]KeyCode jumpKey = KeyCode.Space;

    [Header ("Ground Check")]
    public float playerHeight;
    public LayerMask groundLayer;
    bool grounded;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        currentMoveSpeed= moveSpeed;
        stamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
        MyInput();
        SpeedLimiter();
        if (grounded)
        {
            rb.drag = groundDrag;
            ResetJump();
        }
        else
        {
            rb.drag = airDrag;
        }
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }


    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(jumpKey)  && canJump && grounded)
        {
            Jump();
            
        }
        if(Input.GetKey(sprintKey) && stamina > 0 && grounded)
        {
            Sprint(true);
            UIManager.instance.SetStaminaUI(stamina/maxStamina);
        }
        else
        {
            Sprint(false);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        

        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * currentMoveSpeed * 10, ForceMode.Force);
        }
        else
        {
            //rb.AddForce(moveDirection.normalized * currentMoveSpeed * 10 * airMultiplier, ForceMode.Force);   //move in air
        }
    }

    private void SpeedLimiter()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > currentMoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * currentMoveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        canJump = false;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        canJump = true;
    }

    private void Sprint(bool isSprinting)
    {
        if (isSprinting)
        {
            currentMoveSpeed = moveSpeed * sprintMultiplier;
            stamina--;
        }
        else
        {
            currentMoveSpeed = moveSpeed;
        }
    }
}
