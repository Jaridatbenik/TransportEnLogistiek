using System;
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

    private CheckIfInvested Ci_invest;

    private bool T2Finish;

    private Color blackGrey = new Color32(91, 91, 91, 255);

    private int InvestmentCost;

    private int PTT2;
    private int PTT3;

    public Button Tier2_Button;
    public Button Tier3_Button;
    public List<GameObject> T1_Investment_Buttons = new List<GameObject>();
    public List<GameObject> T2_Investment_Buttons = new List<GameObject>();
    public List<GameObject> T1_Investment_Line = new List<GameObject>();
    public List<GameObject> T2_Investment_Line = new List<GameObject>();
    public List<GameObject> Li_T3_Image = new List<GameObject>();
    #region money methods
    public void AddMoney()
    {
        Money += 100;
        MoneyText.text = Money.ToString();
        UpdateColor();
    }

    public void RemoveMoney()
    {
        Money -= InvestmentCost;
        MoneyText.text = Money.ToString();
        UpdateColor();
    }
    #endregion

    private void Start()
    {
        Tier2_Button.interactable = false;
        Tier2_Button.GetComponent<Image>().color = blackGrey;

        foreach (GameObject btn in T1_Investment_Buttons)
        {
            btn.GetComponent<Image>().color = Color.yellow;
        }

        foreach (GameObject im in T1_Investment_Line)
        {
            im.GetComponent<Image>().color = Color.yellow;
        }

        foreach (GameObject im in T2_Investment_Line)
        {
            im.GetComponent<Image>().color = blackGrey;
        }

    }

    public void UpdateColor()
    {
        if (Money >= InvestmentCost && PTT2 < 4)
        {
            foreach (GameObject btn in T1_Investment_Buttons)
            {
                Ci_invest = btn.GetComponent<CheckIfInvested>();
                if (!Ci_invest.Invested)
                {
                    btn.GetComponent<Image>().color = Color.yellow;
                }
                else
                {
                    continue;
                }
            }

            foreach (GameObject btn in T1_Investment_Line)
            {
                Ci_invest = btn.GetComponent<CheckIfInvested>();
                if (!Ci_invest.Invested)
                {
                    btn.GetComponent<Image>().color = Color.yellow;
                }
                else
                {
                    continue;
                }
            }
        }
        else if (Money < InvestmentCost && PTT2 < 4)
        {
            foreach (GameObject btn in T1_Investment_Buttons)
            {
                Ci_invest = btn.GetComponent<CheckIfInvested>();
                if (!Ci_invest.Invested)
                {
                    btn.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    continue;
                }
            }

            foreach (GameObject btn in T1_Investment_Line)
            {
                Ci_invest = btn.GetComponent<CheckIfInvested>();
                if (!Ci_invest.Invested)
                {
                    btn.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    continue;
                }
            }
        }

        if (PTT2 == 4)
        {
            Tier2_Button.interactable = true;
            InvestmentCost = Tier2_Button.GetComponent<CheckIfInvested>().InvestCost;
        }

        if (PTT2 == 4 && !T2Finish && Money >= InvestmentCost)
        {
            Tier2_Button.GetComponent<Image>().color = Color.yellow;
            foreach (GameObject img in T2_Investment_Line)
            {
                img.GetComponent<Image>().color = Color.yellow;
            }
        }
        else if (PTT2 == 4 && !T2Finish && Money < InvestmentCost)
        {
            Tier2_Button.GetComponent<Image>().color = Color.red;
            foreach (GameObject img in T2_Investment_Line)
            {
                img.GetComponent<Image>().color = Color.red;
            }
        }
    }

    public void InvestmentPressed(int i)
    {
        if (PTT2 < 4)
        {
            InvestmentCost = T1_Investment_Buttons[i].GetComponent<CheckIfInvested>().InvestCost;
            UpdateColor();
        }

        if (Money >= InvestmentCost && PTT2 < 4)
        {
            PTT2++;
            T1_Investment_Buttons[i].GetComponent<Button>().interactable = false;
            T1_Investment_Buttons[i].GetComponent<Image>().color = Color.green;
            T1_Investment_Buttons[i].GetComponent<CheckIfInvested>().Invested = true;
            T1_Investment_Line[i].GetComponent<Image>().color = Color.green;
            T1_Investment_Line[i].GetComponent<CheckIfInvested>().Invested = true;
            T2_Investment_Line[i].GetComponent<Image>().color = Color.yellow;
            RemoveMoney();
        }
        else if (Money >= InvestmentCost && PTT2 == 4)
        {
            Tier2_Button.interactable = false;
            Tier2_Button.GetComponent<Image>().color = Color.green;

            foreach (GameObject im in T2_Investment_Line)
            {
                im.GetComponent<Image>().color = Color.green;
            }

            T1_Investment_Buttons.Clear();
            T1_Investment_Line.Clear();
            T2_Investment_Line.Clear();

            T2Finish = true;
            RemoveMoney();
        }
    }
}
