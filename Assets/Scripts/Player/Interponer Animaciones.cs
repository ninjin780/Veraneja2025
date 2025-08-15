using System;
using UnityEngine;

public class InterponerAnimaciones : MonoBehaviour
{
    public Animator animator1;
    public Animator animator2;

    private int time;
    private void FixedUpdate()
    {
        time++;
    }
}
