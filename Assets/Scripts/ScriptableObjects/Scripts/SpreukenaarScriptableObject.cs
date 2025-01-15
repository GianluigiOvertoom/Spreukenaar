using UnityEngine;

[CreateAssetMenu(fileName = "SpreukenaarScriptableObject", menuName = "ScriptableObjects/Spreukenaar")]
//algemene character details die adhv type (moet gaan) weet wat de hp movespeed enz van de spreukenaar is.
//
//spreukenaar adhv type laten switchen of de gehele scriptable object uitswitchen? en dan hier de character stats uitwerken en in het spreuk SO puur de dmg en attacks enz...?
//
public class SpreukenaarScriptableObject : ScriptableObject {
    //spreuk scriptable object reference
    [field: SerializeField] public SpreukenScriptableObject spreuken;

    //spreukenaar type
    [field: SerializeField] public string type {get; private set;}
    
    //player stats
    [field: SerializeField] public float playerHealth {get; private set;}
    [field: SerializeField] public float moveSpeed {get; private set;}
    [field: SerializeField] public float jumpHeight {get; private set;} 
    [field: SerializeField] public float jumpTimeMaxHeight {get; private set;}
    
    //spreuk dmg
    public float fbMoveSpeed {get; private set;}
    public float enviornmentDamage {get; private set;}
    public float initialHit {get; private set;}
    public bool isDOT {get; private set;}
    public float totalDotDamage {get; private set;}
    public float amountOfTicks {get; private set;}
    public float tickInterval {get; private set;}

    private void OnEnable() {
        fbMoveSpeed = spreuken.fbMoveSpeed;
        enviornmentDamage = spreuken.enviornmentDamage;
        initialHit = spreuken.initialHit;
        isDOT = spreuken.isDOT;
        totalDotDamage = spreuken.totalDotDamage;
        amountOfTicks = spreuken.amountOfTicks;
        tickInterval = spreuken.tickInterval;
    }
}
