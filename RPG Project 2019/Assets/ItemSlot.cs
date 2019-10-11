using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class ItemSlot : MonoBehaviour
{

    [SerializeField]
    Equipment equipped;

    bool empty = true;

    Image itemImage;
 
    public void EquipItem(Equipment equipment) {
        if(itemImage == null) { itemImage = GetComponent<Image>(); }
        
        empty = false;
        equipped = equipment;
        itemImage.sprite = Resources.Load<Sprite>(equipped.icon);
    }

    public void RemoveItem() {

        //need to add a confirmation box window system 

        if (empty == false)
        {
            equipped.Unequip();
            equipped = null;
            empty = true;
            itemImage.sprite = null;
        }
    }

    public void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
 
            RemoveItem();
           
        }
       
    }
}
