using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {
    
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] float displayedTime; 
    [SerializeField] private GameObject TutorialGameObject;
    [SerializeField] private GameObject YouWinGameObject;
    public PlayerController playerController;
    public bool gameStart = false;
    public bool timerEnded = false;
    AudioSource audioSource; 
    public AudioClip winsfx;
    public AudioClip readysfx;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySound(readysfx);
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }

        /*if (remainingTime < 0)
        {
            remainingTime = 0;
        }
        */

        remainingTime = Mathf.Max(0f, remainingTime);
        displayedTime = remainingTime; // Update displayedTime

        //remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(displayedTime / 60);
        int seconds = Mathf.FloorToInt(displayedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime <= 10f && remainingTime > 9f && !gameStart)
        {
            StartGame();
            gameStart = true;
        }

        if (remainingTime == 0f && !timerEnded && playerController.isDead == false)
        {
            StartCoroutine(WinGame());
            timerEnded = true;
        }
    }

    void StartGame()
    {
        TutorialGameObject.SetActive(false);
        Debug.Log("STARTGAME");
    }

    IEnumerator WinGame()
    {
        YouWinGameObject.SetActive(true);
        PlaySound(winsfx);
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}
