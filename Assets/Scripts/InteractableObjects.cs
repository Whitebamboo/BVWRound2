using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum CleaningType
{
    None,
    HideAndReturn
}

public class InteractableObjects : MonoBehaviour
{
    public int happinessPoints = 1;

    public CleaningType cleaningType;

    public AudioClip onSelectClip;

    bool isTouched;

    bool isStayInHideArea;

    private void Start()
    {
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnSelectEnter);
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnSelectExit);
        isStayInHideArea = false;

        if(cleaningType == CleaningType.HideAndReturn)
        {
            Debug.Log(gameObject.name);
            GameManager.Instance.InitCleanValue();
        }
    }

    public void OnTriggerStay(Collider other)
    {  
        if(isTouched && other.GetComponent<HideArea>() != null && !isStayInHideArea && GameManager.Instance.state == GameState.CleaningState)
        {
            isStayInHideArea = true;

            MusicManager.Instance.PlayClean();
            GameManager.Instance.ChangeClean(1);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (isTouched && other.GetComponent<HideArea>() != null && isStayInHideArea && GameManager.Instance.state == GameState.CleaningState)
        {
            isStayInHideArea = false;

            GameManager.Instance.ChangeClean(-1);
        }
    }

    public void OnSelectExit(SelectExitEventArgs interactor)
    {
        if (cleaningType == CleaningType.HideAndReturn && GameManager.Instance.state == GameState.CleaningState)
        {
            GameManager.Instance.DisableHideAreaHint();
        }

        if (isTouched)
        {
            return;
        }

        isTouched = true;

        GameManager.Instance.ChangeMood(happinessPoints);
    }

    public void OnSelectEnter(SelectEnterEventArgs interactor)
    {
        if(onSelectClip != null)
        {
            MusicManager.Instance.PlayClip(onSelectClip);
        }

        if(cleaningType == CleaningType.HideAndReturn && GameManager.Instance.state == GameState.CleaningState)
        {
            GameManager.Instance.ShowHideAreaHint();
        } 
    }

    
}
