using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class Human : MonoBehaviour
{
    private Box box;
    [HideInInspector]public Sprite Mad;
    public List<string> randomNames;
    public List<string> randomAddresses;
    public bool contrabandEnabled = false;
    public float contrabandChance = 0.9f;
    public List<char> chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList();
    public List<int> allowedPostnumbers;
    public GameObject boxPrefab;
    public Transform boxSpawn;
    public float patienceMad = 5.0f;
    public float patienceLeave = 10.0f;
    public List<Sprite> packageSprites;

    void Start()
    {
        GameObject uhhh = Instantiate(boxPrefab, transform.parent);
        uhhh.transform.position = boxSpawn.position;
        box = uhhh.GetComponent<Box>();

        box.id          =   System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9)) + "-" + System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9));
        box.auth        =   System.Convert.ToString(Random.Range(0,9)) + "-" + chars[Random.Range(0,chars.Count)]  +"-" + System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9)) + "-" + System.Convert.ToString(Random.Range(0,9));
        //box.points      =   1;
        //box.penalty     =   5;
        box.sender      =   randomNames[Random.Range(0, randomNames.Count)];
        box.receiver    =   randomNames[Random.Range(0, randomNames.Count)];
        box.address     =   randomAddresses[Random.Range(0, randomAddresses.Count)];
        box.postnumber  =   allowedPostnumbers[Random.Range(0, allowedPostnumbers.Count)];
        if(contrabandEnabled && Random.Range(0f,1f) > contrabandChance)
        {
            box.boxtype =   Box.e_boxtype.CONTRABAND;
            box.purchasedWeight =   Random.Range(1, 5)*Random.Range(1, 5)*1000;
            box.actualWeight    =   Random.Range(box.purchasedWeight*2, box.purchasedWeight*4);
        } else {
            box.boxtype = Box.e_boxtype.DEFAULT;
            box.purchasedWeight =   Random.Range(1, 10)*Random.Range(1, 10)*1000;
            box.actualWeight    =   Random.Range(box.purchasedWeight/2, box.purchasedWeight);
        }
        Sprite tmp;
        switch (box.actualWeight)
        {
            case < 1:
                tmp = packageSprites[0];
                break;
            case < 5:
                tmp = packageSprites[1];
                break;
            default:
                tmp = packageSprites[2];
                break;
        }
        uhhh.GetComponent<UnityEngine.UI.Image>().sprite = tmp;
        StartCoroutine(balls());
    }

    IEnumerator balls()
    {
        float timeTaken = 0.0f;
        for(;box.hasBeenTaken && timeTaken < patienceMad; timeTaken += Time.deltaTime)
        {
            yield return new WaitForNextFrameUnit();
        }
        if(timeTaken < patienceMad)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = Mad;
        }
        for(;box.hasBeenTaken && timeTaken < patienceLeave; timeTaken += Time.deltaTime)
        {
            yield return new WaitForNextFrameUnit();
        }
        if (timeTaken < patienceLeave)
        {
            // Or trigger an animation type shit
            Destroy(gameObject);
        }
        else
        {
            // Or trigger an animation skriv lort
            Score.score -= box.penalty;
            Destroy(box.gameObject);
        }
    }
}