using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButonHandler : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IDeselectHandler
{
    public void OnDeselect(BaseEventData eventData)
    {
        GetComponent<Selectable>().OnPointerExit(null);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.selectedObject.GetComponent<Button>() != null)//I only care if its a button
        {
            GetComponent<Button>().onClick.Invoke();//call the button that is currently selected
        }
        Input.ResetInputAxes();//assure dont put 2 focuses
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Selectable>().Select();//put the focus on the button I moved the cursor above
    }


}