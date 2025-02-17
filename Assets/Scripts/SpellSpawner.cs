using System;
using UnityEngine;

public class SpellSpawner : MonoBehaviour {
    //reference spell prefab
    [SerializeField] private SpellDatabase elementDb;
    [SerializeField] private GameObject defaultSpellPf;
    private float spellSpawnIntervall = 5f;
    private int spellCount;
    private int maxSpellAmount = 10;
    private Vector3 minPos;
    private Vector3 maxPos;
    private Vector3 randomPosition;
    private bool randomPosReset = true;

    private enum Element {
        Vuur, 
        Water, 
        Aarde, 
        Wind
    }

    private Element spreukenaarType;

    private void GenerateRandomSpell() {
        int enumLength = 0;

        foreach(Element spreukenaarType in Enum.GetValues(typeof(Element))) {
            enumLength++;
        }

        int spreukenaarTypeAmount = enumLength;
        
        int randomEnumInt = UnityEngine.Random.Range(0, spreukenaarTypeAmount);
        spreukenaarType = (Element)randomEnumInt;
    }

    private void Timer() {
        if(spellSpawnIntervall > 0) {
            spellSpawnIntervall -= Time.deltaTime;
        }
    }

    private void RandomPositionGenerator() {
        minPos = new Vector3(-6,5,1);
        maxPos = new Vector3(6,5,7);

        if(randomPosReset == true) {
            randomPosition = new Vector3(
            UnityEngine.Random.Range(minPos.x, maxPos.x),
            UnityEngine.Random.Range(minPos.y, maxPos.y),
            UnityEngine.Random.Range(minPos.z, maxPos.z)
            );
            
            randomPosReset = false;
        }
    }

    private void SpawnSpell() {
        randomPosReset = true;
        
        GenerateRandomSpell();

        GameObject newSpell = Instantiate(defaultSpellPf, randomPosition, Quaternion.identity);
        SpellBehaviour spellBehaviour = newSpell.GetComponent<SpellBehaviour>();
        spellBehaviour.SetSpellType(spreukenaarType.ToString());
        spellBehaviour.ReferenceDb(elementDb);
        spellCount += 1;
    }

    private void SpellCheck() {
        if(spellCount == maxSpellAmount) {
            spellSpawnIntervall = UnityEngine.Random.Range(5,10);
        }
    }

    private void TimeCheck() { 
        if(spellSpawnIntervall <= 0) {
            SpawnSpell();
            spellSpawnIntervall = UnityEngine.Random.Range(5,10);
        }
    }

    private void Update() {
        Timer();
        RandomPositionGenerator();
        TimeCheck();
        SpellCheck();
    }
}
