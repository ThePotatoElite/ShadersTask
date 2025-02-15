using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalSettings : MonoBehaviour
{
    [SerializeField] private Material portalTwirlMat;
    [SerializeField] private Slider speed;
    [SerializeField] private Slider strength;
    [SerializeField] private Slider refraction;
    [SerializeField] private Slider scale;
    
    void Start()
    {
        speed.onValueChanged.AddListener(value => portalTwirlMat.SetFloat("_Speed", value));
        strength.onValueChanged.AddListener(value => portalTwirlMat.SetFloat("_Strength", value));
        refraction.onValueChanged.AddListener(value => portalTwirlMat.SetFloat("_Refraction", value));
        scale.onValueChanged.AddListener(value => portalTwirlMat.SetFloat("_Scale", value));
    }
}