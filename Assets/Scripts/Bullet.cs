using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Vector2 direction;
    public float maxRange = 6.0f;
    private float currentRange = 0.0f;
    [SerializeField] private GameObject destroyEffect;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upLeftSprite;
    public Sprite upRightSprite;
    public Sprite downLeftSprite;
    public Sprite downRightSprite;

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;

        if (newDirection == Vector2.up)
            GetComponent<SpriteRenderer>().sprite = upSprite;
        else if (newDirection == Vector2.down)
            GetComponent<SpriteRenderer>().sprite = downSprite;
        else if (newDirection == Vector2.left)
            GetComponent<SpriteRenderer>().sprite = leftSprite;
        else if (newDirection == Vector2.right)
            GetComponent<SpriteRenderer>().sprite = rightSprite;
        else if (newDirection == (Vector2.up + Vector2.left).normalized)
            GetComponent<SpriteRenderer>().sprite = upLeftSprite;
        else if (newDirection == (Vector2.up + Vector2.right).normalized)
            GetComponent<SpriteRenderer>().sprite = upRightSprite;
        else if (newDirection == (Vector2.down + Vector2.left).normalized)
            GetComponent<SpriteRenderer>().sprite = downLeftSprite;
        else if (newDirection == (Vector2.down + Vector2.right).normalized)
            GetComponent<SpriteRenderer>().sprite = downRightSprite;
    }

    private void Update()
    {
        float distance = speed * Time.deltaTime;
        currentRange += distance;
        transform.Translate(direction * distance);
        if(currentRange >= maxRange) {
            Dissapear();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            TilemapManager tilemapManager = FindObjectOfType<TilemapManager>();
            if(tilemapManager != null) {
                tilemapManager.PutOffFire(transform.position);
                int contador = tilemapManager.FireCount();
                if(contador == 0) {
                    GameManager gameManager = FindObjectOfType<GameManager>();
                    gameManager.FuegoApagado();
                }
            }
            Dissapear();
        }
        if(other.CompareTag("Three")) 
        {
            Dissapear();
        }
    }

    private void Dissapear() 
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
