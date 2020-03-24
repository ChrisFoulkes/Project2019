using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public int dialogPosition;

    public List<DialogNode> dialogNodes = new List<DialogNode>();

    public void OpenDialog() {
        if (dialogPosition != -1)
        {
            DialogBox.Instance.SetDialog(this);
        
      
        }
    }

    public void UpdatePosition(int newpos) {
        dialogPosition = newpos;

        if (dialogPosition != -1)
        {
            DialogBox.Instance.SetDialog(this);
        }
        else {
            DialogBox.Instance.CloseBox();
        }
    }
}
