using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pokemon : MonoBehaviour
{

    //ステータス
    public Sprite backImage;
    public string nickName;
    public int type;
    public string typename;
    public int lv;
    public int hp;
    public int maxHp;
    public int attack;
    public int defence;
    public int spAttack;
    public int spDefence;
    public int speed;

    //種族値
    public int baseHP;
    public int baseAttack;
    public int baseDefence;
    public int baseSpAttack;
    public int baseSpDefence;
    public int baseSpeed;

    //個体値・努力値
    public int individualValue;
    public int effortValue;

    void Start()
    {
        Status();
    }

    public void Status()
    {
        Type(type);
        HP();
        MaxHP();
        this.attack = Attack();
        Defence();
        SpAttack();
        SpDefence();
        Speed();
    }

    public int MaxHP()
    {
        maxHp = ((baseHP * 2 + individualValue + effortValue / 4) * lv / 100) + 10 + lv;
        return maxHp;
    }
    public int HP()
    {
        hp = ((baseHP * 2 + individualValue + effortValue / 4) * lv / 100) + 10 + lv;
        return hp;
    }

    public int Attack()
    {
        //[{(種族値×2＋個体値＋努力値/4)×Lv/100}＋5]×性格補正(1.1、1.0、0.9)
        attack = ((baseAttack * 2 + individualValue + effortValue) * lv / 100) + 5;
        return attack;
    }

    public int Defence()
    {
        defence = ((baseDefence * 2 + individualValue + effortValue) * lv / 100) + 5;
        return defence;
    }

    public int SpAttack()
    {
        spAttack = ((baseSpAttack * 2 + individualValue + effortValue) * lv / 100) + 5;
        return spAttack;
    }

    public int SpDefence()
    {
        spDefence = ((baseSpDefence * 2 + individualValue + effortValue) * lv / 100) + 5;
        return spDefence;
    }

    public int Speed()
    {
        speed = ((baseSpeed * 2 + individualValue + effortValue) * lv / 100) + 5;
        return speed;
    }

    
    public void Type(int type)
    {
        switch (type)
        {
            case 0:
                typename = "";
                break;
            case 1:
                typename = "ノーマル";
                break;
            case 2:
                typename = "ほのう";
                break;
            case 3:
                typename = "くさ";
                break;
            case 4:
                typename = "みず";
                break;
            case 5:
                typename = "でんき";
                break;
            case 6:
                typename = "ひこう";
                break;
        }
    }
}
