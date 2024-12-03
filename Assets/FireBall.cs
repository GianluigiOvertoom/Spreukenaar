using UnityEngine;

/// <summary>
/// Fireball Behaviour
/// </summary>
public class FireBall : MonoBehaviour {

    private float fbMoveSpeed = 15f;
    private float fbDestroySpeed = 0.85f;
    private Vector3 moveDir;
    public PlayerController pcScript;

    private void Start() { ;
        if (pcScript.movementValue.x != 0) {
            moveDir = new Vector3(Mathf.Sign(pcScript.movementValue.x), 0, pcScript.movementValue.z);
        } else {
            float faceingDir = pcScript.transform.localScale.x > 0 ? 1 : -1;
            moveDir = Vector3.right * faceingDir;
        }
        moveDir = moveDir.normalized;
    }

    private void ProjectileFallOff() {
        transform.localScale -= new Vector3(1,1,1) * fbDestroySpeed * Time.deltaTime;
        
        if(transform.localScale.x <= 0) {
            Destroy(gameObject);
        }
    }

    private void ProjectileMovement() {
        transform.position += moveDir * fbMoveSpeed * Time.deltaTime;
    }

    private void Update() {
        ProjectileMovement();
        ProjectileFallOff();
    }
}
