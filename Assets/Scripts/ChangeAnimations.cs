using UnityEngine;

public class ChangeAnimations : MonoBehaviour
{
    public Animator animator;

    private int time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void FixedUpdate()
    {
        animator.SetInteger("time",time);
        time++;
        if (time > 120)
        {
            time = 0;
        }
    }
}
