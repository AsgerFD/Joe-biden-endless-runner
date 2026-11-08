using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public static int score;
    public static int lives;
    [HideInInspector]public static float conveyerSpeed;
    public double initialConveyerSpeed = 40;
    public double logScaleConveyerSpeed = 60;
    public float humanFrequency;
    [HideInInspector]public double initialHumanFrequency;
    public double logScaleHumanFrequency;
    public static UnityEvent scoreChangeEvent;
    public static UnityEvent livesChangeEvent;
    public Canvas endScreen;

    private double time;

    void Start()
    {
        endScreen.enabled = false;
        if(scoreChangeEvent == null) scoreChangeEvent = new UnityEvent();
        if(livesChangeEvent == null) livesChangeEvent = new UnityEvent();
        scoreChangeEvent.AddListener(onScoreChange);
        livesChangeEvent.AddListener(onLivesChange);
        score = 0;
        lives = 3;
        initialHumanFrequency = humanFrequency;
        StartCoroutine(SpawnHumans());
    }

    void onScoreChange()
    {
        Debug.Log("Score: " + score);
    }

    void onLivesChange()
    {
        Debug.Log("Lives left: " + lives);
        if(lives <= 0)
        {
            endScreen.enabled = true;
        }
    }

    void OnDisable()
    {
        StopCoroutine(SpawnHumans());
        scoreChangeEvent.RemoveListener(onScoreChange);
        livesChangeEvent.RemoveListener(onLivesChange);
    }

    void Update()
    {
        time += Time.deltaTime;

        conveyerSpeed   =   (float)(initialConveyerSpeed * Math.Log(logScaleConveyerSpeed + time) / Math.Log(logScaleConveyerSpeed));
        humanFrequency  =   (float)(initialHumanFrequency * Math.Log(logScaleHumanFrequency) / Math.Log(logScaleHumanFrequency + time));
    }

    IEnumerator SpawnHumans()
    {
        while (true)
        {
            HumanController.newHumanEvent.Invoke();
            yield return new WaitForSecondsRealtime(humanFrequency);
        }
    }
}