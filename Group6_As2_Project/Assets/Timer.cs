using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeToDestroy = 3f;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}