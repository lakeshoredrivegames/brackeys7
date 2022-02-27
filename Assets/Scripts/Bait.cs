using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MonoBehaviour
{
    public int score = 0;
    public string name = "";
    public bool seen = false;

    public Camera camera;

    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        camera = Camera.main;
    
    }

    // Update is called once per frame
    void Update()
    {
        Visible();
    }

    private void Visible()
    {

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(planes, this.GetComponent<Collider>().bounds))
        {
            seen = true;
            if (player.GetComponent<Headline>().baitList.Contains(this))
            {

            }
            else 
                player.GetComponent<Headline>().baitList.Add(this);
        }
        else
        {
            seen = false;
            if (player != null)
                player.GetComponent<Headline>().baitList.Remove(this);
        }
    }

    /*
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
        if(player != null)
            player.GetComponent<Headline>().baitList.Remove(this);
    }
    */
}
