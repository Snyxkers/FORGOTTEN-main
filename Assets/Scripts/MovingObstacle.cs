using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float distance = 3f;
    public float speed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * speed) * distance;

        transform.position = startPosition + new Vector3(x, 0f, 0f);
    }
}