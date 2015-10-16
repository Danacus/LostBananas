using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameStart : MonoBehaviour
{

    // Use this for initialization
    private void Start()
    {
        Analytics.CustomEvent("UserData", new Dictionary<string, object>
          {
            { "Username", System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) },
            { "OS", SystemInfo.operatingSystem },
            { "Device model", SystemInfo.deviceModel },
            { "Device name", SystemInfo.deviceName }
          });
    }

    // Update is called once per frame
    private void Update()
    {

    }
}