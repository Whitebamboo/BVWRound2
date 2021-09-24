using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TVController : XRGrabInteractable
{
    private static TVController _instance;
    public static TVController Instance
    {
        get
        {
            return _instance;
        }
    }
    private readonly string code = "Television";

    private readonly Vector3 grabRotation = new Vector3(-10f, 0, 0);

    private bool _gaveGuidance = false;

    public Television television;


    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

        onSelectEntered.AddListener(Grab);
        onSelectEntered.AddListener(SetRotation);
        onActivate.AddListener(SendSignal);

        onSelectExited.AddListener(Drop);
        onSelectExited.AddListener(RestorePosition);

    }
    /*public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (!_grabbedBefore)
        {
            if (Time.time - _lastChangeMaterial > 0.5f)
            {
                if (meshRenderer.material == shineMaterial)
                {
                    meshRenderer.material = originalMaterial;
                }
                else
                {
                    meshRenderer.material = shineMaterial;
                }
                _lastChangeMaterial = Time.time;
            }
            //Debug.Log(meshRenderer.material.GetFloat("_FresnelPower"));
            //meshRenderer.material.Lerp(originalMaterial, shineMaterial, 1f);
            
            //Debug.Log(Mathf.Clamp((Mathf.Sin(Time.time) + 1) / 2, 0f, 1f));
        }
    }*/
    private void OnDestroy()
    {
        onSelectEntered.RemoveListener(Grab);
        onSelectEntered.RemoveListener(SetRotation);
        onActivate.RemoveListener(SendSignal);

        onSelectExited.RemoveListener(Drop);
        onSelectExited.RemoveListener(RestorePosition);
    }
    private void Grab(XRBaseInteractor interactor)
    {
        HideHand(interactor, false);
        //if (!_gaveGuidance)
        //{
        //    _gaveGuidance = true;
        //    Mum.Instance.TryGiveGuidance(code);
        //}
    }
    private void Drop(XRBaseInteractor interactor)
    {
        HideHand(interactor, true);
    }
    private void SetRotation(XRBaseInteractor interactor)
    {
        Quaternion initialRotation = Quaternion.Euler(grabRotation);
        interactor.attachTransform.localRotation = initialRotation;
    }
    private void RestorePosition(XRBaseInteractor interactor)
    {
        interactor.attachTransform.localPosition = Vector3.zero;
    }
    private void HideHand(XRBaseInteractor interactor, bool hide)
    {
        //if (interactor is Hand hand)
        //{
        //    hand.SetVisibility(hide);
        //}
    }
    private void SendSignal(XRBaseInteractor interactor)
    {
        Debug.Log("sending signal");
        Vector3 diff = (television.TVReciverPosition - transform.position).normalized;
        if (Vector3.Dot(diff, transform.forward) > 0.9f)
        {
            television.ChangeTvStatus();
        }
    }
}
