// using Unity.VisualScripting;
// using UnityEngine;

// //alle player besturende scripts (health, movement etc) vanaf hier 'invullen' (adhv variabelen uit de scriptable objects)
// //zo worden alle verschillende types spreukenaars gebaseerd op een spreuk scriptable object. (dus nieuwe spreuk = automatisch gemaakte nieuwe spreukenaar)
// //ook worden alle scripts (health, movement etc) herbruikt inplaatsvan opnieuw aangemaakt en gebruikt.
// public class SpreukenaarController : MonoBehaviour {
//     [field: SerializeField] public SpreukenaarScriptableObject spreukenaarScriptableObject; //{get; private set;}
//     public PlayerController playerController; //{get; private set;}
//     //public HealthScript healthScript; //{get; private set;}
//     //[field: SerializeField] public FireBall fireBall {get; private set;}

//     private void Awake() {
//         //getcomponents (script references)
    
//         if (playerController == null) {
//             Debug.LogError("PlayerController component is missing from this GameObject.");
//             return;
//         }
//     }

//     private void Start() {
//         //variables from SO to respected scripts

//         playerController.moveSpeed = spreukenaarScriptableObject.moveSpeed;
//         playerController.jumpHeight = spreukenaarScriptableObject.jumpHeight;
//         playerController.jumpHeight = spreukenaarScriptableObject.jumpTimeMaxHeight;
//     }
// }
