using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTier2Handler : MonoBehaviour
{
    private MoneyTest mT;

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
    }

    public void CheckInvestments(int i)
    {
        if (i == 4)
        {
            ThisButton.interactable = true;
            canInvest = true;
        }
    }

}
