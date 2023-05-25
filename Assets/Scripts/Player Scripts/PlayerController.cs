using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerController : MonoBehaviour
{
    //Variables
    //Component variables
    Rigidbody2D _rb;
    TrailRenderer _tr;
    public static PlayerController instance;

    //Run variables
    private Vector2 moveInput;
    [Range(1, 40)] [SerializeField] private float moveSpeed = 15f;
    [Range(1, 40)] [SerializeField] private float runAccelAmount = 13f;
    [Range(1, 40)] [SerializeField] private float runDeccelAmount = 16f;
    [Range(0, 1)] [SerializeField] private float velPowerGround = 0.96f;
    [Range(0, 1)] [SerializeField] private float velPowerAir;
    private float velPower;
    public bool cantMove = false;
    public static bool isWalking;

    //Jump variables
    private bool isJumping;
    [Range(1,40)][SerializeField] private float jumpForce = 18f;

    //Timer variables
    private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.15f;
    private float jumpBufferCounter;


    //Misc movement variables 
    private bool isFacingRight = true;
    private float frictionAmount = 0.22f;

    //Ground check variables
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    //Animator and Variables
    [SerializeField] Animator anim;

    //Dash variables
    private bool isDashing;
    public bool canDash;
    [SerializeField] private float dashVelocity = 1400f;
    [SerializeField]private float dashTime = 0.2f;
    private Vector2 dashDir;
   
    //Light check variable
    public bool isInLight;
    
    //Falling variables
    private float fallGravityValue = 3.5f;
    public float maxFallSpeed = 28f;
    private float fastFallGravityValue = 5f;
    private float maxFastFallSpeed = 50f;
    private bool isJumpCut;

    //Debug variables






    void Start()
    {
        //Assign Components
        _rb = GetComponent<Rigidbody2D>();
        _tr = GetComponent<TrailRenderer>();
        _tr.emitting = false;
        instance = this;
    }


    void Update()
    {
        //Movement vectors
        if (!cantMove)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
        }


        //Debug
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerDeath.instance.playerHasDied = true;
        }

        //Audio
  



        //Animator Variables control
        if (moveInput.x != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else if (moveInput.x == 0)
        {
            anim.SetBool("isRunning", false);
        }

        if (_rb.velocity.y < 0 || _rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
        }

        //Audio Variables control
        if (IsGrounded() && moveInput.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        //Jump Timer control
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
            
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        
        if(IsGrounded() && !isDashing)
        {
            canDash = true;
        }


       
        
        
        //Jump Timer control
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        //Reduce y velocity if player lets go of jump
        if (isJumpCut)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, (_rb.velocity.y / 2));
           _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Max(_rb.velocity.y, -maxFallSpeed));
            isJumpCut = false;
        }



        //Reduce control in air
        if (!IsGrounded())
        {
            velPower = velPowerAir;
        }
        else
        {
            velPower = velPowerGround;
        }
        
        
        //Jump initialise
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f && !isDashing)
        {
            isJumping = true;
            anim.SetBool("isJumping", true);
            Jump();
        }
        else if  (jumpBufferCounter > 0f && coyoteTimeCounter > 0f && isDashing)
        {
            isJumping = true;
            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;
            dashJump();
        }

        //Dash initialise
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !PauseMenu.isPaused)
        {            
            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;
            isDashing = true;
            canDash = false;
            _tr.emitting = true;
            dashDir = new Vector2(moveInput.x, moveInput.y);
            if (dashDir == Vector2.zero)
            {
                dashDir = new Vector2(transform.localScale.x, 0);
            }
            if (dashDir.x != 0 && !IsGrounded())
            {
                _rb.gravityScale = 0f;
            }
            if (dashDir.y != 0)
            {
                _rb.drag = 6f;
            }

            StartCoroutine(stopDash());
        }
        
        if (isDashing)
        {
            _rb.velocity = dashDir.normalized * dashVelocity;
            return;
        }
        
        
        
        
        
        
        
        
        //Determine if player is jumping
        if (isJumping && _rb.velocity.y < 0)
        {
            isJumping = false;
           
        }

       //Determine if player has let go of jump
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (canJumpCut())
            {
                isJumpCut = true;
            }
                
        }

      


        //Apply friction
        if (IsGrounded() && Mathf.Abs(moveInput.x) < 0.01f)
        {
            float amount = Mathf.Min(Mathf.Abs(_rb.velocity.x), Mathf.Abs(frictionAmount));
            amount *= Mathf.Sign(_rb.velocity.x);
            _rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        }

        //Gravity control

        if (!isDashing)
        {
            if (_rb.velocity.y < 0 && moveInput.y < 0)
            {
                _rb.gravityScale = fastFallGravityValue;
                _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Max(_rb.velocity.y, -maxFastFallSpeed));
            }
            else if (_rb.velocity.y < 0 && !isJumpCut)
            {

                _rb.gravityScale = fallGravityValue;

                _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Max(_rb.velocity.y, -maxFallSpeed));
            }
            else
            {
                _rb.gravityScale = 2f;
            }
        }
        
      





        Flip();

    }
    private void FixedUpdate()
    {
            //Movement left and right
            float targetSpeed = moveInput.x * moveSpeed;
            targetSpeed = Mathf.Lerp(_rb.velocity.x, targetSpeed, 1);
            float speedDif = targetSpeed - _rb.velocity.x;
            float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? runAccelAmount : runDeccelAmount;
            float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
            _rb.AddForce(movement * Vector2.right, ForceMode2D.Force);

    }

    private void Jump()
    {
        //Jump

                _rb.velocity = new Vector2(_rb.velocity.x, 0f);
                _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpBufferCounter = 0f;
                coyoteTimeCounter = 0f;   
    }

    private void dashJump()
    {
        //Jump while dashing
        isDashing = false;
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _rb.velocity = new Vector2(_rb.velocity.x * 2.5f,_rb.velocity.y);
        jumpBufferCounter = 0f;
        coyoteTimeCounter = 0f;
        canDash = true;

    }
    
    
    private IEnumerator stopDash() 
    {
        yield return new WaitForSeconds(dashTime);
        _tr.emitting = false;
        isDashing = false;
       if (_rb.drag != 0)
        {
            StartCoroutine(stopDrag());
        }
       
    }

    private IEnumerator stopDrag()
    {
        yield return new WaitForSeconds(0.2f);
        _rb.drag = 0f;
    }







   
    
    
    
    
    
    private void Flip()
    {
        //Flip direction of player sprite
        if (isFacingRight && moveInput.x < 0f || !isFacingRight && moveInput.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }
    private bool IsGrounded()
    {
        //Check if player is grounded
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.05f, 0.5f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
    


    private bool canJumpCut()
    {
        //Determine if player can cut their jump
        return isJumping && _rb.velocity.y > 0;
    }

    //Kill player if they touch "death" layer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            PlayerDeath.instance.playerHasDied = true;
        }
    }

  
    
    
    public void stopMovement(float t)
    {
        cantMove = true;
        canDash = false;
        moveInput.x = 0;
        moveInput.y = 0;
        StartCoroutine(stopWait(t));
    }

    IEnumerator stopWait(float t)
    {
        yield return new WaitForSeconds(t);
        cantMove = false;
    }



}
