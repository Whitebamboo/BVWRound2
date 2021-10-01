using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum CleaningType
{
    None,
    Hide
}

public class InteractableObjects : MonoBehaviour
{
    public int happinessPoints = 1;

    public CleaningType cleaningType;

    bool isTouched;

    bool isStayInHideArea;

    private void Start()
    {
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnSelectEnter);
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

        GameManager.Instance.ChangeMood(happinessPoints);

        if (cleaningType == CleaningType.Hide && GameManager.Instance.state == GameState.CleaningState)
        {
            GameManager.Instance.disableHideAreaHint();
        }
    }

    public void OnSelectEnter(SelectEnterEventArgs interactor)
    {
        if(cleaningType == CleaningType.Hide && GameManager.Instance.state == GameState.CleaningState)
        {
            GameManager.Instance.ShowHideAreaHint();
        } 
    }
}
