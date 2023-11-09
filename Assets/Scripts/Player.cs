using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private Vector2 facingDirection;

    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;

    public int maxBullets = 6;
    public int currentBullets = 6;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;
        if (playerDirection != Vector2.zero)
        {
            facingDirection = playerDirection;
            if (directionX > 0)
                GetComponent<SpriteRenderer>().sprite = rightSprite;
            else if (directionX < 0) 
                GetComponent<SpriteRenderer>().sprite = leftSprite;
            else if (directionY > 0)
                GetComponent<SpriteRenderer>().sprite = upSprite;
            else if (directionY < 0)
                GetComponent<SpriteRenderer>().sprite = downSprite;
        }
    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector2(playerDirection.x * speed, playerDirection.y * speed);
    }

    public Vector2 GetFacingDirection()
    {
        return facingDirection;
    }
}
