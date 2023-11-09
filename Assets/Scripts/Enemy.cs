using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    public TilemapManager tilemapManager;
    public int life = 3;
    public float invulnerabilityTime = 2.0f; // Tiempo de invulnerabilidad en segundos
    private bool isInvulnerable = false;
    private bool canBurn = true;
    Renderer enemyRenderer;
    public Sprite caughtSprite;
    [SerializeField] private TextMeshProUGUI textMesh;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        enemyRenderer = GetComponent<Renderer>();
        enemyRenderer.enabled = true;
    }

    private void Update()
    {
        Vector3 escapeDirection = transform.position - target.position;
        Vector3 targetPosition = transform.position + escapeDirection.normalized * 10f;
        agent.SetDestination(targetPosition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Three"))
        {
            if(canBurn) {
                Vector3 hitPosition = other.ClosestPoint(transform.position);
                Vector3Int tilePosition = tilemapManager.treeTilemap.WorldToCell(hitPosition);
                tilemapManager.PutOnFire(tilePosition);
            }
        }
        if(other.CompareTag("Jugador"))
        {
            if (!isInvulnerable)
            {
                life--;
                if(life >= 0) 
                {
                    textMesh.text = life.ToString();
                }
                if (life <= 0)
                {
                    isInvulnerable = true;
                    GetComponent<SpriteRenderer>().sprite = caughtSprite;
                    agent.speed = 0;
                    canBurn = false;
                    GameManager gameManager = FindObjectOfType<GameManager>();
                    gameManager.AtraparArsonista();
                }
                else
                {
                    isInvulnerable = true;
                    agent.speed *= 2;
                    StartCoroutine(InvulnerabilityBlink());
                }
            }
        }
    }

    private IEnumerator InvulnerabilityBlink()
    {
        isInvulnerable = true;
        float blinkDuration = 0.2f;
        float invulnerabilityTime = 2.0f;
        int blinkCount = Mathf.CeilToInt(invulnerabilityTime / (2 * blinkDuration));

        for (int i = 0; i < blinkCount; i++)
        {
            enemyRenderer.enabled = false;
            yield return new WaitForSeconds(blinkDuration);
            enemyRenderer.enabled = true;
            yield return new WaitForSeconds(blinkDuration);
        }

        isInvulnerable = false;
        enemyRenderer.enabled = true;
    }
}
