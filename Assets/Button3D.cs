using UnityEngine;

public class Button3D : MonoBehaviour
{
    public PlayerUIController uiController;

    void OnMouseDown()
    {
        if (uiController != null)
        {
            uiController.ApplySlowedMovement(); // Call any method from your PlayerUIController
        }

        Debug.Log("3D Button clicked!");
    }
}