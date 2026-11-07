using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HumanController : MonoBehaviour
{
    public static UnityEvent newHumanEvent;
    public List<Sprite> playerSprites;
    public GameObject playerPrefab;

    void Awake()
    {
        if(newHumanEvent == null) newHumanEvent = new UnityEvent();
        newHumanEvent.AddListener(addHumanHandler);
    }

    void OnDisable()
    {
        newHumanEvent.RemoveListener(addHumanHandler);
    }

    void addHumanHandler()
    {
        GameObject pf = Instantiate(playerPrefab);
        pf.GetComponent<Image>().sprite = playerSprites[Random.Range(0,playerSprites.Count)];
        pf.transform.position = transform.position;
    }
}