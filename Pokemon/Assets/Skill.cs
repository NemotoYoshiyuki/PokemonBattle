using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {
    public GameObject Default;
    public GameObject PusuhFight;
    //public string skillName;
    //public int power;
    //public int hit;
    //public int pp;

    public BattleManager battleManager;

    public void SkillTemplate(string skillName, int power, int hit, int pp)
    {
        battleManager.Battle(skillName, power, hit, pp);
        Default.SetActive(true);
        PusuhFight.SetActive(false);
    }

    public void Tackle()
    {
        //skillName = "たいあたり";
        //power = 50;
        //hit = 100;
        //pp = 35;
        SkillTemplate("体当たり", 50, 100, 35);
    }

    public void VineWhip()
    {
        //skillName = "つるのむち";
        //power = 45;
        //hit = 100;
        //pp = 25;
        SkillTemplate("つるのむち", 60, 100, 35);
    }

    public void hakaikousen()
    {
        SkillTemplate("はかいこうせん", 150, 90, 5);
    }

    public void hinoko()
    {
        SkillTemplate("ひのこ", 70, 100, 35);
    }
}
