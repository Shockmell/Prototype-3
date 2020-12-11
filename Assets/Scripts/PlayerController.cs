using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private bool isOnGround = true;
    private Animator anim;
    private AudioSource playerAudio;
    
    public bool gameOver = false;
    public float jumpForce = 10.0f;
    public float gravModifier = 1.0f;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip jump;
    public AudioClip crash;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravModifier;
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dirt.Stop();
            playerAudio.PlayOneShot(jump, 1.0f);
            isOnGround = false;
            anim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            dirt.Play();
            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            explosion.Play();
            playerAudio.PlayOneShot(crash, 1.0f);
            dirt.Stop();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
        }
    }
}