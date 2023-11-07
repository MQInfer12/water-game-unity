using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Jugador"))
        {
            Player player = other.GetComponent<Player>();
            player.currentBullets = player.maxBullets;
        }
    }
}
