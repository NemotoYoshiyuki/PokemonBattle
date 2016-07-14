using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleContlor : MonoBehaviour {
    public Text message;
    public GameObject[] wildPokemons;
    public GameObject enemyPosition;
    public GameObject myPosition;

    public GameObject enemyPokemon;
    public GameObject myPokemon;

    public GameObject enemy;
    public GameObject my;

    public BasePokemon myPokemonStatus;
    public BasePokemon enemyStatus;

    //セットアップに使う
    //敵の情報
    public Text enemyName;
    public Text enemyLv;
    public Text enemyHp;

    //自分のポケモンの情報
    public Text myName;
    public Text myLv;
    public Text myHp;

    enum State
    {
        Ready,
        MyTurn,
        EnemyTurn,
        End
    }

    State state;

    // Use this for initialization
    void Start () {
        RandomEncounter();

    }
	
	// Update is called once per frame
	void Update () {

        switch (state)
        {
            case State.Ready:
                break;
            case State.MyTurn:
                //自分番
                if (enemyStatus.hp <= 0)
                {
                    Run();
                }
                MyTurn();
                break;
            case State.EnemyTurn:
                //相手のターン番
                EnemyTurn();
                break;
            case State.End:
                //終わり
                break;
        }           
	}

    private void RandomEncounter()
    {
        enemyPokemon = wildPokemons[Random.Range(0, wildPokemons.Length)];
        enemy = Instantiate(enemyPokemon, enemyPosition.transform.position, Quaternion.identity) as GameObject;
        my = Instantiate(myPokemon, myPosition.transform.position, Quaternion.identity) as GameObject;
        //子要素にする
        enemy.transform.parent = enemyPosition.transform;
        my.transform.parent = myPosition.transform;
        //スクリプトの所得
        myPokemonStatus = my.GetComponent<BasePokemon>();
        enemyStatus = enemy.GetComponent<BasePokemon>();
        //自分ポケモンの画像を背中の画像に変更する
        SpriteRenderer backImage = my.GetComponent<SpriteRenderer>();
        backImage.sprite = myPokemonStatus.backImage;
        Invoke("SetUp",0.5f);
    }

    public void SetUp()
    {
        //敵、自分のステータス情報           
        enemyName.text = enemyStatus.name;
        enemyLv.text = "" + enemyStatus.lv;
        enemyHp.text = enemyStatus.maxHp + "/" + enemyStatus.hp;
        myName.text = myPokemonStatus.name;
        myLv.text = "" + myPokemonStatus.lv;
        myHp.text = myPokemonStatus.maxHp + "" + myPokemonStatus.hp;
        message.text = enemy.name + "が現れた";
        Turn();
    }

    public void Turn()
    {
        //スピードの速いポケモンが先行
        if (myPokemonStatus.speed > enemyStatus.speed)
        {
            state = State.MyTurn;
        }
        else
        {
            state = State.EnemyTurn;
        }
    }

    public void EnemyTurn()
    {
        Debug.Log("敵のターン");
        state = State.MyTurn;
    }

    public void MyTurn()
    {
        //技を選択する
        Debug.Log("自分のターン");
        state = State.EnemyTurn;
    }

    public void Battle(string skillname, int Power, int hit, int PP)
    {
        BasePokemon my = myPokemonStatus;
        BasePokemon enemy = enemyStatus;
        float damage = ((my.lv * 2 / 5 + 2) * Power * my.attack / enemy.defence / 50 + 2) * 100 / 100;
        enemy.hp -= (int)damage;
        message.text = enemy.hp + "";
    }

    public void Bag()
    {

    }

    public void Run()
    {
        state = State.End;
        Debug.Log("戦闘終わり");
        return;
    }
}
