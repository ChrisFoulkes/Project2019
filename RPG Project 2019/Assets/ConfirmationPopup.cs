using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum ConfirmResult {
yes, 
no, 
none
}


public class ConfirmationData {
    public string informationText;
    public ConfirmResult confirm = ConfirmResult.none;

    public ConfirmationData(string ptext)
    {
        informationText = ptext;
    }
}

public class ConfirmationPopup : MonoBehaviour
{
    static private ConfirmationPopup __Current;
    static public ConfirmationPopup Current
    {
        get
        {
            if (__Current == null)
            {
                __Current = GameObject.FindObjectOfType<ConfirmationPopup>();
            }

            return __Current;
        }
    }

    List<ConfirmationData> confirmBuffer = new List<ConfirmationData>();
    
    TextMeshProUGUI infoText;

    GameObject popUp;
   
    // Start is called before the first frame update
    void Awake()
    {
        popUp = transform.Find("Popup").gameObject;
        infoText = popUp.transform.Find("ConfirmText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ConfirmationData GenerateConfirmPopup(string ptext) {
        confirmBuffer.Add(new ConfirmationData(ptext));
        if (popUp.activeSelf == false)
        {
            popUp.SetActive(true);

            infoText.text = confirmBuffer[0].informationText;
        }
        return confirmBuffer[confirmBuffer.Count-1];
    }

     void LoadNextInBuffer() {
        infoText.text = confirmBuffer[0].informationText;
     }

    public void ConfirmYes() {
        confirmBuffer[0].confirm = ConfirmResult.yes;
        
        confirmBuffer.RemoveAt(0);
       

        if (confirmBuffer.Count > 0)
        {
            LoadNextInBuffer();
        }
        else {
            popUp.SetActive(false);
        }

    }

    public void ConfirmNo()
    {
        confirmBuffer[0].confirm = ConfirmResult.no;
        confirmBuffer.RemoveAt(0);
        if (confirmBuffer.Count > 0)
        {
            LoadNextInBuffer();
        }
        else
        {
            popUp.SetActive(false);
        }

    }
}
