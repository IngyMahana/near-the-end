using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Main : MonoBehaviour
{

    public GameObject winText;
    public float timerDurationTillRestartSeconds = 5.0f;
    public static int numSaved = 0;

    void Start(){
        winText = GameObject.Find("You Win Text");
        winText.SetActive(false);
    }

    void Update(){
         if(Timer.playerWon){
            if(!winText.activeSelf){
                winText.SetActive(true);
            }
            timerDurationTillRestartSeconds -= Time.deltaTime;
            if(timerDurationTillRestartSeconds <= 0){
                Main.numSaved = 0;
                Timer.playerWon = false;
                Timer.gameStarted = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name );
            } else {
                winText.GetComponent<TextMeshProUGUI>().text = "You Win!\nRestarting in " + ((int)timerDurationTillRestartSeconds).ToString();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ally Soldier" && Timer.gameStarted){
            Main.numSaved += 1;
            Destroy(collision.gameObject);

            if(Main.numSaved == 8){
                Timer.playerWon = true;
                winText.SetActive(true);
            }
        }
    }

   
}
