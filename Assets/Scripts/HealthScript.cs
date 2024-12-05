using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.UI;

/// <summary>
/// Health system
/// </summary>
public class HealthScript : MonoBehaviour {
    
    private float PlayerHealth;
    private CharacterController cc;
    private SpriteRenderer spRend;
    [SerializeField] private TextMeshProUGUI healthDisplay;
    public int playerNum;


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
            PlayerHealth = 0;
            //destroy all components that arnt allowed to work
            //ik wil hier het target script destroyen dat op dit object staat, niet ook de rest van de targetscripts (note: .enabled false is niet genoeg, dan kan ie hem toch nog vinden als target... (transform.pos veranderen als target 'dood gaat?'))
            // Destroy(GetComponentInParent<TargetScript>());
            GetComponent<CharacterController>().enabled = false;
            //fade out
            spRend.color = spRend.color - new Color(0,0,0,0.5f) * Time.deltaTime;
            if(spRend.color.a <= 0) {
                GetComponent<HealthScript>().enabled = false;
                gameObject.SetActive(false);
            }
        }
    }

    private void DisplayHealth() {
        healthDisplay.text = "Target " + playerNum + ":" + PlayerHealth + "HP";
    }

    private void Update() {
        DeathCheck();
        DisplayHealth();
    }
}
