using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTest : MonoBehaviour
{
    public int Money;

    public Text MoneyText;

    public void AddMoney()
    {
        Money += 100;
        MoneyText.text = Money.ToString();
    }

    public void RemoveMoney()
    {
        Money -= 100;
        MoneyText.text = Money.ToString();
    }

}
