using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignController : MonoBehaviour
{
    public GameObject canvasPrefab;
    public void Appear(string text) {
        GameObject canvas = Instantiate(canvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        TextMeshProUGUI textMesh = canvas.GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = text;
    }
}
