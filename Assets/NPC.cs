using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float state;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("State", state);
    }
}
