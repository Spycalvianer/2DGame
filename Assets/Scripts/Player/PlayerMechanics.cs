using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMechanics : MonoBehaviour
{
    [Header("Components")]
    Rigidbody2D rb;
    public Transform groundcheckPosition;
    public GameObject sprite;

    [Header("Variables")]
    [HideInInspector] public float xAxis;
    [HideInInspector] public bool doubleJumpActivated, upwardsDashActivated, dashActivated;
    [HideInInspector] public bool canPerformAction;
    [HideInInspector] public float startMovementSpeed;

    //Jumping and Dashing Variables
    public float jumpForce, movementSpeed, upwardsDashForce, dashAmount;
    bool jumpIsPressed, isGrounded, upwardsDashPressed, dashPressed;
    public float groundcheckRadius;
    public LayerMask groundLayer;
    public float doubleJumpForce;
    int jumpCount, upwardsDashCount;
    public float waitDash;

     //Hiding Variables
    public bool hideInput;
    bool canMove = true;
    public bool canHide;
    float hideableTimer = 0;

    [Header("Data")]
    public int dashStaminaCost;
    public int upwardsDashStaminaCost;
    public int doubleJumpStaminaCost;
    public int hidingStaminaCost;
    PlayerData data;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        data = GetComponent<PlayerData>();

    }
    private void Start()
    {
        upwardsDashActivated = false;
        doubleJumpActivated = false;
        startMovementSpeed = movementSpeed;
        canPerformAction = true;
    }

    void Update()
    {
        GetInput();
        Movement();
        Flip();
        Jump();
        GroundCheck();
        DoubleJump();
        UpwardsDash();
        ResetCounts();
        ForwardDash();
        Hiding();
    }
    void GetInput()
    {
        xAxis = Input.GetAxis("Horizontal");
        jumpIsPressed = Input.GetButtonDown("Jump");
        upwardsDashPressed = Input.GetKeyDown(KeyCode.Mouse1);
        dashPressed = Input.GetKeyDown(KeyCode.Mouse0);
        hideInput = Input.GetKey(KeyCode.H);
    }

    void Movement()
    {
        if (canMove)
        {
            transform.position += new Vector3(xAxis * movementSpeed * Time.deltaTime, 0, 0);
        }

    }
    void Flip()
    {
        if (xAxis > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (xAxis < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    void Jump()
    {
        if (jumpIsPressed && isGrounded && canPerformAction)
        {
            rb.velocity = new Vector2(0, jumpForce);
        }
    }
    void DoubleJump()
    {
        if (!isGrounded && jumpCount < 1 && doubleJumpActivated && jumpIsPressed && canPerformAction)
        {
            rb.velocity = new Vector2(0, doubleJumpForce);
            jumpCount++;
            data.StaminaCost(doubleJumpStaminaCost);
        }
    }
    void UpwardsDash()
    {
        if(upwardsDashCount < 1 && upwardsDashPressed && upwardsDashActivated && canPerformAction)
        {
            rb.AddForce(transform.up * upwardsDashForce, ForceMode2D.Impulse);
            upwardsDashCount++;
            data.StaminaCost(upwardsDashStaminaCost);
        }
    }
    IEnumerator Dash()
    {
        data.StaminaCost(dashStaminaCost);
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(transform.localScale.x * dashAmount, 0);
        yield return new WaitForSeconds(waitDash);
        rb.gravityScale = originalGravity;
    }
    void ForwardDash()
    {
        if (dashPressed && dashActivated && canPerformAction)
        {
            StartCoroutine(Dash());
        }
    }
    void ResetCounts()
    {
        if (isGrounded)
        {
            jumpCount = 0;
            upwardsDashCount = 0;
        }
    }
    
    public void Hiding()
    {
        if (hideInput && canHide && data.playerStamina > 0)
        {
            sprite.SetActive(false);
            canMove = false;
            if (sprite.activeSelf == false)
            {
                data.HidingStaminaCost(hidingStaminaCost);
            }
        }
        else if(data.playerStamina <= 0)
        {
            canHide = false;
            
            hideableTimer += Time.deltaTime;
            if(hideableTimer >= 3)
            {
                canHide = true;
            }
        }
        else 
        {
            sprite.SetActive(true);
            canMove = true;
        }
    }
    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheckPosition.position, groundcheckRadius, groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundcheckPosition.position, groundcheckRadius);
    }
}
