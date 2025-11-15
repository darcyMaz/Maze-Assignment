using System;
using UnityEngine;

public class MazeEntranceTrigger : MonoBehaviour
{
    MazeEntrance me;
    Boolean CanClick;

    private void Start()
    {
        CanClick = false;
        me = GetComponentInParent<MazeEntrance>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            CanClick = true;
        }
    }

    private void OnMouseDown()
    {
        if (CanClick)
        {
            me.DoorCanTransition();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        me.DoorCannotTransition();
        CanClick = false;
    }
}
