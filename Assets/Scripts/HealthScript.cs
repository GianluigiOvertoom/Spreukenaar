using System;
using System.Collections;
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
    
    public float playerHealth;
    private CharacterController cc;
    private SpriteRenderer spRend;
    private GameObject canvas;
    public int playerNum;
    private TextMeshProUGUI healthDisplay; 


    private void Start() {
        playerHealth = 1000f;
        cc = GetComponent<CharacterController>();
        spRend = GetComponentInChildren<SpriteRenderer>();
        canvas = GameObject.Find("Canvas");
        healthDisplay = canvas.transform.GetChild(playerNum - 1).GetComponent<TextMeshProUGUI>();  
    }
    
    public void DotDamage(float initialHit, bool isDOT, float totalDotDamage, float amountOfTicks, float tickInterval) {
        playerHealth -= initialHit;
        StartCoroutine(ActivateDot(isDOT, totalDotDamage, amountOfTicks, tickInterval));
    }

    private IEnumerator ActivateDot(bool isDOT, float totalDotDamage, float amountOfTicks, float tickInterval) {
        float tickDamage = totalDotDamage / amountOfTicks;
            if(isDOT == true) {
                for(int i = 0; i < amountOfTicks; i++) {
                yield return new WaitForSeconds(tickInterval);
                playerHealth -= tickDamage;
            }
        }
    }


    private void DeathCheck() {
        if(playerHealth <= 0) {
            playerHealth = 0;
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
        healthDisplay.text = "Target " + playerNum + " : " + playerHealth + " HP";        
    }

    private void Update() {
        DeathCheck();
        DisplayHealth();
    }
}
