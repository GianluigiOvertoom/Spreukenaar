using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerSpawnScript : MonoBehaviour {
    
    [SerializeField] private GameObject playerPf;
    private List<int> Spawnlocations = new List<int>();

    private void Start() {
        RandomAssigner();

        //use stored numbers
        // Vector3 spawnLocation1 = new Vector3(Spawnlocations[0], 1.25f, 4);
        // Vector3 spawnLocation2 = new Vector3(Spawnlocations[1], 1.25f, 4);
        // Vector3 spawnLocation3 = new Vector3(Spawnlocations[2], 1.25f, 4);
        // Vector3 spawnLocation4 = new Vector3(Spawnlocations[3], 1.25f, 4);
        Vector3 spawnLocation1 = new Vector3(-6, 1.25f, 4);
        Vector3 spawnLocation2 = new Vector3(-3, 1.25f, 4);
        Vector3 spawnLocation3 = new Vector3(3, 1.25f, 4);
        Vector3 spawnLocation4 = new Vector3(6, 1.25f, 4);
        
        //instantiate the players at the right location
        GameObject playerInstance1 = Instantiate(playerPf, spawnLocation1, Quaternion.identity);
        GameObject playerInstance2 = Instantiate(playerPf, spawnLocation2, Quaternion.identity);
        GameObject playerInstance3 = Instantiate(playerPf, spawnLocation3, Quaternion.identity);
        GameObject playerInstance4 = Instantiate(playerPf, spawnLocation4, Quaternion.identity);
        
        //give players there number
        playerInstance1.GetComponent<HealthScript>().playerNum = 1;
        playerInstance2.GetComponent<HealthScript>().playerNum = 2;
        playerInstance3.GetComponent<HealthScript>().playerNum = 3;
        playerInstance4.GetComponent<HealthScript>().playerNum = 4;
    }

    private void RandomAssigner() {
        //spread the content of the list randomly throughout the 4 spawnlocations
    }
}