using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shaders
{
    public class RotateLight : MonoBehaviour
    {
        [SerializeField] private Light directionalLight; 
        [SerializeField] private Slider rotationSlider;
        [SerializeField] private Toggle usePhong;
        [SerializeField] private Material toonShade;

        private void Start()
        {
            if (rotationSlider != null)
            {
                rotationSlider.minValue = 0;
                rotationSlider.maxValue = 360;
                rotationSlider.value = directionalLight.transform.eulerAngles.y;
                rotationSlider.onValueChanged.AddListener(UpdateLightRotation);
            }

            usePhong.onValueChanged.AddListener(value =>
            {
                if (value)
                    toonShade.SetFloat("_PhongOrNot", 1f);
                else
                    toonShade.SetFloat("_PhongOrNot", 0f);
            });

            rotationSlider.onValueChanged.AddListener(value =>
            {
                if (value != 0)
                    toonShade.SetFloat("_Lines", value/100);
            });
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