using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Editor;
using UnityEngine.UIElements;

/// <summary>
/// Class voor movement van character.
/// </summary>
public class Movement : MonoBehaviour {

    private float moveSpeed = 5f;
    private float jumpHeight = 1;
    //time it takes to reach max height (or 0 velocity)
    private float jumpTimeMaxHeight = 0.3f;
    private float gravity;
    private float jumpVelocity;
    private Vector3 startPos;
    //movement values opgeslagen in vector3
    private Vector3 movementValue;
    private CharacterController cc;


    private void Start() {
        cc = GetComponent<CharacterController>();

        startPos = gameObject.transform.position;
        gravity = -(2 * jumpHeight) / Mathf.Pow (jumpTimeMaxHeight, 2);
        jumpVelocity = Mathf.Abs(gravity) * jumpTimeMaxHeight;
    }

    private void Walk() {
        movementValue.x = Input.GetAxisRaw("Horizontal");
        movementValue.z = Input.GetAxisRaw("Vertical");
    }

    private void Run() {
        if(Input.GetKey(KeyCode.LeftShift) == true) {
            moveSpeed = 8f;
        } else {
            moveSpeed = 5f;
        }
    }

    private void Jump() {
        if(cc.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            movementValue.y = jumpVelocity;
        }
    }

    private void ApplyGravity() {
        movementValue.y += gravity * Time.deltaTime;

        //gravity niet te snel laten gaan door het te limiteren
        if(movementValue.y < -5) {
            movementValue.y = -5;
        }
    }

    private void Update() {
        Jump();
    }
    
    private void FixedUpdate() {
        Walk();
        Run();

        //movement apply'en
        cc.Move(movementValue * moveSpeed * Time.fixedDeltaTime);
        ApplyGravity();
        if (gameObject.transform.position.y <= -25f) {
            transform.position = startPos;            
        }
    }
}
