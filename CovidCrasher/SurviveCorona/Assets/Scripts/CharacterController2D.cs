using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class CharacterController2D : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public float smoothSpeed = 0.3f;
    public Camera mainCamera;

    public SFXScript sfx;

    public Joystick joystick;
    public Animator animator;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    public Vector3 offset;
    Rigidbody2D r2d;
    Collider2D mainCollider;
    // Check every collider except Player and Ignore Raycast
    LayerMask layerMask = ~(1 << 2 | 1 << 8);
    Transform t;

    // Use this for initialization
    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<Collider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        gameObject.layer = 8;

        if (mainCamera)
            cameraPos = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (joystick.Horizontal >= .2f)
        {
            moveDirection = 1;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            moveDirection = -1;
        }
        else
        {
            moveDirection = 0;
        }*/

        moveDirection = Input.GetAxisRaw("Horizontal");

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Jumping
        if (/*joystick.Vertical >= .5 && isGrounded*/ Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            sfx.JumpSoundPlay();
        }

        //Attack with keyboard buttons
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<SwordAttack>().Attack();
            sfx.SwordSwingPlay();
        }
}

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, 0.1f, 0);
        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, 0.23f, layerMask);

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
        if(r2d.velocity.x > 0 || r2d.velocity.x <0)
        {
            if (!sfx.moveSound.isPlaying)
                sfx.moveSound.Play();
        }
        else
        {
            sfx.moveSound.Stop();
        }

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, 0.23f, 0), isGrounded ? Color.green : Color.red);

        /* Camera follow
        Vector3 desiredPosition = t.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(mainCamera.transform.position, desiredPosition, smoothSpeed);
        mainCamera.transform.position = smoothedPosition;*/
    }
}