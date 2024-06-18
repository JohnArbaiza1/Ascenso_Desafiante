using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPuertas : MonoBehaviour
{
    public bool doorOpen = false;
    public float doorOpenAngle = 95f;
    public float doorCloseAngle = 0.0f;
    public float smooth = 3.0f;
    public float doorXRotate = 0.0f;

    //public AudioClip opendoor;
    //public AudioClip closeDoor;

    public void ChangeDoorState()
    {
        doorOpen = !doorOpen;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            Quaternion targertRotation = Quaternion.Euler(doorXRotate, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targertRotation, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targertRotation2 = Quaternion.Euler(doorXRotate, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targertRotation2, smooth * Time.deltaTime);
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerDoor")
        {
            AudioSource.PlayClipAtPoint(closeDoor, transform.position, 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        AudioSource.PlayClipAtPoint(opendoor, transform.position, 1);
    }*/
}
