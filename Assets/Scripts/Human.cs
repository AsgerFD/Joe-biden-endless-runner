using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Human : MonoBehaviour
{
    private Box box;
    List<char> chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList();
    [HideInInspector]public Sprite Mad;
    [Header("Funnies")]
    public List<string> randomNames;
    public List<int> allowedPostnumbers;
    public List<string> randomAddresses1;
    public List<string> randomAddresses2;
    public List<string> randomAddresses3;
    public List<string> randomAddresses4;
    [Header("Actual balancing")]
    public float weightFraudChance = 0.1f;
    public float adressFuckupChance = 0.1f;
    public float patienceMad = 5.0f;
    public float patienceLeave = 10.0f;
    [Header("Actually needed")]
    public GameObject boxPrefab;
    public Transform boxSpawn;
    public List<Sprite> packageSprites;

    void Start()
    {
        GameObject uhhh = Instantiate(boxPrefab, transform.parent);
        uhhh.transform.position = boxSpawn.position;
        box = uhhh.GetComponent<Box>();

        box.id          =   System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9)) + "-" + System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9));
        box.auth        =   System.Convert.ToString(Random.Range(0,9)) + "-" + chars[Random.Range(0,chars.Count)]  +"-" + System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9)) + "-" + System.Convert.ToString(Random.Range(0,9));
        box.sender      =   randomNames[Random.Range(0, randomNames.Count)];
        box.receiver    =   randomNames[Random.Range(0, randomNames.Count)];
        int tmpPostnumberIndex = Random.Range(0, allowedPostnumbers.Count);
        box.postnumber  =   allowedPostnumbers[tmpPostnumberIndex];
        if(Random.Range(0f,1f) < adressFuckupChance)
        {
            box.boxtype =   Box.e_boxtype.DISCARD;
            int tmpTmpPostnumberIndex = tmpPostnumberIndex;
            while(tmpTmpPostnumberIndex == tmpPostnumberIndex)
                tmpPostnumberIndex = Random.Range(0, allowedPostnumbers.Count);
        }
        switch (tmpPostnumberIndex) {
            case 0:
                box.address =   randomAddresses1[Random.Range(0, randomAddresses1.Count)];
                break;
            case 1:
                box.address =   randomAddresses2[Random.Range(0, randomAddresses2.Count)];
                break;
            case 2:
                box.address =   randomAddresses3[Random.Range(0, randomAddresses3.Count)];
                break;
            case 3:
                box.address =   randomAddresses4[Random.Range(0, randomAddresses4.Count)];
                break;
        }
        if(Random.Range(0f,1f) < weightFraudChance)
        {
            box.boxtype =   Box.e_boxtype.DISCARD;
            box.purchasedWeight =   Random.Range(1, 5)*Random.Range(1, 5)*1000;
            box.actualWeight    =   Random.Range(box.purchasedWeight*2, box.purchasedWeight*4);
        }
        if(box.boxtype != Box.e_boxtype.DISCARD) {
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
        while(timeTaken < patienceMad)
        {
            if(box.hasBeenTaken) break;
            timeTaken += Time.deltaTime;
            yield return 0;
        }
        if(timeTaken > patienceMad)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = Mad;
        }
        while(timeTaken < patienceLeave)
        {
            if(box.hasBeenTaken) break;
            timeTaken += Time.deltaTime;
            yield return 0;
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
            Destroy(gameObject);
        }
    }
}