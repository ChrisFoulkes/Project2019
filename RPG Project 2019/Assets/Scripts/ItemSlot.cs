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
    public Sprite DefaultIcon;
    ItemPanel parentPanel;

    private void Start()
    {
        itemImage = GetComponent<Image>(); 

        DefaultIcon = itemImage.sprite;

    }
    public void SetPanel(ItemPanel panel) {
        parentPanel = panel;
    }

    public void SetItem(Equipment equipment) {
 
       
        empty = false;
        equipped = equipment;
        itemImage.sprite = Resources.Load<Sprite>(equipped.icon);
    }


    public void SetDefault() {
        equipped = null;
        empty = true;
        itemImage.sprite = DefaultIcon;
    }

    public void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (empty == false && waitingOnConfirm == false)
            {
                StartCoroutine(RightClickRemoveItem());
            }
            
           
        }
       
    }

    IEnumerator RightClickRemoveItem()
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

            equipped.inventory.RemoveItem(equipped.equipmentType);
            equipped = null;
            empty = true;
            itemImage.sprite = DefaultIcon;
            waitingOnConfirm = false;


        }
        else if (ConfirmCheck.confirm == ConfirmResult.no)
        {
            waitingOnConfirm = false;
     
        }
    }

}
