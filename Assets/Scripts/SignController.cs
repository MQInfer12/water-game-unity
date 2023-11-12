using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SignController : MonoBehaviour
{
    public GameObject canvasPrefab;
    [SerializeField] private Sprite mision;
    [SerializeField] private Sprite ganaste;
    [SerializeField] private Sprite perdiste;
    [SerializeField] private Sprite apaga;

    public void Appear(string text) {
        GameObject canvas = Instantiate(canvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Image image = canvas.GetComponentInChildren<Image>();
        switch (text)
        {
            case "Salvaste el Tunari":
                image.sprite = ganaste;
                break;
            case "Apaga el fuego":
                image.sprite = apaga;
                break;
            case "Se quemó el Tunari :(":
                image.sprite = perdiste;
                break;
            case "Atrapa al arsonista":
                image.sprite = mision;
                break;
        }
    }
}
