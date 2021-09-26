using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    public int happiness;

    bool isTouched;

    public void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && !isTouched)
        {
            isTouched = true;

            ObjectManager.Instance.ChangeMood(happiness);
        }
    }
}
