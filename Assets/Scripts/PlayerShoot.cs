using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform shootController;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private TextMeshProUGUI textMesh;
    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if(player.currentBullets > 0) {
            Vector2 shootingDirection = player.GetFacingDirection();
            if(shootingDirection != Vector2.zero) {
                GameObject newBullet = Instantiate(bulletPrefab, shootController.position, Quaternion.identity);
                Bullet bullet = newBullet.GetComponent<Bullet>();
                bullet.SetDirection(shootingDirection);
                player.currentBullets--;
                textMesh.text = player.currentBullets.ToString();
            }
        }
    }
}
