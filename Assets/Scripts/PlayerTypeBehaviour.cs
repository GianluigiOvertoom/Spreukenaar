using UnityEngine;

//PlayerTypeBehaviour keeps track of players active and previous type
public class PlayerTypeBehaviour : MonoBehaviour {
   private string type;
   private string previousType;

   private void Start() {
      type = "default";
      previousType = "default";
   }

   public void ChangePlayerType(string newType) {
      previousType = type;
      type = newType;
   }

   public string GetPreviousType() {
      return previousType;
   }
}
