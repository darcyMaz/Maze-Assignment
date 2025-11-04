using UnityEngine;

public class PlaneTrigger : MonoBehaviour
{
    Door door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door = GetComponentInParent<Door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        door.CanOpen();
    }

    private void OnTriggerExit(Collider other)
    {
        door.CannotOpen();
    }
}
