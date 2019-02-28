using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTier2Handler : MonoBehaviour
{
    private MoneyTest mT;

    public Image[] lines;

    public Image ButtonImage;
    public Button ThisButton;

    public int AmountOfInvestments;

    private bool invested;

    private bool canInvest;

    private void Start()
    {
        mT = FindObjectOfType<MoneyTest>();
        ButtonImage.color = Color.grey;
        ThisButton.interactable = false;
        foreach (Image line in lines)
        {
            line.color = Color.gray;
        }
    }

    private void Update()
    {
        if (canInvest)
        {
            if (mT.Money >= 100 && !invested)
            {
                ButtonImage.color = Color.yellow;
            }
            else if (mT.Money < 100 && !invested)
            {
                ButtonImage.color = Color.red;
            }
        }

        if (AmountOfInvestments == 4)
        {
            ThisButton.interactable = true;
            canInvest = true;
        }
    }

    public void CheckInvestments()
    {
        if (mT.Money >= 100)
        {
            foreach (Image line in lines)
            {
                line.color = Color.green;
            }

            mT.RemoveMoney();
            invested = true;
            ButtonImage.color = Color.green;
            ThisButton.interactable = false;
        }
    }

}
