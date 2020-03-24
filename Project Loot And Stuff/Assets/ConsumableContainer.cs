using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableContainer : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActions() {
        InteractionPanel.Instance.SetAction("Consume", Consume);
        InteractionPanel.Instance.SetAction("Destroy", Destory);
        InteractionPanel.Instance.SetAction("Store", Store);
        InteractionPanel.Instance.SetAction(" Check Condition", CheckCondition);

    }

    public void Consume() {
        Debug.Log("Eating...");
        Destroy(gameObject);
    }

    public void Store()
    {
        Debug.Log("Storing...");    
    }

    public void CheckCondition()
    {
        Debug.Log("Checking Condition...");
    }


    public void Destory()
    {
        Debug.Log("Destorying...");

    }
}
