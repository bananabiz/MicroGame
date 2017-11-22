using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EricWangYongli
{
    public class Timer : MonoBehaviour
    {
        public float hour = 8f;
        public float minute = 8f;
        public float second = 8f;
        public int buttonCount = 0;
        public string hourText, minText, secText;
        public Text hours, minutes, seconds;
        public GameObject button1, button2, button3;

        private float hr, min, sec;
        private bool one, two, three;

        void CountingHour()  //counting down number of hours
        {
            hour -= Time.deltaTime;
            hr = Mathf.Round(second);
            hourText = hr.ToString();
            hours.text = "0" + hourText;
        }

        void CountingMinute()  //counting down number of minutes 
        {
            minute -= Time.deltaTime;
            min = Mathf.Round(second);
            minText = min.ToString();
            minutes.text = "0" + minText;
        }

        void CountingSecond()  //counting down number of seconds
        {
            second -= Time.deltaTime;
            sec = Mathf.Round(second);
            secText = sec.ToString();
            seconds.text = "0" + secText;
        }


        void Update()
        {
            // continue counting down if not press any button 
            if (!one)
            {
                CountingHour();
            }
            if (!two)
            {
                CountingMinute();
            }
            if (!three)
            {
                CountingSecond();
            }
            // set countdown number to 0 and show You Lose image if countdown number smaller than 0
            if (sec < 0)
            {
                second = 0;
                GameObject canvas = GameObject.FindWithTag("Canvas");
                GameObject youwin = GameObject.FindWithTag("YouWin");
                canvas.SetActive(false);
                youwin.SetActive(false); 
            }
            // perform actions on button image if space button is pressed
            if (Input.GetButtonDown("Fire1"))
            {
                ++buttonCount;
                if (buttonCount == 1 && hr >= 0)
                {
                    button1.transform.position = button1.transform.position + new Vector3(0, -9, 0);
                    one = true;
                }
                if (buttonCount == 2 && min >= 0)
                {
                    button2.transform.position = button2.transform.position + new Vector3(0, -9, 0);
                    two = true;
                }
                // show You Win image if countdown number is bigger or equal to 0 when all three buttons have been clicked
                if (buttonCount == 3 && sec >= 0)
                {
                    three = true;
                    button3.transform.position = button3.transform.position + new Vector3(0, -9, 0);
                    GameObject canvas = GameObject.FindWithTag("Canvas");
                    canvas.SetActive(false);
                }
            }
        }
    }
}
