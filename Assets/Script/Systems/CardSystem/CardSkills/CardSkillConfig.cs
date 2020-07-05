using UnityEngine;

public class CardSkillConfig : Singleton<CardSkillConfig>
{
    private const string RESOURCE_CONFIG_PATH = "ConfigTables/CreateCardSkillConfig";
    public CardSkillData[] skills;
    public CardSkillConfig()
    {
        CardSkillConfigTable table = Resources.Load<CardSkillConfigTable>(RESOURCE_CONFIG_PATH);
        if (table != null)
        {
            skills = table.cardSkillConfig;
        }
    }

    public CardSkillData GetSkillByCode(int code)
    {
        if (skills == null)
        {
            return null;
        }
        CardSkillData result = null;
        foreach (var skill in skills)
        {
            if(code == skill.code)
            {
                return skill;
            }
        }
        return result;
    }
}
