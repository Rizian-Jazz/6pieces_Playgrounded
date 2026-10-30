using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PlayerController
{
    public float moveSpeed = 7f;
    public bool isFlipped = false;
    
    Vector2 moveInput, playerVelocity;
    
    public override void FixedUpdate()
    {
        playerVelocity = moveInput.normalized * moveSpeed;
        Move();
    }
    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Move()
    {
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, playerVelocity, moveSpeed * Time.fixedDeltaTime);
        if (moveInput.x < 0 && !isFlipped)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                isFlipped = true;
            }
            else if (moveInput.x > 0 && isFlipped)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                isFlipped = false;
            }
    }

}
