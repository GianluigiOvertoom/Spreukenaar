using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Spawns projectile from player pos
/// </summary>
public class ShootProjectile : MonoBehaviour {

    [SerializeField] private GameObject SpellPrefab;
    private PlayerController pcScript;

    private void Start() {
        pcScript = GetComponent<PlayerController>();
    }

    private void CastSpell() {
        //Spawn projectile, enviornment, effect...
        GameObject projectileInstance = Instantiate(SpellPrefab, transform.position, Quaternion.identity);
        projectileInstance.GetComponent<ProjectileBehaviour>().pcScript = GetComponent<PlayerController>();
    }      

    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)) {
            CastSpell();
        }
    }
}
