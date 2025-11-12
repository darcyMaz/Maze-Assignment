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
        door.Unlock();
    }

    private void OnTriggerExit(Collider other)
    {
        door.Lock();
    }
}
