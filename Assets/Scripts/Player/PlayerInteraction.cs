using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Collider2D [] colliderArray;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
               colliderArray = Physics2D.OverlapCircleAll(transform.position, 1.5f);
               foreach (Collider2D collider in colliderArray)
               {
                   if (collider.name == "Hole1")
                   {
                       collider.TryGetComponent(out HoleInteraction holeInteraction);
                       holeInteraction.Interact1();
                   }
                   else if (collider.name == "Hole2")
                   {
                       collider.TryGetComponent(out HoleInteraction holeInteraction);
                       holeInteraction.Interact2();
                   }
                   else if (collider.name == "Down1")
                   {
                       collider.TryGetComponent(out SceneChangeDown sceneChangeDown);
                       sceneChangeDown.Interact1();
                   }
                   else if (collider.name == "Down2")
                   {
                       collider.TryGetComponent(out SceneChangeDown sceneChangeDown);
                       sceneChangeDown.Interact2();
                   }
                   else if (collider.name == "Down3")
                   {
                       collider.TryGetComponent(out SceneChangeDown sceneChangeDown);
                       sceneChangeDown.Interact3();
                   }
                   else if (collider.name == "Down4")
                   {
                       collider.TryGetComponent(out SceneChangeDown sceneChangeDown);
                       sceneChangeDown.Interact4();
                   }
                   else if (collider.name == "Down5")
                   {
                       collider.TryGetComponent(out SceneChangeDown sceneChangeDown);
                       sceneChangeDown.Interact5();
                   }
               }
        }
    }
}
