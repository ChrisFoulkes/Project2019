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
    bool waitingOnConfirm = false;
    Image itemImage;
 
    public void EquipItem(Equipment equipment) {
        if(itemImage == null) { itemImage = GetComponent<Image>(); }
        
        empty = false;
        equipped = equipment;
        itemImage.sprite = Resources.Load<Sprite>(equipped.icon);
    }


    public void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (empty == false && waitingOnConfirm == false)
            {
                Debug.Log("remove item!");
                StartCoroutine(RemoveItem());
            }
            
           
        }
       
    }

    IEnumerator RemoveItem()
    {
        // whatever you're doing now with the temporary / placement preview building
        waitingOnConfirm = true;
        ConfirmationData ConfirmCheck = ConfirmationPopup.Current.GenerateConfirmPopup("Removing item: " + equipped.name + " ? " );

        while (ConfirmCheck.confirm == ConfirmResult.none)
        {
            yield return null; // wait
        }
        if (ConfirmCheck.confirm == ConfirmResult.yes)
        {

                equipped.Unequip();
                equipped = null;
                empty = true;
                itemImage.sprite = null;
                waitingOnConfirm = false;

        }
        else if (ConfirmCheck.confirm == ConfirmResult.no)
        {
            waitingOnConfirm = false;
        }
    }

}
