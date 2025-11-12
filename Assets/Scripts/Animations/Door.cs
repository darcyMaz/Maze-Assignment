using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator myAnimator;
    Boolean canOpen;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        canOpen = false;
    }

    public void Unlock()
    {
        canOpen = true;
    }
    public void Lock()
    {
        canOpen = false;
    }
    public Boolean IsUnlocked()
    {
        return canOpen;
    }

    public void OpenDoor()
    {
        myAnimator.SetBool("isGameDone", false);
        myAnimator.SetBool("doorCanOpen", true);
    }

    public void CloseDoor()
    {
        myAnimator.SetBool("isGameDone", true);
        myAnimator.SetBool("doorCanOpen", false);
    }
}
