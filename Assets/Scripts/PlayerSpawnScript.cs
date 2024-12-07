using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerSpawnScript : MonoBehaviour {
    
    [SerializeField] private GameObject playerPf;
    private List<int> randomNums = new List<int>();
    private int minValueX = -6;
    private int maxValueX = 6;
    private int increment = 3;
    List<int> possiblePos = new List<int>();            

    private void Start() {
        NewRandomNumbers();

        //use stored numbers
        Vector3 spawnLocation1 = new Vector3(randomNums[0], 1.25f, 4);
        Vector3 spawnLocation2 = new Vector3(randomNums[1], 1.25f, 4);
        Vector3 spawnLocation3 = new Vector3(randomNums[2], 1.25f, 4);
        Vector3 spawnLocation4 = new Vector3(randomNums[3], 1.25f, 4);
        
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

    private void NewRandomNumbers() {
        randomNums.Clear();
        //calculate all posible values
        for(int i = minValueX; i <= maxValueX; i += increment) {
            possiblePos.Add(i);
        }

        //pick 4 random values
        while(randomNums.Count < 4) {
            int newRandomNum = Random.Range(-6, 6);
            
            if(!randomNums.Contains(newRandomNum)) {
                randomNums.Add(newRandomNum);
            }
        }
    }
}