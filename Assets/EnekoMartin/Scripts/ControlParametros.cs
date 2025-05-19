using UnityEngine;


public class ControlParametros : MonoBehaviour
{
    void Start()
    {
        int totalGemas = ParametrosJuego.TotalGemas;
        float tiempo = ParametrosJuego.tiempoBusqueda;
        bool usarOclusion = ParametrosJuego.oclusion;

        Debug.Log("Total gemas a generar: " + totalGemas);
        Debug.Log("Tiempo de búsqueda: " + tiempo);
        Debug.Log("¿Usar oclusión?: " + usarOclusion);
    }
}