using UnityEngine;


public class ControlParametros : MonoBehaviour
{
    void Start()
    {
        int totalGemas = ParametrosJuego.TotalGemas;
        float tiempo = ParametrosJuego.tiempoBusqueda;
        bool usarOclusion = ParametrosJuego.oclusion;

        Debug.Log("Total gemas a generar: " + totalGemas);
        Debug.Log("Tiempo de b�squeda: " + tiempo);
        Debug.Log("�Usar oclusi�n?: " + usarOclusion);
    }
}