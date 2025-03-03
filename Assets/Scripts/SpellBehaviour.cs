using Unity.VisualScripting;
using UnityEditor.Build.Player;
using UnityEngine;

public class SpellBehaviour : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private string spellType;
    private GameObject spellManager;
    private TypeHandler typeHandler;

    private void Start() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spellManager = GameObject.Find("SpellManager");
        typeHandler = spellManager.GetComponent<TypeHandler>();
        
        typeHandler.ChangeBookType(spellType, spriteRenderer);
    }

    public void SetSpellType(string type) {
        spellType = type;
    }

    public void ReferenceDb(SpellDatabase spellDatabase) {
        spellDatabase.GetTypeFromDb(spellType);
    }  

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            // 'other' gameobject is the player to change's Go die in de trigger loopt van een boekje
            string oldType = other.GetComponent<PlayerTypeBehaviour>().GetPreviousType(); 
            PlayerStatsManager playerStats = other.GetComponent<PlayerStatsManager>();

            SpriteRenderer playerSpriteRenderer = other.GetComponentInChildren<SpriteRenderer>();
            typeHandler.ChangePlayerType(spellType, playerSpriteRenderer, /*other.playerStats,*/ oldType);
            //typeHandler.ChangeBookType(default);
            gameObject.SetActive(false);
        }
    }
}
