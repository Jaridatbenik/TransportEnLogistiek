using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private ButtonTier2Handler bt2h;
    private MoneyTest mT;
    public Image Tier1Line;
    public Image Tier2Line;
    public Image ButtonImage;

    public Button ThisButton;

    private bool invested = false;

    private void Start()
    {
        mT = FindObjectOfType<MoneyTest>();
        bt2h = FindObjectOfType<ButtonTier2Handler>();
    }

    private void Update()
    {
        if (mT.Money >= 100 && !invested)
        {
            Tier1Line.color = Color.yellow;
            ButtonImage.color = Color.yellow;
        }
        else if(mT.Money < 100 && !invested)
        {
            Tier1Line.color = Color.red;
            ButtonImage.color = Color.red;
        }
    }

    public void BuyInvestment()
    {
        if (mT.Money >= 100)
        {
            invested = true;
            mT.RemoveMoney();
            Tier1Line.color = Color.green;
            Tier2Line.color = Color.yellow;
            ButtonImage.color = Color.green;
            ThisButton.interactable = false;
            bt2h.AmountOfInvestments++;
        }
    }   
}
