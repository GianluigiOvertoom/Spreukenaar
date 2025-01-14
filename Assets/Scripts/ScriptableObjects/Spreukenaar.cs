using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEditor.VersionControl;
using UnityEngine;

[CreateAssetMenu(fileName = "Spreukenaar", menuName = "Spreukenaars")]
public class Spreukenaar : ScriptableObject {
    //sprites
    [SerializeField] private Sprite spreukenaarSprite;

    //variables
    [SerializeField] private new string name;
    [SerializeField] private string type;
    [SerializeField] private float playerHealth;
    [SerializeField] private float playerNum; 
}
