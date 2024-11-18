using UnityEngine.UI;
using UnityEngine;
using System;

public class PanelControlCoulds : MonoBehaviour
{
    public float Transparency, CountClouds, SpeedClouds ;
    private string transparencyText, countCloudsText , speedCloudsText;

    public Material materialCloud;
    public ParticleSystem parSys;

    void Start()
    {
        Color color = materialCloud.GetColor("_TintColor");
        transparencyText = color.a.ToString();
        //Запис настоящих даних змінні
        OnReadTextInSystem();

        //Виведення змінних системи на екран
        PrintTextOnScreen();

        Debug.Log("parSys.startSpeed - "+ parSys.startSpeed);
    }
    public void ButtonNext(int id)
    {
        switch (id)
        {
            case 0: if (Transparency < 0.95f) Transparency += 0.05f; break;
            case 1: if (CountClouds < 200) CountClouds += 5f; break;
            case 2: if (SpeedClouds < 40) SpeedClouds += 1f; break;
        }
        OnRaitTextSheider();
        PrintTextOnScreen();
    }
    public void ButtonPrevius(int id)
    {
        switch (id)
        {
            case 0: if (Transparency > 0.05f) Transparency -= 0.05f; break;
            case 1: if (CountClouds > 5) CountClouds -= 5f; break;
            case 2: if (SpeedClouds > 0) SpeedClouds -= 1f; break;
        }
        OnRaitTextSheider();
        PrintTextOnScreen();
    }

    private void OnRaitTextSheider()
    {
        Color color = materialCloud.GetColor("_TintColor");
        color.a = Transparency;
        materialCloud.SetColor("_TintColor", color);
        parSys.startSpeed = SpeedClouds;
        parSys.emissionRate = CountClouds;
    }

    private void OnReadTextInSystem()
    {
        Color color = materialCloud.GetColor("_TintColor");
        Transparency = color.a;
        CountClouds = parSys.emissionRate;
        SpeedClouds = parSys.startSpeed;
    }

    private void PrintTextOnScreen()
    {
        this.transform.GetChild(1).GetComponent<Text>().text = Math.Round(Transparency, 2).ToString();
        this.transform.GetChild(3).GetComponent<Text>().text = Math.Round(CountClouds, 2).ToString();
        this.transform.GetChild(5).GetComponent<Text>().text = Math.Round(SpeedClouds, 2).ToString();
    }
}
