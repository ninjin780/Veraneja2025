using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCsInteractions : MonoBehaviour
{
   public GameObject contButton;
   public GameObject dialoguePanel;
   public TMPro.TMP_Text dialogueText;
   public string [] dialogue;
   private int index;

   public float wordSpeed;
   public bool playerIsClose;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
      {
         if (dialoguePanel.activeInHierarchy)
         {
            contButton.SetActive(false);
            zeroText();
         }
         else
         {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
         }
      }

      if (dialogueText.text == dialogue[index])
      {
         contButton.SetActive(true);
      }
   }

   public void zeroText()
   {
      dialogueText.text = "";
      index = 0;
      dialoguePanel.SetActive(false);
      
   }

   public void NextLine()
   {
      contButton.SetActive(false);
      if (index < dialogue.Length - 1)
      {
         index++;
         dialogueText.text = "";
         StartCoroutine(Typing());
      }
      else
      {
         zeroText();
      }
   }

   IEnumerator Typing()
   {
      foreach (char letter in dialogue[index].ToCharArray())
      {
         dialogueText.text += letter;
         yield return new WaitForSeconds(wordSpeed);
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
         contButton.SetActive(false);
         playerIsClose = false;
         zeroText();
      }
   }
   

}
