using System;
using System.Collections.Generic;
using UnityEngine;

//PlayerStatsManager handles the playerstats when the players type changes
public class PlayerStatsManager : MonoBehaviour {
    private void Start() {
        
    }

    public void GetPlayerStats() {
        // call in typehandler.ChangePlayerType(); to return the players stats list / array
    }

    public void RefreshPlayerStats(string newType, string oldType) {
        // call in typehandler.ChangePlayerType(); to fun the switchcase if the players type is the same as already is, multiply stats, else, change player stats to coresponding type
        if(newType == oldType) {
            MultiplyPlayerStats();
        } else {
            SwitchPlayerStats();
        }
    }

    private void MultiplyPlayerStats() {
        //players stats *'x' doen zodat de player de enhanced versie van het type krijgt wat hij nu al heeft... (moet wel maar 1x kunnen.. max.)
    }

    private void SwitchPlayerStats() {
        //zelfde manier players stats veranderen als gedaan is met de spriterenderer (component niet veranderen maar gwn andere scriptable object doorsturenb en de stats daarmee updaten...)
    }

    public void SetPlayerStats() {

    }
}
