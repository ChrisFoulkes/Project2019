using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogNode
{
    public int NodeID; 
    public string dialogText = "Not Set Dialog";

    public List<DialogOption> dialogOptions;

}
