using UnityEngine;

//script voor declaren van variabelen voor het bijpassende element
[CreateAssetMenu(fileName = "SpreukenScriptableObject", menuName = "ScriptableObjects/Spreuk")]
public class SpreukenScriptableObject : ScriptableObject {
    //spreuk variables (damage / dot)
    [field: SerializeField] public float projectileMoveSpeed {get; private set;}
    [field: SerializeField] public float enviornmentDamage {get; private set;}
    [field: SerializeField] public float initialHit {get; private set;}
    [field: SerializeField] public bool isDOT {get; private set;}
    [field: SerializeField] public float totalDotDamage {get; private set;}
    [field: SerializeField] public float amountOfTicks {get; private set;}
    [field: SerializeField] public float tickInterval {get; private set;}
} 
