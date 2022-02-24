using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headlineText : MonoBehaviour
{
    public string headline;
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


    void OnBecameVisible()
    {
        seen = true;
        player.GetComponent<CameraControls>().texts.Add(this);
    }

    void OnBecameInvisible()
    {
        seen = false;
        player.GetComponent<CameraControls>().texts.Remove(this);
    }
}
