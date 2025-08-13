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
                   else if (collider.name == "Hole3")
                   {
                       collider.TryGetComponent(out HoleInteraction holeInteraction);
                       holeInteraction.Interact3();
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
                   else if (collider.name == "Front1")
                   {
                       collider.TryGetComponent(out SceneChangerUp sceneChangeUp);
                       sceneChangeUp.Interact1();
                   }
                   else if (collider.name == "Front2")
                   {
                       collider.TryGetComponent(out SceneChangerUp sceneChangeUp);
                       sceneChangeUp.Interact2();
                   }
                   else if (collider.name == "Front3")
                   {
                       collider.TryGetComponent(out SceneChangerUp sceneChangeUp);
                       sceneChangeUp.Interact3();
                   }
                   else if (collider.name == "Front4")
                   {
                       collider.TryGetComponent(out SceneChangerUp sceneChangeUp);
                       sceneChangeUp.Interact4();
                   }
                   else if (collider.name == "Front5")
                   {
                       collider.TryGetComponent(out SceneChangerUp sceneChangeUp);
                       sceneChangeUp.Interact5();
                   }
                   else if (collider.name == "Front6")
                   {
                       collider.TryGetComponent(out SceneChangerUp sceneChangeUp);
                       sceneChangeUp.Interact6();
                   }
                   else if (collider.name == "Front7")
                   {
                       collider.TryGetComponent(out SceneChangerUp sceneChangeUp);
                       sceneChangeUp.Interact7();
                   }
                   else if (collider.name == "yisus")
                   {
                       collider.TryGetComponent(out NPCsInteractions npcsInteraction);
                       npcsInteraction.Interact1();
                   }
               }
        }
    }
}
