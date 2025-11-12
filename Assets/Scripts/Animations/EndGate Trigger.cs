using UnityEngine;

public class EndGateTrigger : MonoBehaviour
{
    public EndGate eg;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // sets the bool of the animation for EndGate
        eg.OpenAnimation();
    }

}
