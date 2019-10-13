using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Kick Behaviour", menuName = "Item Behaviours/Kick Behaviour")]

public class BonusBehaviour : ItemBehaviour
{
    
    public string behaviourName = "kick";

    public  override void Action() {
        Debug.Log("Action: " + behaviourName);
    }
    
}
