using UnityEngine;

public class PlayerTypeBehaviour : MonoBehaviour {
   private SpriteRenderer spriteRenderer;

   private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
   }
}
