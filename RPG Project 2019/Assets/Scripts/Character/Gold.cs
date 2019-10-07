using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour, Iinteractable
{
    void Start() {
      
    }

    public void Interact() {

        Debug.Log("5 gold added!");
        PopupText.Instance.GenerateText("5 gold added!");
        Destroy(gameObject);
    }

}