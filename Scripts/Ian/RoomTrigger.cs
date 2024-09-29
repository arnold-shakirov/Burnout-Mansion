using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    private bool isOut;
    public GameObject outCam;
    public GameObject inCam;

    private float rot;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            rot = other.transform.localRotation.y;    
    }
    private void OnTriggerExit(Collider other)
    {
        triggerTouch(other);
    }

    void triggerTouch(Collider other)
    {
        if (other.tag == "Player" && rot == other.transform.localRotation.y)
        {
            isOut = !isOut;

            PlayerController.instance.switchCamera((isOut) ? outCam : inCam);
        }
      
    }
}
