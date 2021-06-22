﻿ 
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    void Start()
    {
        paddleToBallVector = transform.position-paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            lockBallToPaddle();
            launchOnMouseClick();
        }
       
    }

    private void lockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void launchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
           myRigidBody2D.velocity = new Vector2(xPush, yPush);
            hasStarted = true;

        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f,randomFactor), 
            Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
