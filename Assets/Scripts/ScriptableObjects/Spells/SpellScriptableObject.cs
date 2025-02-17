using UnityEngine;

[CreateAssetMenu(fileName = "SpellScriptableObject", menuName = "ScriptableObjects/Spell Sprites")]
public class SpellScriptableObject : ScriptableObject {
    public string type;
    public Sprite spellSprite;
    public Sprite spreukenaarSprite;

    //spreukenaarstats kunnen uit het oude scriptable object gehaald worden

    //spreukstats kunnen uit het oude scriptable object gehaald worden
}

/* 
er zouden 2 scriptable objects moeten zijn, 1 voor het opslaan van data (de gene die je duplicate en steeds vult met andere data... en 1 )

dit scriptable object is de gene waar bijvoorbeeld ook stats in ingevuld kunnen worden om die ook dynamisch mee te laten veranderen door een functie te maken die checkt op type. (dat stukje logica moet dan in een playermanager of iets dergelijks op een player zelf die een string met type mee gezonden krijgt als ie gecalld word.)

*/