using UnityEngine.UI;
using UnityEngine;
using System;

public class PanelControlWater : MonoBehaviour
{
    public float WaterLerp, NormalStrength, Refraction, Lerp;
    private string waterLerpText, normalStrengthText, refractionText, lerpText;

    public GameObject Water;
    private Material material;
    void Start()
    {
        //ініціалізація змінних
        material = Water.GetComponent<Renderer>().material;
        Debug.Log(material.GetFloat("_Water_Lerp").ToString());
        waterLerpText = material.GetFloat("_Water_Lerp").ToString();
        normalStrengthText = material.GetFloat("_Normal_Strength").ToString();
        refractionText = material.GetFloat("_Refraction").ToString();
        lerpText = material.GetFloat("_Lerp").ToString();

        //Запис настоящих даних змінні
        OnReadTextInSystem();

        //Виведення змінних системи на екран
        PrintTextOnScreen();
    }
    public void ButtonNext(int id){
        switch (id){
            case 0: if (WaterLerp < 1) WaterLerp += 0.05f; break;
            case 1: if (NormalStrength < 2)NormalStrength += 0.05f; break;
            case 2: if (Refraction < 2) Refraction += 0.05f; break;
            case 3: if (Lerp < 1)Lerp += 0.05f; break;
        }
        OnRaitTextSheider();
        PrintTextOnScreen();
    }
    public void ButtonPrevius(int id)
    {
        switch (id)
        {
            case 0: if (WaterLerp > 0) WaterLerp -= 0.05f; break;
            case 1: if (NormalStrength > 0) NormalStrength -= 0.05f; break;
            case 2: if (Refraction > 0) Refraction -= 0.05f; break;
            case 3: if (Lerp > 0) Lerp -= 0.05f; break;
        }
        OnRaitTextSheider();
        PrintTextOnScreen();
    }

    private void OnRaitTextSheider()
    {
        material.SetFloat("_Water_Lerp", WaterLerp);
        material.SetFloat("_Normal_Strength", NormalStrength);
        material.SetFloat("_Refraction", Refraction);
        material.SetFloat("_Lerp", Lerp);
    }

    private void OnReadTextInSystem()
    {
        WaterLerp = material.GetFloat("_Water_Lerp");
        NormalStrength = material.GetFloat("_Normal_Strength");
        Refraction = material.GetFloat("_Refraction");
        Lerp = material.GetFloat("_Lerp");
    }

    private void PrintTextOnScreen()
    {
        this.transform.GetChild(1).GetComponent<Text>().text = WaterLerp.ToString();
        this.transform.GetChild(3).GetComponent<Text>().text = NormalStrength.ToString();
        this.transform.GetChild(5).GetComponent<Text>().text = Refraction.ToString();
        this.transform.GetChild(7).GetComponent<Text>().text = Lerp.ToString();
    }
}
