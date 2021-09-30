using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSpray : MonoBehaviour
{
    public GameObject spray;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            spray.gameObject.SetActive(true);
        }
    }
}
