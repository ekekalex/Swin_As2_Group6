using UnityEngine;

public class ObjectManipulator : MonoBehaviour
{
    [Header("Target Prefab (for instantiation)")]
    public GameObject objectPrefab;

    [Header("Target Instance (for show/hide/destroy)")]
    public GameObject targetObject;

    private GameObject spawnedObject;

    void Update()
    {
        // A) Hide/show object (Toggle with H key)
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (targetObject != null)
            {
                bool isActive = targetObject.activeSelf;
                targetObject.SetActive(!isActive);
                Debug.Log(isActive ? "Object hidden" : "Object shown");
            }
        }

        // B) Instantiate new object (on I key)
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (objectPrefab != null)
            {
                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(objectPrefab, transform.position + Vector3.right * 2, Quaternion.identity);
                    Debug.Log("Object instantiated.");
                }
                else
                {
                    Debug.Log("Object already exists.");
                }
            }
        }

        // C) Destroy the instantiated object (on D key)
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (spawnedObject != null)
            {
                Destroy(spawnedObject);
                spawnedObject = null;
                Debug.Log("Object destroyed.");
            }
        }
    }
}
