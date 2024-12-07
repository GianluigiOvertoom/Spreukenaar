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
    
    public float PlayerHealth;
    private CharacterController cc;
    private SpriteRenderer spRend;
    private GameObject canvas;
    public int playerNum;
    private TextMeshProUGUI healthDisplay;


    private void Start() {
        PlayerHealth = 100f;
        cc = GetComponent<CharacterController>();
        spRend = GetComponentInChildren<SpriteRenderer>();
        canvas = GameObject.Find("Canvas");
        healthDisplay = canvas.transform.GetChild(playerNum - 1).GetComponent<TextMeshProUGUI>();  
    }

    public void DealDamage(float amountOfDamage) {
        PlayerHealth -= amountOfDamage;
    }

    private void DeathCheck() {
        if(PlayerHealth <= 0) {
            PlayerHealth = 0;
            //disable character controller/ (collision)
            cc.enabled = false;
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
