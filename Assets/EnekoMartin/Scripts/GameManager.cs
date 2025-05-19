using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gemaPrefab;
    public TextMeshProUGUI textoContador;
    public TextMeshProUGUI textoTiempo;
    public GameObject panelInicioJuego;
    public DeteccionDePlanos detectorDePlanos;

    private float tiempoRestante;
    private int gemasRecogidas = 0;
    private int totalGemas;
    private bool juegoActivo = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        tiempoRestante = ParametrosJuego.tiempoBusqueda;
        totalGemas = ParametrosJuego.TotalGemas;
        textoContador.text = $"0 / {totalGemas}";
        textoTiempo.text = $"{tiempoRestante:0}s";
    }

    public void ComenzarJuego(List<ARPlane> planosDetectados)
    {
        panelInicioJuego.SetActive(false);
        InstanciarGemas(planosDetectados);
        juegoActivo = true;
        StartCoroutine(ContadorTiempo());
    }

    void InstanciarGemas(List<ARPlane> planos)
    {
        int gemasColocadas = 0;

        foreach (ARPlane plano in planos)
        {
            if (gemasColocadas >= totalGemas)
                break;

            Vector3 pos = plano.center;
            Vector3 offset = new Vector3(Random.Range(-0.3f, 0.3f), 0.05f, Random.Range(-0.3f, 0.3f));
            Instantiate(gemaPrefab, pos + offset, Quaternion.identity);
            gemasColocadas++;
        }
    }

    IEnumerator ContadorTiempo()
    {
        while (tiempoRestante > 0 && gemasRecogidas < totalGemas)
        {
            yield return new WaitForSeconds(1f);
            tiempoRestante--;
            textoTiempo.text = $"{tiempoRestante:0}s";
        }

        juegoActivo = false;
        FinDelJuego();
    }

    public void RecogerGema(GameObject gema)
    {
        if (!juegoActivo) return;

        Destroy(gema);
        gemasRecogidas++;
        textoContador.text = $"{gemasRecogidas} / {totalGemas}";

        if (gemasRecogidas >= totalGemas)
        {
            juegoActivo = false;
            FinDelJuego();
        }
    }
    public void BotonIniciarJuego()
    {
        List<ARPlane> planos = detectorDePlanos.ObtenerPlanosValidos();
        ComenzarJuego(planos);
    }

    void FinDelJuego()
    {
        // Mostrar panel de fin, ir a otra escena o mostrar mensaje
        Debug.Log("Juego terminado");
    }
}
