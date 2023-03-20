using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount;
    public ProjectileBehavior ProjectilePrefab;
    public Transform LaunchOffset;
    public bool diamondPickedUp = false;
    public float timer;
    public float cooldown;

    private Rigidbody2D rb;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        jumpCount = maxJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        Animate();

        ProjectileFire();

        timer += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }
        Move();
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
    }
    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpCount--;
            isJumping = true;
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
        
    }
    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
    }
    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    // Increase Speed
    IEnumerator PowerUpSpeed()
    {
        moveSpeed = 9;
        yield return new WaitForSeconds(5);
        moveSpeed = 5;
    }

    public void SpeedPowerUp()
    {
        StartCoroutine(PowerUpSpeed());
    }
    public void ProjectileFire()
    {
        if (Input.GetButtonDown("Fire1") && diamondPickedUp && timer > cooldown)
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            timer = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = col.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerDetectionZone")
        {
            // move player to new position
        }
    }
    public IEnumerator PowerUpJump()
    {
        jumpForce = 1000;
        yield return new WaitForSeconds(5);
        jumpForce = 250;
    }
    public void JumpPowerUp()
    {
        StartCoroutine(PowerUpJump());
    }
}
