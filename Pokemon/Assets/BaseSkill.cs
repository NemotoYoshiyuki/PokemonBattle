using UnityEngine;
using System.Collections;

public class BaseSkill : Skill {

    public void Skills(int skillID)
    {
        switch (skillID)
        {
            case 1:
                Tackle();
                break;
            case 2:
                VineWhip();
                break;
            case 3:
                hakaikousen();
                break;
            case 4:
                hinoko();
                break;
        }
    }
   
}
