using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellDatabase", menuName = "ScriptableObjects/Spell Database")]
public class SpellDatabase : ScriptableObject {
    public List<SpellScriptableObject> soList;

    public SpellScriptableObject GetType(string type) {
        foreach(SpellScriptableObject so in soList) {
            if(so.type == type) {
                return so;
            }
        }
        return null;
    }
}

//dit scriptable object moet een list maken met scriptable objects erin, zodat hier in gekeken kan worden en een check op gedaan kan worden/ een antwoord gegeven kan worden op het veranderen van type.