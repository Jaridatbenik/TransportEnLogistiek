using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    float currentTime = 0;
    public float timeSpeed = 60;
    [SerializeField]
    List<float> extraMultiplier = new List<float>();
    [SerializeField]
    TextMeshProUGUI multiplierText = null;
    int currentIndex = 0;

    int hours = 9;
    int minutes = 0;

    int days = 1;
    int months = 1;

    [SerializeField]
    List<int> monthDayAmount = new List<int>();

    [SerializeField]
    TextMeshProUGUI hour_min = null;
    [SerializeField]
    TextMeshProUGUI day_month = null;
    Color baseColor;
    [SerializeField]
    Color homeHourColor = Color.red;

    //work
    Vector2 workhours = new Vector2(9, 17);
    bool working = false;

    void Start()
    {
        baseColor = hour_min.color;
        multiplierText.text = (currentIndex + 1) + "x";
    }

    void Update()
    {
        AddTime();
        SetText();
        WorkHourDetection();
    }

    void AddTime()
    {
        if(currentIndex < extraMultiplier.Count)
            currentTime += timeSpeed * extraMultiplier[currentIndex];

        int minIncrement = Mathf.RoundToInt(currentTime / 60);
        if (minIncrement > 0)
        {
            minutes += minIncrement;
            currentTime = 0;
        }
        int hourIncrement = Mathf.RoundToInt(minutes / 60);
        if (hourIncrement > 0)
        {
            hours += hourIncrement;
            minutes = 0;
        }
        int dayIncrement = Mathf.RoundToInt(hours / 24);
        if (dayIncrement > 0)
        {
            days += dayIncrement;
            hours = 0;
        }
        int monthIncrement = Mathf.RoundToInt(days / monthDayAmount[months]);
        if (monthIncrement > 0)
        {
            months += monthIncrement;
            days = 0;
            NewMonth();
        }
        if (months >= 12)
        {
            months = 0;
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
        if (hours == 9 && !working)
        {
            StartWorking();
        }
        else if (hours == 17 && working)
        {
            StopWorking();
        }
    }

    void NewMonth()
    {
        print("NEW MONTH");
        //Send Mail.
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

    public void SetMultiplier()
    {
        currentIndex++;
        if (currentIndex >= extraMultiplier.Count)
        {
            currentIndex = 0;
        }        
        multiplierText.text = (currentIndex + 1) + "x";
    }
}