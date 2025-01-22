using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Spawns projectile from player pos
/// </summary>
public class ShootProjectile : MonoBehaviour {

    [SerializeField] private GameObject SpellPrefab;
    private PlayerController pcScript;
    [SerializeField] private SpreukenaarScriptableObject spreukenaarScriptableObject;

    private void Start() {
        pcScript = GetComponent<PlayerController>();
    }

    private void CastSpell() {
        if(spreukenaarScriptableObject.type == "Earth") {
            GameObject projectileInstance = Instantiate(SpellPrefab, transform.position, quaternion.identity);
            projectileInstance.GetComponent<WallBehaviour>().pcScript = pcScript;
            projectileInstance.GetComponent<ProjectileBehaviour>().pcScript = pcScript;
        } else {
            GameObject projectileInstance = Instantiate(SpellPrefab, transform.position, Quaternion.identity);
            projectileInstance.GetComponent<ProjectileBehaviour>().pcScript = pcScript;
        }
    }      

    private void Update() {
        if(Input.GetKeyDown(KeyCode.F) && !pcScript.isDebug) {
            CastSpell();
        }
    }
}
