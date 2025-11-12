using UnityEngine;

public class EndGate : MonoBehaviour
{
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenAnimation()
    {
        animator.SetBool("isGameOver", false);
        animator.SetBool("isInTrigger", true);
    }

    public void CloseAnimation()
    {
        animator.SetBool("isInTrigger", false);
        animator.SetBool("isGameOver", true);
    }
}
