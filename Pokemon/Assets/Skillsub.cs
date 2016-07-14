using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Skillsub : MonoBehaviour
{

    public GameObject myPokemon;
    public GameObject enemyPokemon;
    public GameObject[] wildPokemons;

    public int skillPower; //技の威力
    public int Accuracy; //技の命中率
    public int pp;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Battle()
    {
        //{（攻撃側のレベル × 2 ÷ 5 ＋ 2）× 技の威力 × 攻撃側の能力値 ÷ 防御側の能力値 ÷ 50 ＋ 2}×（85～100）÷ 100 
        enemyPokemon = wildPokemons[Random.Range(0, wildPokemons.Length)];
        Pokemon enemy = enemyPokemon.GetComponent<Pokemon>();
        Pokemon my = myPokemon.GetComponent<Pokemon>();
        float power = ((my.lv * 2 / 5 + 2) * 30 * my.attack / enemy.defence / 50 + 2) * 100 / 100;
        Debug.Log(my.attack);
        Debug.Log(enemy.defence);
        Debug.Log(power);
    }   
}
