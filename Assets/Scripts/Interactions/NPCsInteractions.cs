using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCsInteractions : MonoBehaviour
{
   public GameObject contButton;
   public GameObject dialoguePanel;
   public GameObject NPC;
   
   public TMPro.TMP_Text dialogueText;
   public TMPro.TMP_Text name;
   
   public string [] dialogue;
   private int index;

   public float wordSpeed;
   public bool playerIsClose;
   
   public void Spawn()
   {
      switch (NPC.name)
      {
         case "Boo":
            PlayerPrefs.SetInt("Boo", 1);
            break;
         case "Milo":
            PlayerPrefs.SetInt("Milo", 1);
            break;
         case "Steve":
            PlayerPrefs.SetInt("Steve", 1);
            break;
         case "Virgil":
            PlayerPrefs.SetInt("Virgil", 1);
            break;
         case "Ranastacio":
            PlayerPrefs.SetInt("Ranastacio", 1);
            break;
      }
   }

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
            name.text = NPC.name;
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
      name.text = "";
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
