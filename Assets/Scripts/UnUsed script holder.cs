using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnUsedscriptholder : MonoBehaviour
{

    //Wall jump variables
   // [SerializeField] private LayerMask wallLayer;
  //  [SerializeField] private Transform wallCheck;
  //  private float wallJumpTime = 0.2f;
  //  private float wallJumpCounter;
  //  private float wallJumpDuration = 0.2f;
  //  private Vector2 wallJumpPower = new Vector2(12f, 18f);
   // private bool isWallSliding;
   // private bool isWallJumping;
  //  private float wallJumpDirection;







   // private void wallJump()
  //  {
        //Wall jump
    //    if (isWallSliding)
    //    {
    //        isWallJumping = false;
    //        wallJumpDirection = -transform.localScale.x;
     //       wallJumpCounter = wallJumpTime;

           // CancelInvoke(nameof(stopWallJump));
      //  }
      //  else
      //  {
      //      wallJumpCounter -= Time.deltaTime;
      //  }

      //  if (Input.GetButtonDown("Jump") && wallJumpCounter > 0f)
      //  {
      //      isWallJumping = true;
            //_rb.velocity = new Vector2(wallJumpDirection * wallJumpPower.x, wallJumpPower.y);
      //      wallJumpCounter = 0f;

       //     if (transform.localScale.x != wallJumpDirection)
       //     {
           //     isFacingRight = !isFacingRight;
        //        Vector3 localScale = transform.localScale;
      //          localScale.x *= -1f;
       //         transform.localScale = localScale;
//
        //    }

            //Invoke(nameof(stopWallJump), wallJumpDuration);
       // }
  //  }
   // private void stopWallJump()
   // {
    //    isWallJumping = false;
   // }
  //  private bool IsOnWall()
  //  {
        //Check if player is on wall
   //     return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
  //  }
  //  private void wallSlide()
  //  {
  //      float wallSlideSpeed = 1f;
    //    if (IsOnWall() && !IsGrounded() && moveInput.x != 0f)
   //     {
   //         isWallSliding = true;
    //        _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y, -wallSlideSpeed, float.MaxValue));

  //      }
   //     else
    //    {
    //        isWallSliding = false;
    //    }
  //  }



}
