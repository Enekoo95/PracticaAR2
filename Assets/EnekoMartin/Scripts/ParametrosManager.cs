using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ParametrosManager : MonoBehaviour
{
    public static ParametrosManager instance;

    public float tiempoBusqueda;
    public int gemasVertical;
    public int gemasHorizontal;
    public bool oclusionActiva;

    [Header("Referencias UI")]
    public Slider sliderTiempo;
    public Slider sliderGemasVertical;
    public Slider sliderGemasHorizontal;
    public Toggle toggleOclusion;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void LeerParametros()
    {
        tiempoBusqueda = sliderTiempo.value;
        gemasVertical = Mathf.RoundToInt(sliderGemasVertical.value);
        gemasHorizontal = Mathf.RoundToInt(sliderGemasHorizontal.value);
        oclusionActiva = toggleOclusion.isOn;

        // Cambia a la escena AR
        SceneManager.LoadScene("Scene1");
    }
}

public class SliderTextoUpdater : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI texto;

    public bool mostrarDecimal = false;

    private void Start()
    {
        slider.onValueChanged.AddListener(UpdateTexto);
        UpdateTexto(slider.value);
    }

    void UpdateTexto(float valor)
    {
        if (mostrarDecimal)
            texto.text = valor.ToString("0.0");
        else
            texto.text = Mathf.RoundToInt(valor).ToString();
    }
}
