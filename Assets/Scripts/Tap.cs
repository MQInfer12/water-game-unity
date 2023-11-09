using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tap : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Jugador"))
        {
            Player player = other.GetComponent<Player>();
            player.currentBullets = player.maxBullets;
            textMesh.text = player.maxBullets.ToString();
        }
    }
}
