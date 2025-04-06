using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip oneShotClip;
    public AudioClip loopingClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.loop = true;
        audioSource.clip = loopingClip;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(oneShotClip);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }
}
