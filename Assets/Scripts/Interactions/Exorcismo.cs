using UnityEngine;

public class Exorcismo : MonoBehaviour
{
    private Animator animator; 
    private NPCsInteractions npcInteractions;
    private bool playerIsClose;

    private bool isExorcited = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        npcInteractions = GetComponent<NPCsInteractions>();
        npcInteractions.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && !isExorcited)
        {
            animator.SetTrigger("Interacted");
            isExorcited = true;
            npcInteractions.enabled = true;
        }
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
