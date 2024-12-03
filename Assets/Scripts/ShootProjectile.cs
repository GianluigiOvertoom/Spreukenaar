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
            fbInstance.GetComponentInChildren<Transform>().localRotation = new Quaternion(35f,0,0,0);
        }
    }

    //receive movementvalue (x,z --> move direction)
    
    private void Update() {
        PlayerShoot();
    }
}
