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

    private bool T3Finish;

    public int InvestmentCost;

    private int PTT2;
    private int PTT3;

    #region Needed lists and buttons
    /// <summary>
    /// Dit zijn alle buttons en lists die er nodig zijn voor de research tree.
    /// </summary>
    public Button Tier2_Button;
    public Button Tier3_Button;
    public List<GameObject> T1_Investment_Buttons = new List<GameObject>();
    public List<GameObject> T2_Investment_Buttons = new List<GameObject>();
    public List<GameObject> First_Investment_Line = new List<GameObject>();
    public List<GameObject> Second_Investment_Line = new List<GameObject>();
    public List<GameObject> Third_Investment_Line = new List<GameObject>();
    public List<GameObject> Fourth_Investment_Line = new List<GameObject>();
#endregion

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
        InvestmentCost = 100;
        UpdateColor();
        
    }

    public void UpdateColor()
    {
        #region Tier 2 stuff

        if (!T2Finish)
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

                foreach (GameObject btn in First_Investment_Line)
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

                foreach (GameObject btn in First_Investment_Line)
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
                foreach (GameObject img in Second_Investment_Line)
                {
                    img.GetComponent<Image>().color = Color.yellow;
                }
            }
            else if (PTT2 == 4 && !T2Finish && Money < InvestmentCost)
            {
                Tier2_Button.GetComponent<Image>().color = Color.red;
                foreach (GameObject img in Second_Investment_Line)
                {
                    img.GetComponent<Image>().color = Color.red;
                }
            }
        }

        #endregion

        #region Tier 3 stuff
        if (T2Finish)
        {
            if (Money >= InvestmentCost && PTT3 < 4)
            {
                foreach (GameObject btn in T2_Investment_Buttons)
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

                foreach (GameObject btn in Third_Investment_Line)
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
            else if (Money < InvestmentCost && PTT3 < 4)
            {
                foreach (GameObject btn in T2_Investment_Buttons)
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

                foreach (GameObject btn in Third_Investment_Line)
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

            if (PTT3 == 4)
            {
                Tier3_Button.interactable = true;
                InvestmentCost = Tier3_Button.GetComponent<CheckIfInvested>().InvestCost;
            }

            if (PTT3 == 4 && !T3Finish && Money >= InvestmentCost)
            {
                Tier3_Button.GetComponent<Image>().color = Color.yellow;
                foreach (GameObject img in Fourth_Investment_Line)
                {
                    img.GetComponent<Image>().color = Color.yellow;
                }
            }
            else if (PTT3 == 4 && !T3Finish && Money < InvestmentCost)
            {
                Tier3_Button.GetComponent<Image>().color = Color.red;
                foreach (GameObject img in Fourth_Investment_Line)
                {
                    img.GetComponent<Image>().color = Color.red;
                }
            }
        }
        #endregion
    }

    public void InvestmentPressed(int i)
    {
        #region Tier 2 stuff
        if (!T2Finish)
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
                First_Investment_Line[i].GetComponent<Image>().color = Color.green;
                First_Investment_Line[i].GetComponent<CheckIfInvested>().Invested = true;
                Second_Investment_Line[i].GetComponent<Image>().color = Color.yellow;
                InvestBonusus(T1_Investment_Buttons[i].GetComponent<CheckIfInvested>().InvestTier, T1_Investment_Buttons[i].GetComponent<CheckIfInvested>().InvestName);
                RemoveMoney();
            }
            else if (Money >= InvestmentCost && PTT2 == 4)
            {
                Tier2_Button.interactable = false;
                Tier2_Button.GetComponent<Image>().color = Color.green;

                foreach (GameObject im in Second_Investment_Line)
                {
                    im.GetComponent<Image>().color = Color.green;
                }

                foreach (GameObject btn in T2_Investment_Buttons)
                {
                    btn.GetComponent<Button>().interactable = true;
                }

                InvestBonusus(Tier2_Button.GetComponent<CheckIfInvested>().InvestTier, Tier2_Button.GetComponent<CheckIfInvested>().InvestName);

                T2Finish = true;
                InvestmentCost = 200;
                RemoveMoney();
                return;
            }
        }
        #endregion

        #region Tier 3 stuff
        if (T2Finish)
        {
            if (PTT3 < 4)
            {
                InvestmentCost = T2_Investment_Buttons[i].GetComponent<CheckIfInvested>().InvestCost;
                UpdateColor();
            }

            if (Money >= InvestmentCost && PTT3 < 4)
            {
                PTT3++;
                T2_Investment_Buttons[i].GetComponent<Button>().interactable = false;
                T2_Investment_Buttons[i].GetComponent<Image>().color = Color.green;
                T2_Investment_Buttons[i].GetComponent<CheckIfInvested>().Invested = true;
                Third_Investment_Line[i].GetComponent<Image>().color = Color.green;
                Third_Investment_Line[i].GetComponent<CheckIfInvested>().Invested = true;
                Fourth_Investment_Line[i].GetComponent<Image>().color = Color.yellow;
                InvestBonusus(T2_Investment_Buttons[i].GetComponent<CheckIfInvested>().InvestTier, T2_Investment_Buttons[i].GetComponent<CheckIfInvested>().InvestName);
                RemoveMoney();
            }
            else if (Money >= InvestmentCost && PTT3 == 4)
            {
                Tier3_Button.interactable = false;
                Tier3_Button.GetComponent<Image>().color = Color.green;

                foreach (GameObject im in Fourth_Investment_Line)
                {
                    im.GetComponent<Image>().color = Color.green;
                }

                InvestBonusus(Tier3_Button.GetComponent<CheckIfInvested>().InvestTier, Tier3_Button.GetComponent<CheckIfInvested>().InvestName);

                T3Finish = true;
                RemoveMoney();
            }
        }
        #endregion
    }

    private void InvestBonusus(int Tier, string Subject)
    {
        #region Motor Upgrades
        if (Subject == "Motor")
        {
            if (Tier == 1)
            {
                Debug.Log("Motor 1");
            }
            else if (Tier == 2)
            {
                Debug.Log("Motor 2");
            }
            else if (Tier == 3)
            {
                Debug.Log("Motor 3");
            }
        }
        #endregion

        #region Chassis Upgrades
        if (Subject == "Chassis")
        {
            if (Tier == 1)
            {
                Debug.Log("Chassis 1");
            }
            else if (Tier == 2)
            {
                Debug.Log("Chassis 2");
            }
            else if (Tier == 3)
            {
                Debug.Log("Chassis 3");
            }
        }
        #endregion

        #region Uitlaat Upgrades
        
        if (Subject == "Uitlaat")
        {
            if (Tier == 1)
            {
                Debug.Log("Uitlaat 1");
            }
            else if (Tier == 2)
            {
                Debug.Log("Uitlaat 2");
            }
            else if (Tier == 3)
            {
                Debug.Log("Uitlaat 3");
            }
        }

        #endregion

        #region Versnelling Upgrades

        if (Subject == "Versnelling")
        {
            if (Tier == 1)
            {
                Debug.Log("Versnelling 1");
            }
            else if (Tier == 2)
            {
                Debug.Log("Versnelling 2");
            }
            else if (Tier == 3)
            {
                Debug.Log("Versnelling 3");
            }
        }

        #endregion

        #region Model Upgrades

        if (Subject == "Model")
        {
            if (Tier == 1)
            {
                Debug.Log("Model 1");
            }
            else if (Tier == 2)
            {
                Debug.Log("Model 2");
            }
            else if (Tier == 3)
            {
                Debug.Log("Model 3");
            }
        }

        #endregion
    }
}
