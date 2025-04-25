using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cronometer : MonoBehaviour
{
    private float timeRemaining = 120;
    private float timeCinema = 16;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPuntos;
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ChangeTime());
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining <= 0)
        {
            timeRemaining = 0;
            GameOver();
        }
        else
        {
            if(timeCinema > 0)
            {
                timeCinema -= Time.deltaTime;
            }
            else
            {
                timeRemaining -= Time.deltaTime;
            }
            
        }

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        if ((seconds <= 20 && minutes == 0) && timeCinema < 0)
        {
            if(seconds % 2 == 0)
                timer.color = Color.red;
            else
                timer.color = Color.white;
        }
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void GameOver()
    {
        isGameOver = true;
        //desactivar boton pausa
        buttonPause.SetActive(false);
        //activar menu
        menuPuntos.SetActive(true);
    }

    //IEnumerator ChangeTime()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //    Debug.Log("aja");
    //    if(!(minutes <= 0 && seconds <= 0))
    //    {
    //        if(seconds <= 0)
    //        {
    //            seconds = 59;
    //            minutes--;
    //        }
    //        else
    //        {
    //            seconds--;
    //        }
    //    }
    //    else
    //    {
    //        minutes = 0; seconds = 0;
    //    }
    //    timer.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    //}
}
