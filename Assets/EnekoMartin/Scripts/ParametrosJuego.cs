using UnityEngine;

public static class ParametrosJuego
{
    public static int gemasVertical;
    public static int gemasHorizontal;
    public static float tiempoBusqueda;
    public static bool oclusion;

    public static int TotalGemas => gemasVertical + gemasHorizontal;
}
