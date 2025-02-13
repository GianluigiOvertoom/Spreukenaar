using System;
using UnityEngine;

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
        GenerateRandomSpell();
    }

    private enum Element {
        Vuur, 
        Water, 
        Aarde, 
        Wind
    }

    private Element spreukenaarType;

    private void GenerateRandomSpell() {
        // pick random value from enum spreukenaarType
        /*  1. Kijk naar de length van de enum v
            2. Pak deze length en zet deze als maxSpreukenaarType v
            3. Kies random getallen tussen 0 en maxSpreukenaarType v
            4. Gebruik je randomized getal, dat getal als var toString en switchcase dat....*/
        
        
        // enumLength = Enum.GetValues(typeof(SpreukenaarType));

        //define start of enum count
        int enumLength = 0;

        foreach(Element spreukenaarType in Enum.GetValues(typeof(Element))) {
            enumLength++;
        }

        int maxSpreukenaarType = enumLength;

        //generate random int between 0 and enumlength
        int randomEnumInt = UnityEngine.Random.Range(0, maxSpreukenaarType - 1);
        
        string randomEnumIntString = randomEnumInt.ToString();
        

        Debug.Log("SpreukenaarTypeInt = " + randomEnumInt + " bijbehorende enum string = " + Enum.Parse<Element>(randomEnumIntString));
    }

    //Deze functie moet eigenlijk (ook) in een spreukenaarStateManager script ofzo...
    private void HandleState() {
        switch (spreukenaarType) {
            case Element.Vuur:
                // switch spreukenaar logic
                break;
            case Element.Water:
                // switch spreukenaar logic
                break;
            case Element.Aarde:
                // switch spreukenaar logic
                break;
            case Element.Wind:
                // switch spreukenaar logic
                break;
        }
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
        Instantiate(spell, randomPosition, Quaternion.identity);
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
