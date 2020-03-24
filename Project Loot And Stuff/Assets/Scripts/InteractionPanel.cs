using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InteractionPanel : MonoBehaviour
{
    public static InteractionPanel Instance { get; private set; }


    public RectTransform rect;

    // Start is called before the first frame update
    public GameObject container;
    public GameObject interactionPrefab;

    public delegate void TestFunctions();
    private List<GameObject> ActionButtons = new List<GameObject>();

    public int counter = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple InteractionPanels instances warning destorying self!!!");

            Destroy(gameObject);
        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetPosition()
    {
     
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + rect.sizeDelta.x/2, Input.mousePosition.y - rect.sizeDelta.y / 2, 0f));
        transform.position = mousePos;
    }


    public void SetAction(string pText, TestFunctions func)
    {
        if (ActionButtons.Count < counter+1)
        {
            ActionButtons.Add(Instantiate<GameObject>(interactionPrefab, container.transform));
        }

        ActionButtons[counter].GetComponentInChildren<TextMeshProUGUI>().text = pText;
        ActionButtons[counter].GetComponent<Button>().onClick.AddListener(delegate { func(); });
        ActionButtons[counter].GetComponent<Button>().onClick.AddListener(Clicked);
        container.transform.GetChild(counter).gameObject.SetActive(true);
        counter++; 
    }

    public void Clicked() {
        
        Enabled(false);
    }

    public void Enabled(bool value)
    {
        if (value)
        {
            foreach (GameObject button in ActionButtons)
            {
                button.SetActive(false);
                button.GetComponent<Button>().onClick.RemoveAllListeners();
            }
            counter = 0;
        
        }
        else {
            foreach (GameObject button in ActionButtons) {
                button.SetActive(false);
                button.GetComponent<Button>().onClick.RemoveAllListeners();
            }
        }

    }
}
