using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// Fireball Behaviour
/// </summary>
public class FireBall : MonoBehaviour {

    private float fbMoveSpeed = 15f;
    private float fbDamage = 10f;
    private Vector3 moveDir;
    public PlayerController pcScript;
    private float hitDetectionSize = 1f;
    private HealthScript healthScript;

    private void Start() { 
        if (pcScript.movementValue.x != 0) {
            moveDir = new Vector3(Mathf.Sign(pcScript.movementValue.x), 0, pcScript.movementValue.z);
        } else {
            float faceingDir = pcScript.transform.localScale.x > 0 ? 1 : -1;
            moveDir = -Vector3.forward * faceingDir;
            if (pcScript.movementValue.z > 0) {
                moveDir = Vector3.forward;
            }
        }
        moveDir = moveDir.normalized;
    }

    private void ProjectileFallOff() {
        if(transform.position.x >= 50 || transform.position.x <= -50 || transform.position.z >= 50 || transform.position.z <= -50) {
            Destroy(gameObject);
        }
    }

    private void TargetCheckerNew() {
        //check for nearby colliders
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, 0.95f);
        foreach (Collider collider in detectedColliders) {
            if(collider.GetComponent<HealthScript>()) {
                healthScript = collider.GetComponent<HealthScript>();
                healthScript.DealDamage(fbDamage);
                if(healthScript.PlayerHealth > 0) {
                    //destroy for now, store and re-use later
                    Destroy(gameObject);
                }
            }
        }
    }

    private void ProjectileMovement() {
        transform.position += moveDir * fbMoveSpeed * Time.deltaTime;
    }

    private void Update() {
        ProjectileMovement();
        ProjectileFallOff();
        TargetCheckerNew();
    }
}
