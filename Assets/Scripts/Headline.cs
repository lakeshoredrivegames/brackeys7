using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class Headline : MonoBehaviour
{
    public ScoreScreen scoreScreen;
    public Sprite image;

    public class HeadlineEntry
    {
        public int score;
        public string headline;
    }

    [SerializeField]
    public List<Bait> baitList;


    private GameObject player;
    public int headlineScore = 0;

    [SerializeField]
    private StarterAssetsInputs starterAssetsInput;

    [SerializeField]
    public List<HeadlineEntry> headlineEntryList; // need to fix this so that it shows in inspector 

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        CreateHeadlines();
    }

    void Awake()
    {
        starterAssetsInput = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateHeadlines()
    {
        //headlines = new List<int,string>();
        headlineEntryList = new List<HeadlineEntry>()
        {
            new HeadlineEntry{score = 10, headline="HEALTH INSPECTOR SHUTTERS RESTAURANT AFTER INSANE DISCOVERY"},
            new HeadlineEntry{score = 20, headline="MAN ARRESTED FOR INCITING REVOLUTION. WATCH THE VIDEO"},
            new HeadlineEntry{score = 30, headline="RENOWNED DOCTOR REVEALS SECRET TO LONGER LIFE"},
            new HeadlineEntry{score = 40, headline="WALL STREET DOESN’T WANT YOU TO KNOW ABOUT THIS MONEYMAKING HACK"},
            new HeadlineEntry{score = 50, headline="PUPPY ALMOST DIED IN OPERATING ROOM.WHAT HAPPENS NEXT WILL SHOCK YOU"},
            new HeadlineEntry{score = 60, headline="FIND HOT SINGLES IN YOUR AREA"},
            new HeadlineEntry{score = 70, headline="ALIENS REAL? SCIENTISTS DISCOVER PROMISING NEW EVIDENCE"},
            new HeadlineEntry{score = 80, headline="YOU WON’T BELIEVE HIS SECRET TO LOSING WEIGHT"},
            new HeadlineEntry{score = 90, headline="LEAKED IMAGES FROM THE UPCOMING WHITE HOUSE REALITY TV SHOW"},
        };
    }

    public IEnumerator PrintHeadline()
    {
        yield return new WaitForEndOfFrame();


        headlineScore = 0;
        foreach (Bait bait in baitList)
        {
            headlineScore += bait.score;
            Debug.Log("Captured " + bait.name );
        }

        Debug.Log("Score is " + headlineScore );

        //score: equals headline 
        //if score is 10, headline is:"
        for(int i = 0; i < headlineEntryList.Count; i++)
        {
            if(headlineScore == headlineEntryList[i].score)
            {
                Debug.Log(headlineEntryList[i].headline);
                scoreScreen.Setup(headlineEntryList[i].score, headlineEntryList[i].headline);
                PlayerPrefs.SetInt("score", headlineEntryList[i].score);
                PlayerPrefs.SetString("headline", headlineEntryList[i].headline);

            }
        }

        //Scene scene = SceneManager.GetActiveScene();
        //PlayerPrefs.SetString("_last_scene_", scene.name);
        //SceneManager.LoadScene("GameOver");



    }

    

}
