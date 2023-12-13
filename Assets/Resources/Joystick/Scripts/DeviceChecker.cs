using System;
using UnityEngine;

public class DeviceChecker : MonoBehaviour
{
    [SerializeField] private GameObject joyStick;

    private void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            joyStick.SetActive(true);
        }
    }
}
