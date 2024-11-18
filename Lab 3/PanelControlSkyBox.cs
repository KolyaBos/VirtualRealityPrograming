using UnityEngine.UI;
using UnityEngine;
using System;

public class PanelControlSkyBox : MonoBehaviour
{
    public float SunSize, AtmosphereThickness, Exposure;
    public string sunSizeText, AtmosphereThicknessText, exposureText;

    public Material material;
    void Start()
    {
        //ініціалізація змінних
        sunSizeText = material.GetFloat("_SunSize").ToString();
        AtmosphereThicknessText = material.GetFloat("_AtmosphereThickness").ToString();
        exposureText = material.GetFloat("_Exposure").ToString();

        //Запис настоящих даних змінні
        OnReadTextInSystem();

        //Виведення змінних системи на екран
        PrintTextOnScreen();
    }
    public void ButtonNext(int id){
        switch (id){
            case 0: if (SunSize < 1) SunSize += 0.05f; break;
            case 1: if (AtmosphereThickness < 10) AtmosphereThickness += 0.1f; break;
            case 2: if (Exposure < 8) Exposure += 0.1f; break;
        }
        OnRaitTextSheider();
        PrintTextOnScreen();
    }
    public void ButtonPrevius(int id)
    {
        switch (id)
        {
            case 0: if (SunSize > 0) SunSize -= 0.05f; break;
            case 1: if (AtmosphereThickness > 0) AtmosphereThickness -= 0.1f; break;
            case 2: if (Exposure > 0) Exposure -= 0.1f; break;
        }
        OnRaitTextSheider();
        PrintTextOnScreen();
    }

    private void OnRaitTextSheider()
    {
        material.SetFloat("_SunSize", SunSize);
        material.SetFloat("_AtmosphereThickness", AtmosphereThickness);
        material.SetFloat("_Exposure", Exposure);
    }

    private void OnReadTextInSystem()
    {
        SunSize = material.GetFloat("_SunSize");
        AtmosphereThickness = material.GetFloat("_AtmosphereThickness");
        Exposure = material.GetFloat("_Exposure");
    }

    private void PrintTextOnScreen()
    {
        this.transform.GetChild(1).GetComponent<Text>().text = Math.Round(SunSize, 2).ToString();
        this.transform.GetChild(3).GetComponent<Text>().text = Math.Round(AtmosphereThickness, 2).ToString();
        this.transform.GetChild(5).GetComponent<Text>().text = Math.Round(Exposure, 2).ToString();
    }
}
