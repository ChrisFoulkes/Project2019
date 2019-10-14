using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour, Iinteractable
{
    bool waitingOnConfirm = false;

    void Start() {
      
    }

    public void Interact(GameObject interacter) {

      
        if (waitingOnConfirm == false) {
            StartCoroutine(GoldTest());
        }
    }

    IEnumerator GoldTest()
    {
        // whatever you're doing now with the temporary / placement preview building
        waitingOnConfirm = true;
        ConfirmationData ConfirmCheck = ConfirmationPopup.Current.GenerateConfirmPopup("Gift 5 gold to the begger!");

        while (ConfirmCheck.confirm == ConfirmResult.none)
        {
            yield return null; // wait
        }
        if (ConfirmCheck.confirm == ConfirmResult.yes)
        {

            PopupText.Instance.GenerateText("5 gold given to the beggar!");
         

            Destroy(gameObject);

        }
        else if (ConfirmCheck.confirm == ConfirmResult.no) {

            PopupText.Instance.GenerateText("5 gold added!");

            Destroy(gameObject);
        }
    }
}