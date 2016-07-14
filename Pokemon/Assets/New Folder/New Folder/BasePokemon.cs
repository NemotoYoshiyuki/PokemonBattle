using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasePokemon : MonoBehaviour
{

    //ステータス
    public Sprite backImage;
    public string nickName;
    public int lv;
    public PokemonType type;
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

    //ポケモンの状態
    public bool isDead;

    public bool IsDead()
    {
        return isDead;
    }

    //技
    public List<int> skillID = new List<int>();

    public enum PokemonType
    {
        Flying,
        Ground,
        Rock,
        Steel,
        Fire,
        Water,
        Grass,
        Ice,
        Electric,
        Psychic,
        Dark,
        Dragon,
        Fighting,
        Normal
    }

    // Use this for initialization
    void Start()
    {   
        maxHp = hp = ((baseHP * 2 + individualValue + effortValue / 4) * lv / 100) + 10 + lv;
        hp = ((baseHP * 2 + individualValue + effortValue / 4) * lv / 100) + 10 + lv;
        attack = ((baseAttack * 2 + individualValue + effortValue) * lv / 100) + 5;
        defence = ((baseDefence * 2 + individualValue + effortValue) * lv / 100) + 5;
        spAttack = ((baseSpAttack * 2 + individualValue + effortValue) * lv / 100) + 5;
        spDefence = ((baseSpDefence * 2 + individualValue + effortValue) * lv / 100) + 5;
        speed = ((baseSpeed * 2 + individualValue + effortValue) * lv / 100) + 5;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}