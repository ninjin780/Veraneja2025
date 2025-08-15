using System;
using UnityEngine;

public class InterponerAnimaciones : MonoBehaviour
{
    public Animator animator1;
    public Animator animator2;
    private AnimatorClipInfo[] info1;
    private bool ataque = false;
    private AnimationClip currentClip;
    private AnimationClip nextClip;
    private void FixedUpdate()
    {
        if (animator1.transform.position.x < 0)
        {
            animator2.transform.localScale = new Vector3(animator1.transform.localScale.x, animator1.transform.localScale.y, 1);
            animator2.transform.position = new Vector3(animator2.transform.position.x + 3, animator2.transform.position.y, 1);
        }
        else if (animator1.transform.position.x > 0)
        {
            animator2.transform.localScale = new Vector3(-animator1.transform.localScale.x, animator1.transform.localScale.y, 1);
            animator2.transform.position = new Vector3(animator2.transform.position.x - 3, animator2.transform.position.y, 1);
        }
        info1 = animator1.GetCurrentAnimatorClipInfo(0);
        currentClip = info1[0].clip;
        if (currentClip.name == "Attack")
        {
            nextClip = info1[0].clip;
            animator2.SetTrigger("Ataque");
            ataque = true;
            animator2.SetBool("Atacado", ataque);
        }
        if (currentClip != nextClip)
        {
            ataque = false;
            animator2.SetBool("Atacado", ataque);
        }
    }
}
