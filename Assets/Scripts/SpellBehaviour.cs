using UnityEngine;

public class SpellBehaviour : MonoBehaviour {
   
   
    private void Descend() { 
        //gameObject.transform.position -= new Vector3(0, 1f * Time.deltaTime, 0);
    }

    private void Update() {
        Descend();
    }
}
