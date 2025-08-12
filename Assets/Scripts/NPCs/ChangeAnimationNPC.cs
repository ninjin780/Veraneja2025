using System.Threading;
using UnityEngine;

public class ChangeAnimationsNPC : MonoBehaviour
{
    public Animator animator;

    private int time;
    void FixedUpdate()
    {
        animator.SetInteger("Time",time);
        time++;
        if (time > 480)
        {
            time = 0;
        }
    }
}
