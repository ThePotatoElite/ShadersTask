using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthSlider;
    public Renderer healthBarRenderer;
    
    private Material _healthBarMaterial;

    void Start()
    {
        if (healthBarRenderer != null)
        {
            _healthBarMaterial = healthBarRenderer.material;
        }
        
        if (_healthBarMaterial != null)
        {
            healthSlider.value = _healthBarMaterial.GetFloat("_Health");
        }
        
        healthSlider.onValueChanged.AddListener(UpdateHealthValue);
    }

    void UpdateHealthValue(float value)
    {
        if (_healthBarMaterial != null)
        {
            _healthBarMaterial.SetFloat("_Health", value);
        }
    }
}