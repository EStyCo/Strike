using System;
using System.Collections;
using UnityEngine;
using YG;

public class DeviceChecker : MonoBehaviour
{
    [SerializeField] private GameObject joyStick;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(GetDataDevice());
    }

    private IEnumerator GetDataDevice()
    {
        float expectedTimer = 0;
        float timer = 0.25f;
        
        while (expectedTimer < 80)
        {
            if (YandexGame.SDKEnabled)
            {
                CheckDevice();
            }

            expectedTimer += timer;
            yield return new WaitForSeconds(timer);
        }
    }

    private void CheckDevice()
    {
        if(YandexGame.EnvironmentData.deviceType == "mobile") joyStick.SetActive(true);

        else Destroy(joyStick);
    }
}
