using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class PlayerUIController : MonoBehaviour
{
    public Button slowButton;
    public Button doubleJumpButton;
    public Button halfJumpButton;
    public Button fastAnimButton;
    public Button slowAnimButton;
    public Button resetButton;

    public ThirdPersonController playerController;

    void Start()
    {
        if (slowButton != null) slowButton.onClick.AddListener(ApplySlowedMovement);
        if (doubleJumpButton != null) doubleJumpButton.onClick.AddListener(DoubleJumpHeight);
        if (halfJumpButton != null) halfJumpButton.onClick.AddListener(HalveJumpHeight);
        if (fastAnimButton != null) fastAnimButton.onClick.AddListener(FastAnimation);
        if (slowAnimButton != null) slowAnimButton.onClick.AddListener(SlowAnimation);
        if (resetButton != null) resetButton.onClick.AddListener(ResetPlayerStats);
    }

    void ApplySlowedMovement()
    {
        playerController.MoveSpeed = 1.0f;
        playerController.SprintSpeed = 2.5f;
        Debug.Log("Slowed movement applied.");
    }

    void DoubleJumpHeight()
    {
        playerController.JumpHeight = 2.4f;
        Debug.Log("Jump height doubled.");
    }

    void HalveJumpHeight()
    {
        playerController.JumpHeight = 0.6f;
        Debug.Log("Jump height halved.");
    }

    void FastAnimation()
    {
        playerController.AnimationSpeedMultiplier = 2.0f;
        Debug.Log("Animation speed doubled.");
    }

    void SlowAnimation()
    {
        playerController.AnimationSpeedMultiplier = 0.5f;
        Debug.Log("Animation speed halved.");
    }

    void ResetPlayerStats()
    {
        playerController.MoveSpeed = 2.0f;
        playerController.SprintSpeed = 5.335f;
        playerController.JumpHeight = 1.2f;
        playerController.AnimationSpeedMultiplier = 1.0f;
        Debug.Log("Player stats reset.");
    }
}
