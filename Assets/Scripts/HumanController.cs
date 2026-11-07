using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HumanController : MonoBehaviour
{
    public static UnityEvent newHumanEvent;
    public List<Sprite> playerSprites;
    public List<Sprite> playerMadSprites;
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
        GameObject pf = Instantiate(playerPrefab, transform);
        int tmp = Random.Range(0,playerSprites.Count);
        pf.GetComponent<Image>().sprite = playerSprites[tmp];
        pf.GetComponent<Human>().Mad = playerMadSprites[tmp];
        pf.transform.position = transform.position;
    }
}