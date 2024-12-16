using UnityEngine;

/// <summary>
/// Spawns projectile from player pos
/// </summary>
public class ShootProjectile : MonoBehaviour {

    [SerializeField] private GameObject fireBall;

    private void PlayerShoot() {
        if(Input.GetKeyDown(KeyCode.F)) {
            //Spawn fireball, asign script, rotate sprite
            GameObject fbInstance = Instantiate(fireBall, transform.position, Quaternion.identity);
            fbInstance.GetComponent<FireBall>().pcScript = GetComponent<PlayerController>();
        }
    }
    
    private void Update() {
        PlayerShoot();
    }
}
