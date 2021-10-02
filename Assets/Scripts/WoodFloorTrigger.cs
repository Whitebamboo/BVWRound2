using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//raise and lower the play position
public class WoodFloorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Transform rigTransform = other.transform.parent.parent;
            rigTransform.position = new Vector3(rigTransform.position.x, 0.8f, rigTransform.position.z);
        }
    }
}
