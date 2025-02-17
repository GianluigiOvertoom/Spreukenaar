using UnityEngine;

public class TypeHandler : MonoBehaviour {
    [SerializeField] private SpellDatabase elementDb;

    public void ChangeBookType(string type, SpriteRenderer spriteRendToChange) {
        Debug.Log("type is: " + type);   
        SpellScriptableObject typeSo = elementDb.GetType(type);

        spriteRendToChange.sprite = typeSo.spellSprite;
    }

    public void ChangePlayerType(string type, SpriteRenderer spriteRendToChange) {
        SpellScriptableObject typeSO = elementDb.GetType(type);

        spriteRendToChange.sprite = typeSO.spreukenaarSprite;

        //change player stats health = typeSO.health enz..
    }
}

