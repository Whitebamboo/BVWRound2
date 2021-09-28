using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableObjects : MonoBehaviour
{
    public int happiness = 1;

    bool isTouched;

    bool isStayInHideArea;

    private void Start()
    {
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnSelectExit);
        isStayInHideArea = false;
    }

    public void OnTriggerStay(Collider other)
    {  
        if(isTouched && other.GetComponent<HideArea>() != null && !isStayInHideArea)
        {
            isStayInHideArea = true;

            GameManager.Instance.ChangeClean(1);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (isTouched && other.GetComponent<HideArea>() != null && isStayInHideArea)
        {
            isStayInHideArea = false;

            GameManager.Instance.ChangeClean(-1);
        }
    }

    public void OnSelectExit(SelectExitEventArgs interactor)
    {
        if(isTouched)
        {
            return;
        }

        isTouched = true;

        GameManager.Instance.ChangeMood(happiness);
    }
}
