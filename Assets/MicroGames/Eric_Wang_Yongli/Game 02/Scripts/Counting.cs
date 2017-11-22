using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EricWangYongli
{
    public class Counting : MonoBehaviour
    {
        public Text countText;
        public float count = 0;
        public float countdown = 3;
        public GameObject appleDown, appleUp, canvas, youwin;
        public AudioSource ha;

        private void Start()
        {
            //ha = GameObject.FindWithTag("Audio").GetComponent<AudioSource>(); 
        }

        IEnumerator WaitASec()  //wait 1/2 second before showing winning image
        {
            yield return new WaitForSeconds(0.5f);
            canvas.SetActive(false);
        }

        void CheckCount()   //check whether lift up & down 3 times within time limit or not
        {
            count += 0.5f;
            countText.text = "Lift up 3 times: " + Mathf.Round(count).ToString();
            countdown -= Time.deltaTime;
            if (count >= 3 && countdown > 0)   //show you win image
            {
                StartCoroutine("WaitASec");
            }
            if (count <3 && countdown <= 0)   //show you fail image
            {
                canvas.SetActive(false);
                youwin.SetActive(false);
            }
        }

        private void Update()
        {
            if (Input.GetButtonDown("Vertical"))   //switch graphics if up or down button is pressed
            {
                //ha.Play(); 
                if (appleDown.activeSelf)
                {
                    appleDown.SetActive(false);
                    appleUp.SetActive(true);
                }
                else
                {
                    appleDown.SetActive(true);
                    appleUp.SetActive(false);
                }
                CheckCount(); 
            }
        }
    }
}
