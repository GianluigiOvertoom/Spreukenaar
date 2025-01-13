using Unity.VisualScripting;
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
    private HealthScript healthScript;
    private WallBehaviour wallScript;
    [SerializeField] private LayerMask collisionLayers;
    private float initialHit = 10f;
    private bool isDOT = true;
    private float totalDotDamage = 25f;
    private float amountOfTicks = 5f;
    private float tickInterval = 1f;
    

    private void Start() { 
        //snapshot movedirection 
        moveDir = pcScript.lastMoveDir;

        if(pcScript.lastMoveDir == new Vector3(0,0,0)) {
            moveDir = new Vector3(0,0,-1);
        }   
    }

    private void ProjectileFallOff() {
        if(transform.position.x >= 50 || transform.position.x <= -50 || transform.position.z >= 50 || transform.position.z <= -50) {
            Destroy(gameObject);
        }
    }

    private void TargetChecker() {
        //check for nearby colliders
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, 0.95f, collisionLayers);
        foreach (Collider collider in detectedColliders) {
            if(collider.GetComponent<HealthScript>()) {
                healthScript = collider.GetComponent<HealthScript>();
                healthScript.DotDamage(initialHit, isDOT, totalDotDamage, amountOfTicks, tickInterval);
            }   else if (collider.GetComponentInParent<WallBehaviour>()) {
                wallScript = collider.GetComponentInParent<WallBehaviour>();
                wallScript.WallDamage(fbDamage);
            }

            if(collider.gameObject != pcScript.gameObject) {
                Destroy(gameObject);
                return;
            }
        }
    }

    private void ProjectileMovement() {
        transform.position += moveDir * fbMoveSpeed * Time.deltaTime;
    }

    private void Update() {
        ProjectileMovement();
        ProjectileFallOff();
        TargetChecker();
        Debug.Log(moveDir);
    }
}
