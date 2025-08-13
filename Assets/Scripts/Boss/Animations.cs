using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator animator;

    private int time;
    private bool attack = false;
    private int lifes;
    void FixedUpdate()
    {
        time++;
        animator.SetInteger("Tiempo",time);
        animator.SetBool("Atacado", attack);
        if (time > 480)
        {
            time = 0;
            attack = false;
        }

        if (time > 50)
        {
            attack  = true;
        }
    }
}
