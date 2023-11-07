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

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
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
            Tilemap tilemap = other.GetComponent<Tilemap>();
            if (tilemap != null)
            {
                Vector3 hitPosition = tilemap.WorldToCell(transform.position);
                Vector3Int cellPosition = new Vector3Int((int)hitPosition.x, (int)hitPosition.y, 0);
                tilemap.SetTile(cellPosition, null);
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
        Destroy(gameObject);
    }
}
