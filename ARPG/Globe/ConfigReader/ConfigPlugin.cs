using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skill;

public class ConfigPlugin : MonoBehaviour {
   
    //主键：技能拥有者   子键：属性名称   子值：数据
    Dictionary<string, Dictionary<string, string>>
        skillManger = new Dictionary<string, Dictionary<string, string>>();
    List<string> names = new List<string>();
    /// <summary>
    /// 读取配置文件技能字典内容
    /// </summary>
    public void ReadSkill()
    {

    }
    public void WriterSkill()
    {
        CharacterSkillManager magr = null;
        SkillData data=new SkillData();
        string name = null;
        //
        for (int i = 0; i < names.Count; i++)
        {
            name = names[i];
            magr = SkillDataObject.skillObject[name];
            data.skillID = int.Parse
                (skillManger[name]["SkillID"]);
            SkillDataObject.WriterSkillData(magr, data);
        }
    }
}
