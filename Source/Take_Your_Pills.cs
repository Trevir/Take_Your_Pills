using System;
using Verse;
using RimWorld;

namespace Take_Your_Pills
{
    public class TYPLearnLowestSkill : IngestionOutcomeDoer
    {
        private const float XPGainAmount = 500f;

        protected override void DoIngestionOutcomeSpecial(Pawn user, Thing ingested)
        {
            float lowest_skill_value = 10000000;
            SkillDef skill = user.skills.skills[ 0 ].def;
            foreach (SkillRecord element in user.skills.skills)
            {
                if (element != null && !element.TotallyDisabled)
                {
                    if (lowest_skill_value > element.XpTotalEarned)
                    {
                        lowest_skill_value = element.XpTotalEarned;
                        skill = element.def;
                    }
                }
            }            
            
            int level = user.skills.GetSkill(skill).Level;
            user.skills.Learn(skill, XPGainAmount, true);
            int level2 = user.skills.GetSkill(skill).Level;
        }
    }
}