using UnityEngine;

public class AnimationRepeater : MonoBehaviour
{
   public Animator animator;
   private int time;
   void FixedUpdate()
   {
      animator.SetInteger("Time",time);
      time++;
      if (time > 150)
      {
         time = 0;
      }
      
   }
}
