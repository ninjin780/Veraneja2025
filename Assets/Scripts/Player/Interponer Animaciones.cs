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
    private float xInput;
    
    void Update()
    {
        CheckInput();
    }
    void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        animator2.transform.localScale = new Vector3(-0.25f, 0.25f, 1);
        animator2.transform.position = new Vector3(animator1.transform.position.x * xInput, animator1.transform.position.y, 1);
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
