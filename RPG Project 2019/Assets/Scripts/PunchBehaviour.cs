
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Punch Behaviour", menuName = "Item Behaviours/Punch Behaviour")]

public class PunchBehaviour : ItemBehaviour
{

    public string behaviourName = "punch";

    public override void Action()
    {
        Debug.Log("Action: " + behaviourName);
    }

}

