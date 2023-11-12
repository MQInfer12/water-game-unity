using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool arsonistaAtrapado = false;
    private bool fuegoApagado = false;
    private bool cartelFinalMostrado = false;
    private float tiempoRestante = 60f;
    private bool contadorActivo = false;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private Image image;
    [SerializeField] private Sprite reloj;

    void Start()
    {
        SignController signController = FindObjectOfType<SignController>();
        signController.Appear("Atrapa al arsonista");
    }

    IEnumerator ContadorTiempo()
    {
        contadorActivo = true;

        while (tiempoRestante > 0f && contadorActivo)
        {
            yield return new WaitForSeconds(1f);
            tiempoRestante -= 1f;
            textMesh.text = tiempoRestante.ToString();
            image.sprite = reloj;
        }
        if(contadorActivo) {
            TiempoTerminado();
        }
    }

    IEnumerator MostrarPerder()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(3);
    }

    IEnumerator MostrarGanar()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(5);
    }

    void TiempoTerminado()
    {
        SignController signController = FindObjectOfType<SignController>();
        signController.Appear("Se quemó el Tunari :(");
        StartCoroutine(MostrarPerder());
    }

    public void AtraparArsonista()
    {
        arsonistaAtrapado = true;
        SignController signController = FindObjectOfType<SignController>();
        signController.Appear("Apaga el fuego");
        StartCoroutine(ContadorTiempo());
    }

    public void FuegoApagado()
    {
        fuegoApagado = true;
    }

    void Update()
    {
        if(arsonistaAtrapado && fuegoApagado && !cartelFinalMostrado) 
        {
            SignController signController = FindObjectOfType<SignController>();
            signController.Appear("Salvaste el Tunari");
            cartelFinalMostrado = true;
            contadorActivo = false;
            StartCoroutine(MostrarGanar());
        }
    }
}
