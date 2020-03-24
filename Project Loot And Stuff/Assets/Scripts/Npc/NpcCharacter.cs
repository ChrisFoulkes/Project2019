using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InteractionType {
 Empty,
 Dialog
}
public class NpcCharacter : MonoBehaviour
{
    Dialog dialog;
    public InteractionType npctype; 
    // Start is called before the first frame update
    void Start()
    {
        if (npctype == InteractionType.Dialog) {
            dialog = gameObject.GetComponent<Dialog>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if(npctype == InteractionType.Dialog)
        {
            dialog.OpenDialog();
        }
    }
}
