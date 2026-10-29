using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private void Update()
    {
        // Paikutin ang coin
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        CoinManager coinManager = other.GetComponent<CoinManager>();

        if (coinManager != null)
        {
            coinManager.AddCoin();

            Destroy(gameObject);
        }
    }
}