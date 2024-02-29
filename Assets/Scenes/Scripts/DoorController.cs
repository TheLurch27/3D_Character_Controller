using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door; // Referenz zur T�r
    public float openAngle = -90f; // �ffnungswinkel der T�r
    public float smooth = 2f; // Geschwindigkeit der T�r�ffnung

    private bool isOpen = false;
    private Quaternion defaultRotation;
    private Quaternion openRotation;

    private void Start()
    {
        defaultRotation = door.transform.rotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * defaultRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = false;
        }
    }

    private void Update()
    {
        if (isOpen)
        {
            door.transform.rotation = Quaternion.Slerp(door.transform.rotation, openRotation, Time.deltaTime * smooth);
        }
        else
        {
            door.transform.rotation = Quaternion.Slerp(door.transform.rotation, defaultRotation, Time.deltaTime * smooth);
        }
    }
}
