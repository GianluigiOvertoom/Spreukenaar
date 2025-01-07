using Unity.VisualScripting;
using UnityEngine;

public class SpellBehaviour : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            gameObject.SetActive(false);
            Debug.Log("Spell taken");
        }
    }
}
