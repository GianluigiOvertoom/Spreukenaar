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
    private bool damageDealt = false;

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
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider collider in detectedColliders) {
            if(collider.GetComponent<HealthScript>() && damageDealt == false) {
                healthScript = collider.GetComponent<HealthScript>();
                healthScript.DealDamage(fbDamage);
                damageDealt = true;
                //destroy for now, 'turn off' later
                Destroy(gameObject);
            }
        }
    }

    private void ProjectileMovement() {
        transform.position += moveDir * fbMoveSpeed * Time.deltaTime;
    }

    private void TargetChecker() {
        //check for any nearby targets
        // TargetScript target = TargetScript.GetClosest(transform.position, hitDetectionSize);

        //if target detected, get the healthscript on them and damage them appropriately
        // if(target !=null) {
        //     HealthScript targetHealth = target.GetComponent<HealthScript>();
        //     targetHealth.DealDamage(fbDamage);
        //     Destroy(gameObject);
        //     Debug.Log("Hit");
        // } else {
        //     Debug.Log(">.< Mis poes appelmoes >.<");
        // }
    }

    private void Update() {
        ProjectileMovement();
        ProjectileFallOff();   
        TargetChecker();
        TargetCheckerNew();
    }
}
