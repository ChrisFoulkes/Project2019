using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour, Iinteractable
{
    public void Interact() {
        Debug.Log("5 gold added!");
        Destroy(gameObject);
    }
}
