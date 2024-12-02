using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour {

    private float moveSpeed = 5f;
    Vector3 movementValue;

    [SerializeField] CharacterController cc;

    private void Walk() {
        //keypresses registreren en op vector zetten
        movementValue.x = Input.GetAxisRaw("Horizontal");
        movementValue.z = Input.GetAxisRaw("Vertical");
        movementValue.y = 0;
    }

    private void Run() {
        if(Input.GetKey(KeyCode.LeftShift) == true) {
            moveSpeed = 8f;
        } else {
            moveSpeed = 5f;
        }
    }

    void Update() {
        Walk();
        Run();
    }
    
    void FixedUpdate() {
        //apply movement
        cc.Move(movementValue * moveSpeed * Time.fixedDeltaTime);
    }
}
