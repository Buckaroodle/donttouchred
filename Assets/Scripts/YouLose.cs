using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouLose : MonoBehaviour

{

    public PlayerController playerController;
    public Timer timer;
    [SerializeField]private GameObject YouWinGameObject;
     AudioSource audioSource; 
    public AudioClip explode;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("isDead: " + playerController.isDead);

        if (playerController.isDead && timer.timerEnded == false)
        {
            StartCoroutine(LoseGame());
        }
    }

    IEnumerator LoseGame()
    {
        YouWinGameObject.SetActive(true);
        PlaySound(explode);
        yield return new WaitForSeconds(2f);
        Application.Quit(); 
        //Debug.Log("YIPPEEE");
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
