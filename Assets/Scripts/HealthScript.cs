using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.U2D.IK;
using UnityEngine.UI;

/// <summary>
/// Health system
/// </summary>
public class HealthScript : MonoBehaviour {
    
    public float playerHealth {private set; get;}
    private CharacterController cc;
    private GameObject canvas;
    public int playerNum;
    private TextMeshProUGUI healthDisplay; 
    [field: SerializeField] public SpreukenaarScriptableObject spreukenaarScriptableObject {get; private set;}


    private void Start() {
        
        playerHealth = 0;
        cc = GetComponent<CharacterController>();
        canvas = GameObject.Find("Canvas");
        healthDisplay = canvas.transform.GetChild(playerNum - 1).GetComponent<TextMeshProUGUI>();  
    }
    
    public void DotDamage(float initialHit, bool isDOT, float totalDotDamage, float amountOfTicks, float tickInterval) {
        playerHealth += initialHit;
        StartCoroutine(ActivateDot(isDOT, totalDotDamage, amountOfTicks, tickInterval));
    }

    private IEnumerator ActivateDot(bool isDOT, float totalDotDamage, float amountOfTicks, float tickInterval) {
        float tickDamage = totalDotDamage / amountOfTicks;
            if(isDOT == true) {
                for(int i = 0; i < amountOfTicks; i++) {
                yield return new WaitForSeconds(tickInterval);
                playerHealth += tickDamage;
            }
        }
    }

    private void DisplayHealth() {
        if(playerNum > -1) {
            healthDisplay.text = "Target " + playerNum + " : " + playerHealth + " %";        
        }
    }
    
    private void Update() {
        DisplayHealth(); 
    }
}
