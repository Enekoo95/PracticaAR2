using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class DeteccionDePlanos : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public TextMeshProUGUI textoConteo; // Puedes usar TextMeshProUGUI si prefieres
    public GameObject botonComenzar;

    private int planosVerticalesDetectados = 0;
    private int planosHorizontalesDetectados = 0;

    private HashSet<ARPlane> planosDetectados = new HashSet<ARPlane>();

    void Start()
    {
        botonComenzar.SetActive(false);
    }

    void Update()
    {
        planosVerticalesDetectados = 0;
        planosHorizontalesDetectados = 0;

        planosDetectados.Clear();

        foreach (var plano in planeManager.trackables)
        {
            if (plano.trackingState != UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
                continue;

            planosDetectados.Add(plano);

            if (plano.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.Vertical)
                planosVerticalesDetectados++;
            else if (plano.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalUp)
                planosHorizontalesDetectados++;
        }

        textoConteo.text = $"Vertical {planosVerticalesDetectados}/{ParametrosJuego.gemasVertical} " +
                           $"Horizontal {planosHorizontalesDetectados}/{ParametrosJuego.gemasHorizontal}";

        if (planosVerticalesDetectados >= ParametrosJuego.gemasVertical &&
            planosHorizontalesDetectados >= ParametrosJuego.gemasHorizontal)
        {
            botonComenzar.SetActive(true);
        }
        else
        {
            botonComenzar.SetActive(false);
        }
    }

    public List<ARPlane> ObtenerPlanosValidos()
    {
        return new List<ARPlane>(planosDetectados);
    }
}
