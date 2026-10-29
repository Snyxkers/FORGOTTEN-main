
using UnityEngine;

public class GrabHandTrigger : MonoBehaviour
{
    public Animator animator;

    private bool isGrabbed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isGrabbed = !isGrabbed;

            if (isGrabbed)
            {
                animator.Play("GrabHAND", 0, 0f);
            }
            else
            {
                animator.Play("ungrab", 0, 0f);
            }
        }
    }
}
