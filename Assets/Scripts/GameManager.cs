using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float survivieTime;
    private bool isGameover;

    private void Start()
    {
        survivieTime = 0;
        isGameover = false;
    }
    private void Update()
    {
        if (!isGameover)
        {
            survivieTime += Time.deltaTime;
            timeText.text = "Time: " + (int)survivieTime;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(survivieTime > bestTime)
        {
            bestTime = survivieTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }
}
