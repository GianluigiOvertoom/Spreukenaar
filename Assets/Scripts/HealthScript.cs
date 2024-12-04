using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;

/// <summary>
/// Health system
/// </summary>
public class HealthScript : MonoBehaviour {
    
    private float PlayerHealth;
    private CharacterController cc;
    private SpriteRenderer spRend;


    private void Start() {
        cc = GetComponent<CharacterController>();
        spRend = GetComponentInChildren<SpriteRenderer>();
        PlayerHealth = 100f;
    }

    public void DealDamage(float amountOfDamage) {
        PlayerHealth -= amountOfDamage;
    }

    private void DeathCheck() {
        if(PlayerHealth <= 0) {
            //destroy all components that arnt allowed to work
            Destroy(GetComponent<TargetScript>());
            Destroy(GetComponent<PlayerController>());
            Destroy(GetComponent<CharacterController>());
            //fade out
            spRend.color = spRend.color - new Color(0,0,0,0.5f) * Time.deltaTime;
            if(spRend.color.a <= 0) {
                Destroy(gameObject);
            }
        }
    }

    private void Update() {
        DeathCheck();
        Debug.Log("Player Health: " + PlayerHealth + " HP");
    }
}