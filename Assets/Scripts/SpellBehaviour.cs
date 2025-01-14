using Unity.VisualScripting;
using UnityEngine;

public class SpellBehaviour : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            gameObject.SetActive(false);
            Debug.Log("Spell taken");
            // als we met een scriptable object als spreukenaar gaan werken kan hier het type spreukenaar worden doorgegeven wat dan weer in een ander script de variabelen in het 
            // scriptable object aanpassen zodat de sprite en de variabelen automatisch ingevuld kunnen worden
            // (dus if (spreukenaarType = fire) spreukanaar stats (hp sprite jumpheight enz... al vooraf ingevuld en gebalanced inbvullen))
            //      Dan ook gelijk de verschillende attacks toekennen en niet de variabelen los doorgeven maar dat in een al gemaakt scriptable object (voor alle spells) gooien.
        }
    }
}
