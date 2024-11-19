using UnityEngine;

public class movement : MonoBehaviour {

    private float moveSpeed = 5f;
    Vector3 movementvalue;

    [SerializeField] CharacterController cc;


    void Update() {
        movementvalue.x = Input.GetAxisRaw("Horizontal");
        movementvalue.y = 0;
        movementvalue.z = Input.GetAxisRaw("Vertical");
    }
    
    void FixedUpdate() {
        cc.Move(movementvalue * moveSpeed * Time.fixedDeltaTime);
    }

}
