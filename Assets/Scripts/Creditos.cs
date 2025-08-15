using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SimpleCreditsController : MonoBehaviour
{
    [Header("Credit Sprites (Front to Back order)")]
    public GameObject[] creditSprites;



    [Header("Timing")]
    public float delayBeforeStart = 2f;
    public float timeBetweenCredits = 4f;
    public float delayBeforeExitButton = 2f;

    void Start()
    {
        StartCoroutine(ShowCreditsSequence());
    }

    IEnumerator ShowCreditsSequence()
    {
        // Wait before starting
        yield return new WaitForSeconds(delayBeforeStart);

        // Hide each credit sprite one by one (except the last one)
        for (int i = 0; i < creditSprites.Length - 1; i++)
        {
            yield return new WaitForSeconds(timeBetweenCredits);

            if (creditSprites[i] != null)
            {
                creditSprites[i].gameObject.SetActive(false);
            }
        }

        // Wait a bit more, then hide the last sprite
        yield return new WaitForSeconds(timeBetweenCredits);

        if (creditSprites.Length > 0 && creditSprites[creditSprites.Length - 1] != null)
        {
            creditSprites[creditSprites.Length - 1].gameObject.SetActive(false);
        }

        SceneManager.LoadScene(0);  
    }  
}