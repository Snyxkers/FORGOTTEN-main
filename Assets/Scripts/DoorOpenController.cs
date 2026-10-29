
using UnityEngine;

public class DoorOpenController : MonoBehaviour
{
    public Animator doorAnimator;

    void Start()
    {
        if (doorAnimator == null)
        {
            doorAnimator = GetComponent<Animator>();
        }

        if (doorAnimator == null)
        {
            Debug.LogError("Animator not found! Assign the Door Animator in Inspector.");
        }
        else
        {
            Debug.Log("Door Animator found!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key pressed!");

            if (doorAnimator != null)
            {
                doorAnimator.SetTrigger("OpenDoor");
                Debug.Log("OpenDoor trigger activated!");
            }
        }
    }
}
