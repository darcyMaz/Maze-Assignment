using System;
using Unity.VisualScripting;
using UnityEngine;

public class MazeEntrance : MonoBehaviour
{
    Animator myAnimator;
    Boolean isOpen;
    Boolean canTransition;
    Boolean isTransitioning;
    float animationCountdownLength;
    float animationCountdown;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        isOpen = false;
        canTransition = false;
        isTransitioning = false;
        animationCountdownLength = 1.5f;
        animationCountdown = animationCountdownLength;
    }

    void Update()
    {
        if (canTransition && !isTransitioning)
        {
            // Debug.Log("canTransition plus istransitioning is false");
            if (!isOpen) { OpenDoor(); isOpen = true; }
            else { CloseDoor(); isOpen = false;
        }
        }

        if (isTransitioning)
        {
            animationCountdown -= Time.deltaTime;
        }
        if (animationCountdown <= 0)
        {
            animationCountdown = animationCountdownLength;
            isTransitioning = false;
        }
    }

    public void DoorCanTransition()
    {
        canTransition = true;
    }
    public void DoorCannotTransition()
    {
        canTransition = false;
    }

    public void OpenDoor()
    {
        myAnimator.SetBool("doorClose", false);
        myAnimator.SetBool("doorOpen", true);
        isTransitioning = true;
        canTransition = false;
    }

    public void CloseDoor()
    {
        myAnimator.SetBool("doorOpen", false);
        myAnimator.SetBool("doorClose", true);
        isTransitioning = true;
        canTransition = false;
    }
}
