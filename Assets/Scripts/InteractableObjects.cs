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
    Renderer rend;
    // public GameObject OutlineObject;
    public float _frenel = 0.02f;

    public int happinessPoints = 1;

    public CleaningType cleaningType;

    public AudioClip onSelectClip;

    bool isTouched;

    bool isStayInHideArea;

    private void Start()
    {
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnSelectEnter);
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnSelectExit);
        GetComponent<XRGrabInteractable>().firstHoverEntered.AddListener(OnHoverEnter);
        GetComponent<XRGrabInteractable>().lastHoverExited.AddListener(OnHoverExit);
        isStayInHideArea = false;

        rend = GetComponent<Renderer>();
        //rend.material.shader = Shader.Find("Assets/Shader/NewUnlitShader.shader");

        if (cleaningType == CleaningType.HideAndReturn)
        {
            Debug.Log(gameObject.name);
            GameManager.Instance.InitCleanValue();
        }
        /*
        if (OutlineObject == null)
        {
            Debug.Log("Object missing OutlineObject");
            return;
        }
        OutlineObject.SetActive(false);
        */
        rend.material.SetFloat("_frenel", 0.02f);
    }

    void OnHoverEnter(HoverEnterEventArgs args)
    {/*
        if(OutlineObject == null)
        {
            Debug.Log("Object missing OutlineObject");
            return;
        }
        OutlineObject.SetActive(true);
        */
        rend.material.SetFloat("_frenel", 0.25f);
    }

    void OnHoverExit(HoverExitEventArgs args)
    {/*
        if (OutlineObject == null)
        {
            Debug.Log("Object missing OutlineObject");
            return;
        }
        OutlineObject.SetActive(false);
        */
        rend.material.SetFloat("_frenel", 0.02f);
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
    {/*
        if (OutlineObject != null)
        {
            OutlineObject.SetActive(false);
        }
        */
        rend.material.SetFloat("_frenel", 0.02f);
        if (onSelectClip != null)
        {
            MusicManager.Instance.PlayClip(onSelectClip);
        }

        if(cleaningType == CleaningType.HideAndReturn && GameManager.Instance.state == GameState.CleaningState)
        {
            GameManager.Instance.ShowHideAreaHint();
        } 
    }

    
}
