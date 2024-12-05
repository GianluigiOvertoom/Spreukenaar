// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UIElements;

// public class TargetScript : MonoBehaviour {
    
//     private static List<TargetScript> targetList;

//     public static TargetScript GetClosest(Vector3 position, float maxRange) {
//         TargetScript closest = null;
//         foreach(TargetScript target in targetList) {
//             if(Vector3.Distance(position, target.GetPosition()) <= maxRange) {
//                 if(closest == null) {
//                     closest = target;
//                 } else {
//                     if(Vector3.Distance(position, target.GetPosition()) < Vector3.Distance(position, closest.GetPosition())) {
//                         closest = target;
//                     }
//                 }
//             }
//         }
//         return closest;
//     }

//     private void Awake() {
//         if(targetList == null) targetList = new List<TargetScript>(); {
//             targetList.Add(this);
//         }
//     }    
    
//     public Vector3 GetPosition() {
//         return transform.position;
//    }
// }


///////vervangen door het nieuwe overlap sphere stukje in fireball script.