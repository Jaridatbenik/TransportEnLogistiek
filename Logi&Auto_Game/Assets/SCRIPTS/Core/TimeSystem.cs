using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    float currentTime = 0;
    public float timeSpeed = 2;

    int hours = 9;
    int minutes = 0;

    int days = 1;
    int months = 1;

    [SerializeField]List<int> monthDayAmount = new List<int>();

    [SerializeField]TextMeshProUGUI hour_min;
    [SerializeField]
    TextMeshProUGUI day_month;


    void Update()
    {
        currentTime += Time.fixedDeltaTime * timeSpeed;           

        if(currentTime >= 60)
        {
            currentTime = 0;
            minutes++;
        } 
        if(minutes >= 60)
        {
            minutes = 0;
            hours++;
        }
        if(hours >= 24)
        {
            hours = 0;
            days++;
        }
        if(days >= monthDayAmount[months])
        {
            months++;            
            days = 0;
        }
        if(months >= 12)
        {
            months = 0;
            print("YEAR");
        }

        string s_hours = AddZero(hours.ToString());
        string s_minutes = AddZero(minutes.ToString());
        string s_days = AddZero(days.ToString());
        string s_months = AddZero(months.ToString());


        hour_min.text = s_hours + ":" + s_minutes;
        day_month.text = s_days + "-" + s_months;
    }

    string AddZero(string s)
    {
        if (s.Length <= 1)
            s = "0" + s;
        return s;  
    }
}