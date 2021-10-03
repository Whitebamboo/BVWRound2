using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveCamera : MonoBehaviour
{
    private InputDevice controller;
    private float vertical;
    private float horizontal;
    public float speed = 1;
    public float outspeed = 0.01f;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevices(devices);

        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        if (devices.Count > 0)
        {
            controller = devices[0];
        }

        transform.localPosition = Vector3.zero;
    }
    private void Update()
    {
        if (controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 thumbStickValue))
        {
            vertical = thumbStickValue.y;
            horizontal = thumbStickValue.x;
            Transform rigTransform = transform.parent.parent;
         //   Debug.Log("this"+this.GetComponent<Transform>().position);
            if (isInTheHouse())
            { 
                rigTransform.position += (Toolkit.ProjectToXZ(transform.forward.normalized * vertical +
                    transform.right.normalized * horizontal)) * Time.deltaTime * speed;
            }
            else
            {
                rigTransform.position += (Toolkit.ProjectToXZ(transform.forward.normalized * vertical +
                    transform.right.normalized * horizontal)) * Time.deltaTime * outspeed;
            }
        }
        
    }

  

    public bool isInTheHouse()
    {
        Vector3 currentPositon = this.GetComponent<Transform>().position;

        if(currentPositon.x <10 && currentPositon.x >-11 &&
           currentPositon.z < 3 && currentPositon.z > -10)
        {
            Debug.Log("cur"+currentPositon);
            return true;
        }
        else
        {
            return false;
        }
    }


}
