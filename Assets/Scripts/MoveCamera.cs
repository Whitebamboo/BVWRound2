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
    }
    private void Update()
    {
        if (controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 thumbStickValue))
        {
            vertical = thumbStickValue.y;
            horizontal = thumbStickValue.x;

            Transform rigTransform = transform.parent.parent;
            rigTransform.position += (Toolkit.ProjectToXZ(transform.forward.normalized * vertical +
                transform.right.normalized * horizontal)) * Time.deltaTime;
        }
    }
}
