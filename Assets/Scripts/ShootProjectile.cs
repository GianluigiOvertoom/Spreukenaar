using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Spawns projectile from player pos
/// </summary>
public class ShootProjectile : MonoBehaviour {

    [SerializeField] private GameObject fireBall;
    [SerializeField] private GameObject wallPrefab;
    private PlayerController pcScript;

    private void Start() {
        pcScript = GetComponent<PlayerController>();
    }

    private void PlayerShoot() {
        //Spawn fireball, asign script
        GameObject fbInstance = Instantiate(fireBall, transform.position, Quaternion.identity);
        fbInstance.GetComponent<FireBall>().pcScript = GetComponent<PlayerController>();
    }
    
    private void CastWall() { 
        if(pcScript.cc.isGrounded) {
            GameObject wallInstance = Instantiate(wallPrefab, transform.position, quaternion.identity);
            wallInstance.GetComponent<WallBehaviour>().pcScript = GetComponent<PlayerController>();
        }        
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)) {
            PlayerShoot();
        }

        if(Input.GetKeyDown(KeyCode.V)) {
            CastWall();
        }
    }
}
