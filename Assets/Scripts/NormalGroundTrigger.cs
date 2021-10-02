using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGroundTrigger : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Transform rigTransform = other.transform.parent.parent;
            if(rigTransform.position.y > 0.5f)
            {
                rigTransform.position = new Vector3(rigTransform.position.x, 0.2f, rigTransform.position.z);
            }
        }
    }
}
