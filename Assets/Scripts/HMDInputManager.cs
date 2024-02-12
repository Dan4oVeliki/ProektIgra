using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMDInputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Is device active {XRSettings.isDeviceActive}");
        Debug.Log($"Is device Name {XRSettings.loadedDeviceName}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
