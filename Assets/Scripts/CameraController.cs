
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform cameraTarget;

    public float mouseSensitivity = 200f;
    public float minPitch = -60f;
    public float maxPitch = 60f;

    private float yaw;
    private float pitch;

    void Start()
    {
        LockCursor();

        if (player != null)
            yaw = player.eulerAngles.y;
    }

    void Update()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
            LockCursor();

        if (player == null || cameraTarget == null)
            return;

        yaw += Input.GetAxis("Mouse X") *
               mouseSensitivity * Time.deltaTime;

        pitch -= Input.GetAxis("Mouse Y") *
                 mouseSensitivity * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        player.rotation = Quaternion.Euler(0f, yaw, 0f);
    }

    void LateUpdate()
    {
        if (player == null || cameraTarget == null)
            return;

        transform.position = cameraTarget.position;
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
            LockCursor();
    }
}
