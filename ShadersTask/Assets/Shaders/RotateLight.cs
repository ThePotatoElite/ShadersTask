using UnityEngine;
using UnityEngine.UI;

namespace Shaders
{
    public class RotateLight : MonoBehaviour
    {
        [SerializeField] private Light directionalLight; 
        [SerializeField] private Slider rotationSlider;

        private void Start()
        {
            if (rotationSlider != null)
            {
                rotationSlider.minValue = 0;
                rotationSlider.maxValue = 360;
                rotationSlider.value = directionalLight.transform.eulerAngles.y;
                rotationSlider.onValueChanged.AddListener(UpdateLightRotation);
            }
        }

        private void UpdateLightRotation(float value)
        {
            if (directionalLight != null)
            {
                Vector3 currentRotation = directionalLight.transform.eulerAngles;
                directionalLight.transform.eulerAngles = new Vector3(currentRotation.x, value, currentRotation.z);
            }
        }

        private void OnDestroy()
        {
            if (rotationSlider != null)
            {
                rotationSlider.onValueChanged.RemoveListener(UpdateLightRotation);
            }
        }
    }
}