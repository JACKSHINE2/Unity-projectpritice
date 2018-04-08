using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDataObject : MonoBehaviour {

    
    //保存相应名称的技能对象  主键：Player  
    //值：player.GetCompont<CharacterSkillManager>()
  public static Dictionary<string, CharacterSkillManager>
        skillObject = new Dictionary<string, CharacterSkillManager>();
    public static void WriterSkillData(CharacterSkillManager chSkillManager
        ,SkillData skillData)
    {
        chSkillManager.skills.Add(skillData);
    }
}
