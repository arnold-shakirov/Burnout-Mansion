using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(PlayerController.instance.transform); 
    }
}
