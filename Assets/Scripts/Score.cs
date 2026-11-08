using System;
using System.Collections;
using UnityEngine;

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

    private double time;

    void Start()
    {
        score = 0;
        lives = 3;
        initialHumanFrequency = humanFrequency;
        StartCoroutine(SpawnHumans());
    }

    void OnDisable()
    {
        StopCoroutine(SpawnHumans());
    }

    void Update()
    {
        time += Time.deltaTime;

        conveyerSpeed   =   (float)(initialConveyerSpeed * Math.Log(logScaleConveyerSpeed + time) / Math.Log(logScaleConveyerSpeed));
        humanFrequency  =   (float)(initialHumanFrequency * Math.Log(logScaleHumanFrequency) / Math.Log(logScaleHumanFrequency + time));
        Debug.Log(score);
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