using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SpellSpawner : MonoBehaviour {
    //reference spell prefab
    [SerializeField] private GameObject spell;
    private float spellSpawnIntervall = 5f;
    private int spellCount;
    private int maxSpellAmount = 10;
    private Vector3 minPos;
    private Vector3 maxPos;
    private Vector3 randomPosition;
    private bool randomPosReset = true;

    private void Start() {
        minPos = new Vector3(-6,5,1);
        maxPos = new Vector3(6,5,7);
    }

    private void Timer() {
        if(spellSpawnIntervall > 0) {
            spellSpawnIntervall -= Time.deltaTime;
        }
    }

    private void RandomPositionGenerator() {
        if(randomPosReset == true) {
            randomPosition = new Vector3(
            Random.Range(minPos.x, maxPos.x),
            Random.Range(minPos.y, maxPos.y),
            Random.Range(minPos.z, maxPos.z)
            );
            
            randomPosReset = false;
        }
    }

    private void SpawnSpell() {
        randomPosReset = true;
        GameObject spellInstantiate = Instantiate(spell, randomPosition, Quaternion.identity);
        spellCount += 1;
    }

    private void SpellCheck() {
        if(spellCount == maxSpellAmount) {
            spellSpawnIntervall = Random.Range(5,10);
        }
    }

    private void TimeCheck() { 
        if(spellSpawnIntervall <= 0) {
            SpawnSpell();
            spellSpawnIntervall = Random.Range(5,10);
        }
    }

    private void Update() {
        Timer();
        RandomPositionGenerator();
        TimeCheck();
        SpellCheck();
    }
}
