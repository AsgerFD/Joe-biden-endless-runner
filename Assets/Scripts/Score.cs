using System;
using System.Collections;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;
    [HideInInspector]public static float conveyerSpeed = 40;
    public double initialConveyerSpeed = 40;
    public double logScale = 60;
    public float humanFrequency = 5;



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

        conveyerSpeed = (float)(initialConveyerSpeed * Math.Log(logScale+time)/Math.Log(logScale));
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