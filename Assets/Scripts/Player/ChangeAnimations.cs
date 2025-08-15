using System.Threading;
using UnityEngine;

public class ChangeAnimations : MonoBehaviour
{
    public Animator animator;

    private int time;
    void FixedUpdate()
    {
        animator.SetInteger("time",time);
        time++;
        if (time > 240)
        {
            if (AudioManager.aaaaaa)
            {
                AudioManager.currentScene = -1;
                AudioManager.aaaaaa = false;
            }
            time = 0;
        }
    }
    void Start() { }
}
