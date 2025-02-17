using Unity.VisualScripting;
using UnityEditor.Build.Player;
using UnityEngine;

public class SpellBehaviour : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private string spellType;
    private SpellDatabase typeDb;
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
        typeDb = spellDatabase;
        typeDb.GetType(spellType);
    }  

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            SpriteRenderer playerSpriteRenderer = other.GetComponentInChildren<SpriteRenderer>();
            typeHandler.ChangePlayerType(spellType, playerSpriteRenderer);
            //typeHandler.ChangeBookType(default);
            gameObject.SetActive(false);
        }
    }
}
