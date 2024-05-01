using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{

    public float timerDurationSeconds = 10.0f;
    public float preStartDurationSeconds = 10.0f;
    public TMP_Text timerText;
    public GameObject restartText;
    public GameObject startingInText;
    public GameObject loseExplosion;
    public float timerDurationTillRestartSeconds = 5.0f;
    public bool playerLost = false; 
    public static bool playerWon = false; 
    public static bool gameStarted = false;


    void Start() {
        timerText = GetComponent<TextMeshProUGUI>();
        loseExplosion = GameObject.Find("Player Lose Explosion");
        restartText = GameObject.Find("Restart Text");
        startingInText = GameObject.Find("Starting In");
        loseExplosion.SetActive(false);
        restartText.SetActive(false);
        Timer.gameStarted = false;
    }

    void Update(){
        if(gameStarted){
            timerDurationSeconds -= Time.deltaTime;
        } else {
            preStartDurationSeconds -= Time.deltaTime;

            if(preStartDurationSeconds <= 0){
                Timer.gameStarted = true;
                startingInText.SetActive(false);
            } else {
                startingInText.GetComponent<TextMeshProUGUI>().text = "Starting in " + ((int)preStartDurationSeconds).ToString();
            }
        }
      
        if (timerDurationSeconds <= 0.0f && !Timer.playerWon){
            timerEnded();
        } else {
            int minutes = (int)(timerDurationSeconds / 60);
            int seconds = (int)(timerDurationSeconds - (minutes * 60));

            string minutesString;
            if(minutes < 10){
                minutesString = "0" + minutes.ToString();
            } else {
                minutesString = minutes.ToString();
            }

            string secondsString;
            if(seconds < 10){
                secondsString = "0" + seconds.ToString();
            } else {
                secondsString = seconds.ToString();
            }
            timerText.text = minutesString + ":" + secondsString.ToString();

        }

        if(playerLost && !Timer.playerWon){
            timerDurationTillRestartSeconds -= Time.deltaTime;
            if(timerDurationTillRestartSeconds <= 0){
                Main.numSaved = 0;
                Timer.playerWon = false;
                Timer.gameStarted = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name );
            } else {
                restartText.GetComponent<TextMeshProUGUI>().text = "You Lose.\nRestarting in " + ((int)timerDurationTillRestartSeconds).ToString();
            }

        }

        


    }

    void timerEnded(){
        loseExplosion.SetActive(true);
        restartText.SetActive(true);
        playerLost = true;
    }
}
