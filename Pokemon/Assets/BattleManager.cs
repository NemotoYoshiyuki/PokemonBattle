using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {
    public Text text;
    public GameObject[] wildPokemons;
    public GameObject enemyPosition;
    public GameObject myPosition;

    public GameObject enemyPokemon;
    public GameObject myPokemon;

    public GameObject enemy;
    public GameObject my;

    public Pokemon myPokemonStatus;
    public Pokemon enemyStatus;

    public bool myTurn;

    //セットアップに使う
    //敵の情報
    public Text enemyName;
    public Text enemyLv;
    public Text enemyHp;

    //自分のポケモンの情報
    public Text myName;
    public Text myLv;
    public Text myHp;

    public BaseSkill skill;
    // Use this for initialization
    void Start () {
        RandomEncounter();
	}
	
	// Update is called once per frame
	void Update () {
        enemyHp.text = enemyStatus.maxHp + " / " + enemyStatus.hp;
        myHp.text = myPokemonStatus.maxHp + " / " + myPokemonStatus.hp;
        if (enemyStatus.hp <= 0)
        {
            Destroy(enemy,1f);
        }
        else if (myPokemonStatus.hp <= 0)
        {
            Destroy(myPokemon,1f);
        }

    }

    private void RandomEncounter()
    {   
        enemyPokemon = wildPokemons[Random.Range(0, wildPokemons.Length)];
        enemy= Instantiate(enemyPokemon, enemyPosition.transform.position, Quaternion.identity) as GameObject;
        my = Instantiate(myPokemon, myPosition.transform.position, Quaternion.identity) as GameObject;
        //子要素にする
        enemy.transform.parent = enemyPosition.transform;
        my.transform.parent = myPosition.transform;
        //スクリプトの所得
        myPokemonStatus = my.GetComponent<Pokemon>();
        enemyStatus = enemy.GetComponent<Pokemon>();
        //自分ポケモンの画像を背中の画像に変更する
        SpriteRenderer backImage = my.GetComponent<SpriteRenderer>();
        backImage.sprite = myPokemonStatus.backImage;
        //以降する
        Invoke("SetUp", 1f);       
    }

    public void SetUp()
    {
        //敵、自分のステータス情報           
        enemyName.text = enemyStatus.name;
        enemyLv.text = ""+enemyStatus.lv;
       // enemyHp.text = enemyStatus.maxHp+"/"+enemyStatus.hp;
        myName.text = myPokemonStatus.name;
        myLv.text = ""+myPokemonStatus.lv;
       // myHp.text = myPokemonStatus.maxHp + "" + myPokemonStatus.hp;
        text.text = enemy.name + "が現れた";
        Turn();      
    }

    public void Turn()
    {
        //スピードの速いポケモンが先行
        if (myPokemonStatus.speed > enemyStatus.speed)
        {
            MyTurn();           
        }
        else 
        {
            EnemyTurn();           
        }
    }

    public void EnemyTurn()
    {
        myTurn = false;
        ////技を選択する
        int skillSelect = Random.Range(1,4);
        skill.Skills(skillSelect);
        Debug.Log("敵のターン");
    }

    public void MyTurn()
    {
        myTurn = true;
        //技を選択する
        Debug.Log("自分のターン");
    }

    public void Battle(string skillname,int Power,int hit,int PP)
    {
        Pokemon my = myPokemonStatus;
        Pokemon enemy = enemyStatus;
        //自分のターンの時
        if (myTurn == true)
        {
            float damage = ((my.lv * 2 / 5 + 2) * Power * my.attack / enemy.defence / 50 + 2) * 100 / 100;
            enemy.hp -= (int)damage;
            text.text = my.name +"の"+ skillname + damage+"ダメージ";
            myTurn = false;
            //EnemyTurn();
            Invoke("EnemyTurn", 1f);
        }
        else if (myTurn == false)
        {
            float damage = ((enemy.lv * 2 / 5 + 2) * Power * enemy.attack / my.defence / 50 + 2) * 100 / 100;
            my.hp -= (int)damage;
            text.text = enemy.name + "の" + skillname + damage + "ダメージ";
            myTurn = true;
            Debug.Log("自分の攻撃");
        }        
    }

    public void Bag()
    {
        if (myTurn == true)
        {

        }
    }

    public void Run()
    {
        if (myTurn == true)
        {

        }
    }
}
