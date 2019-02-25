using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvesteringHandler : MonoBehaviour
{

    public InvesteringState investState;

    public enum InvesteringState
    {
        Done,
        CanInvest,
        CanInvestNoMoney,
        CantInvest
    }

    public void CheckEnumState()
    {
        Image im = GetComponent<Image>();
        Button btn = GetComponent<Button>();
        switch (investState)
        {
            case InvesteringState.Done:
                im.color = Color.green;
                btn.interactable = false;
                break;
            case InvesteringState.CanInvest:
                im.color = Color.yellow;
                break;
            case InvesteringState.CanInvestNoMoney:
                im.color = Color.red;
                break;
            case InvesteringState.CantInvest:
                im.color = Color.grey;
                btn.interactable = false;
                break;
        }
    }
}
