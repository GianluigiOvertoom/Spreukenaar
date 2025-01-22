using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerSpawnScript : MonoBehaviour {
    
    [SerializeField] private GameObject vuurSpreukenaar;
    [SerializeField] private GameObject waterSpreukenaar;
    [SerializeField] private GameObject earthSpreukenaar;
    [SerializeField] private GameObject windSpreukenaar;

    private void Start() {
        Vector3[] spawnLocations = {
            new Vector3(-6, 1.25f, 4),
            new Vector3(-3, 1.25f, 4),
            new Vector3(3, 1.25f, 4),
            new Vector3(6, 1.25f, 4)
        };

        //instantiate players on the right location
        GameObject[] players = {
            Instantiate(vuurSpreukenaar, spawnLocations[0], Quaternion.identity),
            Instantiate(waterSpreukenaar, spawnLocations[1], Quaternion.identity),
            Instantiate(earthSpreukenaar, spawnLocations[2], Quaternion.identity),
            Instantiate(windSpreukenaar, spawnLocations[3], Quaternion.identity)
        };

        //give players there number
        for(int i = 0; i < players.Length; i++) {
            var healthScript = players[i].GetComponent<HealthScript>();
            healthScript.playerNum = i + 1;
        }
    }
}