using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PlayerController
{
    public float moveSpeed = 7f;
    
    Vector2 moveInput, playerVelocity;
    
    public override void FixedUpdate()
    {
        playerVelocity = (moveInput.normalized * moveSpeed);
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, playerVelocity, moveSpeed * Time.fixedDeltaTime); 
    }
    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);;
    }

}
