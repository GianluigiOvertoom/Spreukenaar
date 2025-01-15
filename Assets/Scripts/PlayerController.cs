using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// Movement class
/// </summary>
public class PlayerController : MonoBehaviour {

    public float moveSpeed {private get; set;}
    public float jumpHeight {private get; set;}
    //time it takes to reach max height (or 0 velocity)
    public float jumpTimeMaxHeight {private get; set;}
    private float gravity;
    private float jumpVelocity;
    private Vector3 startPos;
    //save inputs in vector3
    public Vector3 movementValue;
    private Vector2 xzValue;
    private float jumpValue;
    public CharacterController cc {get; private set;}
    public Vector3 lastMoveDir;
    [field: SerializeField] public SpreukenaarScriptableObject spreukenaarScriptableObject; //{get; private set;}


    private void Awake() {
        moveSpeed = spreukenaarScriptableObject.moveSpeed;
        jumpHeight = spreukenaarScriptableObject.jumpHeight;
        jumpTimeMaxHeight = spreukenaarScriptableObject.jumpTimeMaxHeight;
    }

    private void Start() {
        cc = GetComponent<CharacterController>();

        startPos = gameObject.transform.position;
        gravity = -(2 * jumpHeight) / Mathf.Pow (jumpTimeMaxHeight, 2);
        jumpVelocity = Mathf.Abs(gravity) * jumpTimeMaxHeight;        
    }

    private void Walk() {
        xzValue.x = Input.GetAxisRaw("Horizontal");
        xzValue.y = Input.GetAxisRaw("Vertical");
        xzValue = new Vector2(xzValue.x, xzValue.y).normalized;

        if(xzValue != Vector2.zero) {
            lastMoveDir = new Vector3(xzValue.x, 0, xzValue.y);
        } 

        if(lastMoveDir == null) {
            lastMoveDir = new Vector3(0,-1);
        }
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
            jumpValue = jumpVelocity;
        }
    }

    private void ApplyGravity() {
        jumpValue += gravity * Time.deltaTime;

        //limiting gravity strength
        if(jumpValue < -20) {
            jumpValue = -20;
        }
    }

    //respawn character when falling for now, later on, kill character instead
    private void RespawnCharacter() {
        if (transform.position.y <= -25f) {
            transform.position = startPos;            
        }
    }

    private void Update() {
        Jump();
    }
    
    private void FixedUpdate() {
        Walk();
        Run();

        //apply movement to cc
        movementValue = new Vector3(xzValue.x * moveSpeed, jumpValue, xzValue.y * moveSpeed);
        cc.Move(movementValue * Time.deltaTime);
        
        ApplyGravity();
        RespawnCharacter();
    }
}
