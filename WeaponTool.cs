using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponTool : EventTrigger {
    Transform oriPosition;
    Transform bagParent;
	// Use this for initialization
	void Start () {
        bagParent = GameObject.Find("BagParent").transform;

    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        oriPosition = transform.parent;
        SetParentAndPos(transform, bagParent);
        //关闭当前ui的射线检测
        GetComponent<Image>().raycastTarget = false;

    }

    public override void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;        

    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        Transform item = eventData.pointerCurrentRaycast.gameObject.transform;
        //if (item.gameObject == null) return;

        if (item.gameObject.tag=="bag")
        {
            transform.parent = item;

            transform.position = item.position;
            //SetParentAndPos(transform, item);

        }
        else if (item.gameObject.tag=="good")
        {
            transform.parent = item.parent;
            transform.position = item.position;

            item.parent = oriPosition;
            item.position = oriPosition.position;

            //SetParentAndPos(transform, item.parent);
            //SetParentAndPos(item, oriPosition);
        }
        else
        {
            transform.parent = oriPosition;
            transform.position = oriPosition.position;

            //SetParentAndPos(transform, beginP);

        }
        GetComponent<Image>().raycastTarget = true;
    }


    // Update is called once per frame
    void Update () {
		
	}

    public void SetParentAndPos(Transform item ,Transform mparent)
    {
        item.position = mparent.position;
        item.parent = mparent;
    }

   
}
