using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvesteringHandler : MonoBehaviour
{
    #region money stuff
    public int Money;
    public Text MoneyText;
    #endregion

    private bool T2Finish;

    private Color blackGrey = new Color32(91, 91, 91, 255);

    public int PTT2;

    public Button Tier2_Button;
    public List<Button> Li_Button = new List<Button>();
    
    public List<Image> Li_T1_Image = new List<Image>();
    public List<Image> Li_T2_Image = new List<Image>();
    #region money methods
    public void AddMoney()
    {
        Money += 100;
        MoneyText.text = Money.ToString();
        UpdateColor(-1);
    }

    public void RemoveMoney()
    {
        Money -= 100;
        MoneyText.text = Money.ToString();
    }
    #endregion

    private void Start()
    {
        Tier2_Button.interactable = false;
        Tier2_Button.GetComponent<Image>().color = blackGrey;

        foreach (Button btn in Li_Button)
        {
            btn.GetComponent<Image>().color = Color.yellow;
        }

        foreach (Image im in Li_T1_Image)
        {
            im.color = Color.yellow;
        }

        foreach (Image im in Li_T2_Image)
        {
            im.color = blackGrey;
        }

    }

    public void UpdateColor(int i)
    {
        if (Money >= 100)
        {
            //verander de kleur van de image/button naar yellow wanneer je meer dan 100 money hebt maar de investment nog niet hebt gekocht.
            //zorg er voor dat je de kleur van de lijnen/buttons die nog niet beschikbaar zijn of in welke je al hebt geinvesteerd de kleur niet veranderd.
        }
        else if (Money < 100)
        {
            //verander de kleur van de image/button naar rood wanneer je niet meer dan 100 money hebt.
            //zorg er voor dat je de kleur van de lijnen/buttons die nog niet beschikbaar zijn.
        }

        if (PTT2 == 4 && !T2Finish)
        {
            Tier2_Button.interactable = true;
            Tier2_Button.GetComponent<Image>().color = Color.yellow;
        }
    }

    public void InvestmentPressed(int i)
    {
        if (Money >= 100 && PTT2 < 4)
        {
            PTT2++;

            Li_Button[i].interactable = false;
            Li_Button[i].GetComponent<Image>().color = Color.green;
            Li_T1_Image[i].color = Color.green;
            Li_T2_Image[i].color = Color.yellow;
            UpdateColor(i);
            RemoveMoney();
        }
        else if (Money >= 100 && PTT2 == 4)
        {
            Tier2_Button.interactable = false;
            Tier2_Button.GetComponent<Image>().color = Color.green;

            foreach (Image im in Li_T2_Image)
            {
                im.color = Color.green;
            }

            Li_Button.Clear();
            Li_T1_Image.Clear();
            Li_T2_Image.Clear();

            T2Finish = true;
            UpdateColor(i);
            RemoveMoney();

        }
    }
}
