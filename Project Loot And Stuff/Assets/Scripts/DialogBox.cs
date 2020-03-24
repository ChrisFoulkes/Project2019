using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class DialogBox : MonoBehaviour
{
    public static DialogBox Instance { get; private set; }

    public TextMeshProUGUI dialogText;

    public Button option1;
    public Button option2;

    Dialog currentDialog;
    DialogNode currentNode;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple Dialog Boxes instances warning destorying self!!!");

            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }

    public void SetDialog(Dialog dialog) {
        currentDialog = dialog;
        SetNode(dialog.dialogNodes[dialog.dialogPosition]);
    }
    public void SetNode(DialogNode node) {
        currentNode = node;

        dialogText.text = node.dialogText;

        //update this to dynamically scale the options based on number of options
        if (node.dialogOptions.Count != 0)
        {
            option1.GetComponentInChildren<TextMeshProUGUI>().text = node.dialogOptions[0].optionText;
            option1.onClick.AddListener(delegate { OptionSelect(0); });
            option2.GetComponentInChildren<TextMeshProUGUI>().text = node.dialogOptions[1].optionText;
            option2.onClick.AddListener(delegate { OptionSelect(1); });
        }
        else {
            option1.gameObject.SetActive(false);
            option2.gameObject.SetActive(false);
        }
    }

    public void OptionSelect(int option) {
        currentDialog.UpdatePosition(currentNode.dialogOptions[option].targetNode);
    }

    public void CloseBox() {
        gameObject.SetActive(false);
    }
}
