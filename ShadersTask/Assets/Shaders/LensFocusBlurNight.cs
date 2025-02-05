using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LensFocusBlurNight : MonoBehaviour
{
    [SerializeField] private Material fullscreenMat;
    [SerializeField] private Slider focusRadius;
    [SerializeField] private Slider blurStrength;
    [SerializeField] private Toggle nightVision;
    void Start()
    {
        focusRadius.onValueChanged.AddListener(value => fullscreenMat.SetFloat("_FocusRadius", value));
        blurStrength.onValueChanged.AddListener(value => fullscreenMat.SetFloat("_BlurStrength", value));
        nightVision.onValueChanged.AddListener(value =>
        {
            if (value)
            {
                fullscreenMat.SetFloat("_IsNightVision", 1f);
            }
            else
            {
                fullscreenMat.SetFloat("_IsNightVision", 0f);
            }
        });
    }
}