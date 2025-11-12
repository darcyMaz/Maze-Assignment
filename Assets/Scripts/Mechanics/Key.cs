using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Set starting position in inpsector.
    public Vector3 starting_pos;

    void Start()
    {
        // If a starting position was not set in the inspector, a warning will be sent out.
        if (starting_pos == Vector3.zero)
        {
            Debug.Log("A starting position was not set in the inspector for this key: " + name + ".");
            starting_pos = transform.position;
        }

        // Set the current position to the starting position.
        transform.position = starting_pos;

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // This makes the gameObject dissapear.
        gameObject.SetActive(false);
    }

    public Boolean IsCollected()
    {
        return !gameObject.activeSelf;
    }

    public void ResetKey()
    {
        transform.position = starting_pos;
        gameObject.SetActive(true);
    }



}
