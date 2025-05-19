using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ParametrosManager : MonoBehaviour
{
    public Slider sliderTiempo;
    public Slider sliderVertical;
    public Slider sliderHorizontal;
    public Toggle toggleOclusion;

    public void ComenzarJuego()
    {
        ParametrosJuego.tiempoBusqueda = sliderTiempo.value;
        ParametrosJuego.gemasVertical = Mathf.RoundToInt(sliderVertical.value);
        ParametrosJuego.gemasHorizontal = Mathf.RoundToInt(sliderHorizontal.value);
        ParametrosJuego.oclusion = toggleOclusion.isOn;

        SceneManager.LoadScene("Scene1"); 
    }
}
