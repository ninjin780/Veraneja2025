using UnityEngine;

public class Exorcismo : MonoBehaviour
{
    private Animator animator; 
    private NPCsInteractions npcInteractions;
    private bool playerIsClose;
    private AnimatorClipInfo[] animation;

    private bool isExorcited = false;
    private Vector3 position;
    private Vector3 scale;
    void Start()
    {
        animator = GetComponent<Animator>();
        npcInteractions = GetComponent<NPCsInteractions>();
        npcInteractions.enabled = false;
        position = transform.position;
        scale = transform.localScale;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && !isExorcited)
        {
            animator.SetTrigger("Interacted");
            isExorcited = true;
            npcInteractions.enabled = true;
            npcInteractions.Spawn();
        }

        if (CheckAnimationState())
        {
            transform.position = new Vector3(0, 0, transform.position.z);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.position = position;
            transform.localScale = scale;
        }
    }
    private bool CheckAnimationState()
    {
        // Obtener información de la animación actual
        animation = animator.GetCurrentAnimatorClipInfo(0);
            
        // Verificar si hay clips disponibles
        if (animation.Length > 0)
        {
            if (animation[0].clip.name.Equals("flash"))
            {
                return true;
            }
            
        }
        return false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
