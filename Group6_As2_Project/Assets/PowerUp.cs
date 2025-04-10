using System.Collections;
using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
    public enum EffectType
    {
        SlowMove,
        DoubleJump,
        FastAnimation,
        SlowAnimation
    }

    public EffectType effect;
    public float effectDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false; // disable collider first
            StartCoroutine(ApplyEffect(other));       // THEN start the effect
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private IEnumerator ApplyEffect(Collider player)
    {
        var controller = player.GetComponent<StarterAssets.ThirdPersonController>();
        var animator = player.GetComponent<Animator>();

        // backup original values
        float originalMoveSpeed = controller.MoveSpeed;
        float originalSprintSpeed = controller.SprintSpeed;
        float originalJumpHeight = controller.JumpHeight;
        float originalAnimSpeed = animator != null ? animator.speed : 1f;

        // apply chosen effect
        switch (effect)
        {
            case EffectType.SlowMove:
                controller.MoveSpeed *= 0.5f;
                controller.SprintSpeed *= 0.5f;
                Debug.Log("Applied SLOW MOVE");
                break;

            case EffectType.DoubleJump:
                controller.JumpHeight *= 2f;
                Debug.Log("Applied DOUBLE JUMP HEIGHT");
                break;

            case EffectType.FastAnimation:
                if (animator != null)
                {
                    animator.speed = 2.0f;
                    Debug.Log("Applied FAST ANIMATION SPEED");
                }
                break;

            case EffectType.SlowAnimation:
                if (animator != null)
                {
                    animator.speed = 0.5f;
                    Debug.Log("Applied SLOW ANIMATION SPEED");
                }
                break;
        }


        yield return new WaitForSeconds(effectDuration);
        Debug.Log("Power-up effect ended, values reset.");

        // restore original values
        controller.MoveSpeed = originalMoveSpeed;
        controller.SprintSpeed = originalSprintSpeed;
        controller.JumpHeight = originalJumpHeight;
        if (animator != null)
            animator.speed = originalAnimSpeed;
    }
}
