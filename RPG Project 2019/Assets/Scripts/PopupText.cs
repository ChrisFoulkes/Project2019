using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class PopupText : MonoBehaviour
{

    public static PopupText Instance { get; private set; }

    TextMeshProUGUI textmesh;
    Color fade;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            Debug.LogWarning("Multiple PopupText instances warning destorying self!!!");

            Destroy(gameObject);
        }
    }
    void Start()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
        fade = new Color(0.1f, 0.1f, 0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void GenerateText(string inputText)
    {
     
        textmesh.text = "> " + inputText;
        textmesh.color = new Color(0.1f, 0.1f, 0.1f, 1f);

        StopAllCoroutines();
        StartFade();
    }




    public void StartFade()
    {
        StartCoroutine(FadeOut());
    }


    IEnumerator FadeOut()
    {
        textmesh.color = new Color(0.1f, 0.1f, 0.1f, 1f);

        for (float f = 1f; f >= -0.03f; f -= 0.03f)
        {
            fade.a = f;
            textmesh.color = fade;
            yield return new WaitForSeconds(0.06f);
        }

    }



}

