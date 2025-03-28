using UnityEngine;
using UnityEngine.Audio;

public class FlappyCatController : MonoBehaviour
{
    public float jumpForce = 8f;
    public Sprite idleSprite;
    public Sprite jumpSprite;
    public AudioClip flapSound;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = idleSprite;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpForce;

            if (flapSound != null)
            {
                AudioManager.instance.PlaySound(flapSound);
            }

            spriteRenderer.sprite = jumpSprite;
        }
        else
        {
            if (rb.linearVelocity.y <= 0f)
            {
                spriteRenderer.sprite = idleSprite;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}
