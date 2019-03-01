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

    public int PTT2;

    public Button Tier2_Button;
    public List<GameObject> Li_Button = new List<GameObject>();
    
    public List<GameObject> Li_T1_Image = new List<GameObject>();
    public List<GameObject> Li_T2_Image = new List<GameObject>();
    #region money methods
    public void AddMoney()
    {
        Money += 100;
        MoneyText.text = Money.ToString();
        UpdateColor();
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

        foreach (GameObject btn in Li_Button)
        {
            btn.GetComponent<Image>().color = Color.yellow;
        }

        foreach (GameObject im in Li_T1_Image)
        {
            im.GetComponent<Image>().color = Color.yellow;
        }

        foreach (GameObject im in Li_T2_Image)
        {
            im.GetComponent<Image>().color = blackGrey;
        }

    }

    public void UpdateColor()
    {
        if (Money >= 150)
        {
            foreach (GameObject btn in Li_Button)
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

            foreach (GameObject btn in Li_T1_Image)
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
        else if (Money < 100)
        {
            foreach (GameObject btn in Li_Button)
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

            foreach (GameObject btn in Li_T1_Image)
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
        }

        if (PTT2 == 4 && !T2Finish && Money >= 150)
        {
            Tier2_Button.GetComponent<Image>().color = Color.yellow;
            foreach (GameObject img in Li_T2_Image)
            {
                img.GetComponent<Image>().color = Color.yellow;
            }
        }
        else if (PTT2 == 4 && !T2Finish && Money < 150)
        {
            Tier2_Button.GetComponent<Image>().color = Color.red;
            foreach (GameObject img in Li_T2_Image)
            {
                img.GetComponent<Image>().color = Color.red;
            }
        }
    }

    public void InvestmentPressed(int i)
    {
        if (Money >= 100 && PTT2 < 4)
        {
            PTT2++;

            Li_Button[i].GetComponent<Button>().interactable = false;
            Li_Button[i].GetComponent<Image>().color = Color.green;
            Li_Button[i].GetComponent<CheckIfInvested>().Invested = true;
            Li_T1_Image[i].GetComponent<Image>().color = Color.green;
            Li_T1_Image[i].GetComponent<CheckIfInvested>().Invested = true;
            Li_T2_Image[i].GetComponent<Image>().color = Color.yellow;
            RemoveMoney();
            UpdateColor();
        }
        else if (Money >= 100 && PTT2 == 4)
        {
            Tier2_Button.interactable = false;
            Tier2_Button.GetComponent<Image>().color = Color.green;

            foreach (GameObject im in Li_T2_Image)
            {
                im.GetComponent<Image>().color = Color.green;
            }

            Li_Button.Clear();
            Li_T1_Image.Clear();
            Li_T2_Image.Clear();

            T2Finish = true;
            UpdateColor();
            RemoveMoney();

        }
    }
}
