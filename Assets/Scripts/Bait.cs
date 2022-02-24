using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MonoBehaviour
{
    public int score = 0;
    public string name = "";
    public bool seen = false;

    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // if bait is in view, add to list
    void OnBecameVisible()
    {
        seen = true;
        player.GetComponent<Headline>().baitList.Add(this);
    }

    // if bait leaves view, remove from list
    void OnBecameInvisible()
    {
        seen = false;
        player.GetComponent<Headline>().baitList.Remove(this);
    }
}
