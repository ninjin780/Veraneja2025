using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    public Image barraVida;
    public float vidaMaxima = 100;

    private void Start()
    {
        vidaMaxima = 100;
    }

    private void Update()
    {
        barraVida.fillAmount = PlayerCombat.vidaActual / vidaMaxima;
        Debug.Log("VA" + PlayerCombat.vidaActual);
        Debug.Log("VM" + vidaMaxima);
        Debug.Log("BA" + PlayerCombat.vidaActual / vidaMaxima);
    }
}
