using UnityEngine;
using System.Collections;

public class BttleBotton : MonoBehaviour
{
    public GameObject Default;
    public GameObject PusuhFight;
    public BattleManager battleManager;

    // Use this for initialization
     public void OnFight()
    {
        if (battleManager.myTurn == true)
        {
            Default.SetActive(false);
            PusuhFight.SetActive(true);
        }
    }
}
