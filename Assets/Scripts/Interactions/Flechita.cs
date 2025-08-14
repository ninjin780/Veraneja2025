using UnityEngine;
using UnityEngine.Rendering;

public class Flechita : MonoBehaviour
{
    public GameObject panel;
    public GameObject flechita;
    
    private bool playerIsClose;
    private bool flechaSalida;
    void Update()
    {
        if (playerIsClose)
        {
            if (panel.activeInHierarchy && !flechaSalida)
            {
                flechita.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
                flechita.SetActive(true);
                flechaSalida = true;
            }
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
            panel.SetActive(false);
            flechaSalida = false;
            playerIsClose = false;
        }
    }
    
}
