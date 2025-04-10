using UnityEngine;

public class CollisionSpawner : MonoBehaviour
{
    [Header("Object to Spawn")]
    public GameObject spawnPrefab;

    [Header("Sound to Play")]
    public AudioClip collisionSound;

    private AudioSource audioSource;

    void Start()
    {
        // Create a hidden AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // 1. Get contact point
        ContactPoint contact = collision.contacts[0];
        Vector3 spawnPosition = contact.point;

        // 2. Spawn object at collision point
        if (spawnPrefab != null)
        {
            Instantiate(spawnPrefab, spawnPosition, Quaternion.identity);
            Debug.Log($"📦 Spawned at: {spawnPosition}");
        }

        // 3. Play sound
        if (collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
