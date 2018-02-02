using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Restrict : MonoBehaviour {
    RectTransform rectTransform;
    public RectTransform parent;
    // Use this for initialization
    void Start () {
        rectTransform = GetComponent<RectTransform>();
        //rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update () {
        //print(rectTransform.rect.ToString());
        //print(rectTransform.anchoredPosition.ToString());
        //print(rectTransform.sizeDelta.ToString());
        //print(rectTransform.rect.ToString());
        //print(rectTransform.offsetMin);        
        if (rectTransform.anchoredPosition.magnitude>Mathf.Abs(rectTransform.rect.x-parent.rect.x))
        {
            rectTransform.anchoredPosition = rectTransform.anchoredPosition.normalized * Mathf.Abs(rectTransform.rect.x - parent.rect.x);
        }

    }
}
