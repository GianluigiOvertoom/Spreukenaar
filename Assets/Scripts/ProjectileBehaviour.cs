using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {
    private float knockbackMultiplier;
    private float projectileMoveSpeed;
    private float enviornmentDamage;
    private float initialHit;
    private bool isDOT;
    private float totalDotDamage;
    private float amountOfTicks;
    private float tickInterval;
    private Vector3 moveDir;
    public PlayerController pcScript {private get; set;}
    private HealthScript healthScript;
    private WallBehaviour wallScript;
    [SerializeField] private LayerMask collisionLayers;    
    [field: SerializeField] public SpreukenaarScriptableObject spreukenaarScriptableObject {get; private set;}

    private void Start() { 
        knockbackMultiplier = spreukenaarScriptableObject.knockbackMultiplier;
        projectileMoveSpeed = spreukenaarScriptableObject.projectileMoveSpeed;
        enviornmentDamage = spreukenaarScriptableObject.enviornmentDamage;
        initialHit = spreukenaarScriptableObject.initialHit;
        isDOT = spreukenaarScriptableObject.isDOT;
        totalDotDamage = spreukenaarScriptableObject.totalDotDamage;
        amountOfTicks = spreukenaarScriptableObject.amountOfTicks;
        tickInterval = spreukenaarScriptableObject.tickInterval;
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
                collider.GetComponent<PlayerController>().Knockback(new Vector2(moveDir.x * knockbackMultiplier, moveDir.z * knockbackMultiplier));
            }   else if (collider.GetComponentInParent<WallBehaviour>()) {
                wallScript = collider.GetComponentInParent<WallBehaviour>();
                wallScript.WallDamage(enviornmentDamage);
            }

            if(collider.gameObject != pcScript.gameObject) {
                Destroy(gameObject);
                return;
            }
        }
    }

    private void ProjectileMovement() {
        transform.position += moveDir * projectileMoveSpeed * Time.deltaTime;
    }

    private void Update() {
        ProjectileMovement();
        ProjectileFallOff();
        TargetChecker();
    }
}
