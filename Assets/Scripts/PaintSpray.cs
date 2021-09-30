using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSpray : MonoBehaviour
{
    public GameObject spray;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collision other)
    {
        //Debug.Log("1");
        if (other.gameObject.tag == "Player")
        {
            spray.gameObject.SetActive(true);
        }
    }
}
