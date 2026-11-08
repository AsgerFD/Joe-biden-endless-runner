using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Human : MonoBehaviour
{
    private Box box;
    private SettingsManager settingsManager;
    private List<char> chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList();
    private Sprite tmp;
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
    public float patienceMad = 10.0f;
    public float patienceLeave = 15.0f;
    [Header("Actually needed")]
    public GameObject boxPrefab;
    public List<Sprite> packageSprites;
    private Animator animator;
    public AudioSource audioSourceDing;
    public AudioSource audioSourceMad;

    void LoadSettings()
    {
        audioSourceDing.volume = settingsManager.sfxVolume;
        audioSourceMad.volume = settingsManager.sfxVolume;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        settingsManager = SettingsManager.Instance;
        settingsManager.settingsChangedEvent.AddListener(LoadSettings);
        LoadSettings();
        audioSourceDing.Play();
    }

    void Start()
    {
        HumanController hc = FindFirstObjectByType<HumanController>();
        GameObject uhhh = Instantiate(boxPrefab, hc.boxSpawn);
        uhhh.transform.position = hc.boxSpawn.position;
        box = uhhh.GetComponent<Box>();

        box.id          =   System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9)) + "-" + System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9));
        box.auth        =   System.Convert.ToString(Random.Range(0,9)) + "-" + chars[Random.Range(0,chars.Count)]  +"-" + System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9))+ System.Convert.ToString(Random.Range(0,9)) + "-" + System.Convert.ToString(Random.Range(0,9));
        box.sender      =   randomNames[Random.Range(0, randomNames.Count)];
        box.receiver    =   randomNames[Random.Range(0, randomNames.Count)];
        int tmpPostnumberIndex = Random.Range(0, allowedPostnumbers.Count);
        box.postnumber  =   allowedPostnumbers[tmpPostnumberIndex];
        box.boxtype = Box.e_boxtype.DEFAULT; // Overridden afterwards
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
            switch (Random.Range(0, 3))
            {
                case 0:
                    tmp = packageSprites[0];
                    box.purchasedWeight = Random.Range(1,1001);
                    break;
                case 1:
                    tmp = packageSprites[1];
                    box.purchasedWeight = Random.Range(1001,10001);
                    break;
                case 2:
                    tmp = packageSprites[2];
                    box.purchasedWeight = Random.Range(10001,25001);
                    break;
            }
            box.actualWeight    =   Random.Range(box.purchasedWeight*2, box.purchasedWeight*4);
        } else
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    tmp = packageSprites[0];
                    box.purchasedWeight = Random.Range(1,1001);
                    break;
                case 1:
                    tmp = packageSprites[1];
                    box.purchasedWeight = Random.Range(1001,10001);
                    break;
                case 2:
                    tmp = packageSprites[2];
                    box.purchasedWeight = Random.Range(10001,100001);
                    break;
            }
            box.actualWeight    =   Random.Range(box.purchasedWeight/2, box.purchasedWeight);
        }
        box.img = tmp;
        uhhh.GetComponent<UnityEngine.UI.Image>().sprite = tmp;
        StartCoroutine(balls());
    }

    void OnDisable()
    {
        settingsManager.settingsChangedEvent.RemoveListener(LoadSettings);
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
        animator.SetTrigger("exit");
        if (timeTaken > patienceLeave)
        {
            Score.lives -= box.penalty;
            Score.livesChangeEvent.Invoke();
            audioSourceMad.Play();
            Destroy(box.gameObject);
        }
        yield return new WaitForSecondsRealtime(5);
        Destroy(gameObject);
    }
}