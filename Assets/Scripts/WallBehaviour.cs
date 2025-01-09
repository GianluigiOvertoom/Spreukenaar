using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class WallBehaviour : MonoBehaviour {
    public PlayerController pcScript;
    private float wallStartHeight;
    private float growHeight = 2.495f;
    private Vector3 movementValue;
    private Vector3 wallOfset;
    private float ofsetDistance = 3;
    private float wallHealth;

    private void Awake() {
        pcScript = GetComponent<PlayerController>();
    }

    private void Start() {
        wallStartHeight = transform.position.y;
        movementValue = pcScript.movementValue;
        WallDirection();
        wallHealth = 50;
    }

    private void WallDirection() {
        if(movementValue == new Vector3(0,-20,0)) {
            wallOfset = pcScript.lastMoveDir;
             //last move direction uit playercontroller pakken
        }

        if(pcScript.lastMoveDir.x > 0) {
            //right
            wallOfset.x = ofsetDistance;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        } else if(pcScript.lastMoveDir.x < 0) {
            wallOfset.x = -ofsetDistance;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        if(pcScript.lastMoveDir.z > 0) {
            wallOfset.z = ofsetDistance;
        } else if(pcScript.lastMoveDir.z < 0) {
            wallOfset.z = -ofsetDistance;
        }

        //apply wallofset
        transform.position += wallOfset;
    }

    private void GrowWall() {
        if(transform.position.y < wallStartHeight + growHeight) {  
            gameObject.transform.position += new Vector3(0, 1.5f, 0) * Time.deltaTime;
        }
    }

    public void WallDamage(float amountOfDamage) {
        wallHealth -= amountOfDamage;
    }

    private void DeathCheck() {
        if(wallHealth <= 0) {
            gameObject.SetActive(false);
        }
    }

    private void Update() {
        GrowWall();
        DeathCheck();

        Debug.Log("movementvalue = " + movementValue);
        Debug.Log("lastmovedir = " + pcScript.lastMoveDir);
    }
}
