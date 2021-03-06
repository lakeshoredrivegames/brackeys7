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
    public Text WarningText;
    public AudioSource source;
    public AudioClip errorClip;

    [System.Serializable]
    public class HeadlineEntry
    {
        public int score;
        public string headline;
    }


    //[HideInInspector]
    public List<Bait> baitList;

    public List<int> scores;


    private GameObject player;
    private int headlineScore = 0;
    private int headlinesRemaining = 0;

    [SerializeField]
    public List<HeadlineEntry> headlineEntryList; // need to fix this so that it shows in inspector 

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        
        //Headline can be added into the inspector
        //turn CreateHeadlines() on to load the headlines below. 
        //CreateHeadlines();
    }

    void Awake()
    {
        //store number of headlines in scene
        PlayerPrefs.SetInt("numberOfHeadlines", headlineEntryList.Count);
        headlinesRemaining = PlayerPrefs.GetInt("numberOfHeadlines");
        if (headlineEntryList.Count == 0)
        {
            WarningText.text = "There are no headlines in this scene. Please add some to the Headline component on the player object.";
            WarningText.gameObject.SetActive(true);
        }
        else
            WarningText.gameObject.SetActive(false);

 
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
            new HeadlineEntry{score = 40, headline="WALL STREET DOESN?T WANT YOU TO KNOW ABOUT THIS MONEYMAKING HACK"},
            new HeadlineEntry{score = 50, headline="PUPPY ALMOST DIED IN OPERATING ROOM.WHAT HAPPENS NEXT WILL SHOCK YOU"},
            new HeadlineEntry{score = 60, headline="FIND HOT SINGLES IN YOUR AREA"},
            new HeadlineEntry{score = 70, headline="ALIENS REAL? SCIENTISTS DISCOVER PROMISING NEW EVIDENCE"},
            new HeadlineEntry{score = 80, headline="YOU WON?T BELIEVE HIS SECRET TO LOSING WEIGHT"},
            new HeadlineEntry{score = 90, headline="LEAKED IMAGES FROM THE UPCOMING WHITE HOUSE REALITY TV SHOW"},
        };
    }

    public IEnumerator PrintHeadline()
    {
        yield return new WaitForEndOfFrame();
        bool found = false;


        headlineScore = 0;
        foreach (Bait bait in baitList)
        {
            headlineScore += bait.score;
            Debug.Log("Captured " + bait.name );
        }

        Debug.Log("Score is " + headlineScore );

        

        for (int i = 0; i < headlineEntryList.Count; i++)
        {
            if(headlineScore == headlineEntryList[i].score)
            {
                Debug.Log(headlineEntryList[i].headline);
                // add score to score list so we can check if score has already been attained
                if (headlineScore != 0 && scores.Count == 0)
                {
                    scores.Add(headlineScore);
                    headlinesRemaining--;
                }
                else
                {
                    if (scores.Contains(headlineScore))
                    {
                        //already found the headline before
                        // do not decrement the count
                    }
                    else
                    {
                        //add to scores
                        scores.Add(headlineScore);
                        //decrement headlines remaining
                        headlinesRemaining--;
                    }
                }
                Debug.Log("headlines remaining: " + headlinesRemaining);
                PlayerPrefs.SetInt("headlinesRemaining", headlinesRemaining);
                PlayerPrefs.SetInt("score", headlineEntryList[i].score);
                PlayerPrefs.SetString("headline", headlineEntryList[i].headline);
                scoreScreen.Setup(headlineEntryList[i].score, headlineEntryList[i].headline);
                found = true;

            }
            
        }


        if(!found)
        {
            source.clip = errorClip;
            source.pitch = 1f;
            source.Play();
        }
    }
}
