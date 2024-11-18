using UnityEngine.UI;
using UnityEngine;
using System;

public class PanelControlFog : MonoBehaviour
{
    public float Transparency, CountFog, SpeedFog;
    private string transparencyText, countFogText, speedFogText;

    public Material materialFog;
    public ParticleSystem parSys;

    void Start()
    {
        Color color = materialFog.GetColor("_TintColor");
        transparencyText = color.a.ToString();
        //Запис настоящих даних змінні
        OnReadTextInSystem();

        //Виведення змінних системи на екран
        PrintTextOnScreen();
    }
    public void ButtonNext(int id)
    {
        switch (id)
        {
            case 0: if (Transparency < 0.5f) Transparency += 0.011f; break;
            case 1: if (CountFog < 100) CountFog += 5f; break;
            case 2: if (SpeedFog < 10) SpeedFog += 0.5f; break;
        }
        OnRaitTextSheider();
        PrintTextOnScreen();
    }
    public void ButtonPrevius(int id)
    {
        switch (id)
        {
            case 0: if (Transparency > 0.01f) Transparency -= 0.01f; break;
            case 1: if (CountFog > 5) CountFog -= 5f; break;
            case 2: if (SpeedFog > 0.5) SpeedFog -= 0.5f; break;
        }
        OnRaitTextSheider();
        PrintTextOnScreen();
    }

    private void OnRaitTextSheider()
    {
        Color color = materialFog.GetColor("_TintColor");
        color.a = Transparency;
        materialFog.SetColor("_TintColor", color);
        parSys.startSpeed = SpeedFog;
        parSys.emissionRate = CountFog;
    }

    private void OnReadTextInSystem()
    {
        Color color = materialFog.GetColor("_TintColor");
        Transparency = color.a;
        CountFog = parSys.emissionRate;
        SpeedFog = parSys.startSpeed;
    }

    private void PrintTextOnScreen()
    {
        this.transform.GetChild(1).GetComponent<Text>().text = Math.Round(Transparency, 2).ToString();
        this.transform.GetChild(3).GetComponent<Text>().text = Math.Round(CountFog, 2).ToString();
        this.transform.GetChild(5).GetComponent<Text>().text = Math.Round(SpeedFog, 2).ToString();
    }
}
