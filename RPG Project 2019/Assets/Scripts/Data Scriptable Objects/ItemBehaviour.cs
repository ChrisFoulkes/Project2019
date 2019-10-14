using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum BehaviourType {
    Ability,
    Character
}

[System.Serializable]
public class ItemBehaviour : ScriptableObject
{


    public virtual void Action() {

    }
}
