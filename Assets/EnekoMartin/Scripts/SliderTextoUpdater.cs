using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderTextoUpdater : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI texto;
    public bool mostrarDecimal = false;

    private void Start()
    {
        if (slider == null || texto == null)
        {
            Debug.LogError("Faltan referencias en " + gameObject.name);
            return;
        }

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
