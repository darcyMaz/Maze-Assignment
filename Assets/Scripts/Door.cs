using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator myAnimator = null;
    Boolean canOpen;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        canOpen = false;
    }

    public void CanOpen()
    {
        canOpen = true;
    }
    public void CannotOpen()
    {
        canOpen = false;
    }

    public void PlayAnimation()
    {
        myAnimator.SetBool("doorCanOpen", true);
    }
}
