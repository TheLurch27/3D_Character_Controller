using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    public Transform door;
    public float openAngle = -90f;
    public float openSpeed = 2f;
    public InputActionReference interactAction;

    private bool isOpening = false;
    private bool canInteract = false;

    void Update()
    {
        if (canInteract)
        {
            if (interactAction.action.triggered)
            {
                isOpening = true;
            }
        }

        if (isOpening)
        {
            float targetAngle = Quaternion.Euler(0, openAngle, 0).eulerAngles.y;
            float currentAngle = door.rotation.eulerAngles.y;

            if (Mathf.Abs(targetAngle - currentAngle) > 0.1f)
            {
                float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, openSpeed * Time.deltaTime);
                door.rotation = Quaternion.Euler(0, newAngle, 0);
            }
            else
            {
                isOpening = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            // Hier kannst du den UI-Hinweis anzeigen
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            // Hier kannst du den UI-Hinweis ausblenden
        }
    }
}
