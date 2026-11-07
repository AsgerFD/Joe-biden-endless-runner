using System;
using System.Collections;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int lives = 3;
    [HideInInspector]public static float conveyerSpeed;
    public double initialConveyerSpeed = 40;
    public double logScaleConveyerSpeed = 60;
    [HideInInspector]public float humanFrequency = 60;
    public double initialHumanFrequency = 30;
    public double logScaleHumanFrequency = 60;

    private double time;

    void Start()
    {
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
        Debug.Log("convspeed: " +  conveyerSpeed);
        humanFrequency  =   (float)(initialHumanFrequency * Math.Log(logScaleHumanFrequency) / Math.Log(logScaleHumanFrequency + time));
        Debug.Log("hrmnfrequ: " +  humanFrequency);
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