using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    public Image barraVida;
    private PlayerCombat pc;
    public float vidaMaxima = 100;

    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerCombat>();
    }

    private void Update()
    {
        barraVida.fillAmount = pc.vidaActual / vidaMaxima;
        Debug.Log("VA" + pc.vidaActual);
        Debug.Log("VM" + vidaMaxima);
    }
}
