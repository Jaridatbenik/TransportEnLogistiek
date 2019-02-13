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
    Color baseColor;
    [SerializeField]Color homeHourColor = Color.red;

    //work
    Vector2 workhours = new Vector2(9, 17);
    bool working = false;

    void Start()
    {
        baseColor = hour_min.color;    
    }

    void FixedUpdate()
    {
        AddTime();
        SetText();
        WorkHourDetection();
    }

    void AddTime()
    {
        currentTime += timeSpeed;

        if (currentTime >= 60)
        {
            currentTime = 0;
            minutes++;
        }
        if (minutes >= 60)
        {
            minutes = 0;
            hours++;
        }
        if (hours >= 24)
        {
            hours = 0;
            days++;
        }
        if (days >= monthDayAmount[months])
        {
            months++;
            days = 0;
        }
        if (months >= 12)
        {
            months = 0;
            print("YEAR");
        }
    }

    void SetText()
    {
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


    void WorkHourDetection()
    {
        if(hours == 9 && !working)
        {
            StartWorking();
        }
        else if(hours == 17 && working)
        {
            StopWorking();
        }
    }

    void StartWorking()
    {
        working = true;
        hour_min.color = baseColor;
    }
    void StopWorking()
    {
        working = false;
        hour_min.color = homeHourColor;
    }
}