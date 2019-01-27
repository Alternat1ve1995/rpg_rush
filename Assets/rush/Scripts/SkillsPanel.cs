using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsPanel : MonoBehaviour
{
   public SkillSlot[] slots;
   public Character player;

   void Update()
   {
      CheckInput();
   }

   void CheckInput()
   {
      //TODO : research get number normally
      if (Input.GetKeyDown(KeyCode.Keypad0))
      {
         Debug.Log("Skill 0 triggered");
         if (slots[0].skill != null)
            slots[0].skill.ExecuteSkill(player, player.target, Vector3.zero);
      }
      else if (Input.GetKeyDown(KeyCode.Keypad1))
      {
         Debug.Log("Skill 1 triggered");
         if (slots[1].skill != null)
            slots[1].skill.ExecuteSkill(player, player.target, Vector3.zero);
      }
      
      else if (Input.GetKeyDown(KeyCode.Keypad2))
      {
         Debug.Log("Skill 2 triggered");
         if (slots[2].skill != null)
            slots[2].skill.ExecuteSkill(player, player.target, Vector3.zero);
      }
      else if (Input.GetKeyDown(KeyCode.Keypad3))
      {
         Debug.Log("Skill 3 triggered");
         if (slots[3].skill != null)
            slots[3].skill.ExecuteSkill(player, player.target, Vector3.zero);
      }
      else if (Input.GetKeyDown(KeyCode.Keypad4))
      {
         Debug.Log("Skill 4 triggered");
         if (slots[4].skill != null)
            slots[4].skill.ExecuteSkill(player, player.target, Vector3.zero);
      }
      else if (Input.GetKeyDown(KeyCode.Keypad5))
      {
         Debug.Log("Skill 5 triggered");
         if (slots[5].skill != null)
            slots[5].skill.ExecuteSkill(player, player.target, Vector3.zero);
      }
      
   }
   
   
}
