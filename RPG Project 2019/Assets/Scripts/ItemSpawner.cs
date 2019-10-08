using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, Iinteractable
{


    public Equipment equipmentDisplay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(GameObject interacter) {
      
        GenerateItem(interacter);
         
        PickupItem(interacter);

        Destroy(gameObject);
    }

    void GenerateItem(GameObject player) {
        Equipment testitem = new Equipment("Test HELM", EquipmentType.Helm, "ItemIcons/icon_circlet_helm");


        StatModifier mod = new StatModifier(3f, StatName.Strength);

        testitem.AddItemStat(mod);

        


        equipmentDisplay = testitem;

  


    }

    void PickupItem(GameObject player)
    {
        equipmentDisplay.Equip(player);
    }
}
