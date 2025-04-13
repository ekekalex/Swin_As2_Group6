using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource collisionSound;
    public GameObject player;
    public Mesh ballMesh;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "PlayerArmature")
        {
            print("collision");
            collisionSound.Play();
            
            GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            ball.transform.position = new Vector3(0, 1.5f, 0);
            ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            ball.AddComponent<Rigidbody>();
        }    
    }
}
