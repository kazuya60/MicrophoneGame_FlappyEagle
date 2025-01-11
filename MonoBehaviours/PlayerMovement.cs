using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float minForce = 0f;
    [SerializeField] private float maxForce = 100.0f;
    [SerializeField] private float sensitivity = 100.0f;
    private MainAudioInputController audioController;
    public float gravityModifier = 2;
    private float loudness;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.FindObjectOfType<MainAudioInputController>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
        rb.AddForce(Vector3.up * 20f, ForceMode.Impulse);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("Hit", true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isFlying", true);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isFlying", false);
        }
    }

    void Update()
    {
        if (GameManager.instance.player.IsDead())
        {
            animator.SetBool("isFlying",false);
            animator.SetBool("isDead", true);
            return;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.player.IsDead()) return;
        loudness = Mathf.Clamp01(audioController.Loudness);
        float force = Mathf.Lerp(minForce, maxForce, loudness);
        rb.AddForce(Vector3.up * force * sensitivity, ForceMode.Acceleration);
    }
}
