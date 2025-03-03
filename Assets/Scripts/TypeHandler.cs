using UnityEngine;

//TypeHandler class fetches scriptableobjects from SpellDatabase based on type
public class TypeHandler : MonoBehaviour {
    [SerializeField] private SpellDatabase elementDb;

    public void ChangeBookType(string type, SpriteRenderer spriteRendToChange) {
        Debug.Log("type is: " + type);   
        SpellScriptableObject typeSo = elementDb.GetTypeFromDb(type);

        spriteRendToChange.sprite = typeSo.spellSprite;
    }

    public void ChangePlayerType(string type, SpriteRenderer spriteRendToChange, /*PlayerStats playerStats,*/ string oldType) {
        SpellScriptableObject typeSO = elementDb.GetTypeFromDb(type);

        spriteRendToChange.sprite = typeSO.spreukenaarSprite;

        //change player stats health = typeSO.health enz..

        //playerStats.RefreshPlayerStats(type, oldType);
    }
}

