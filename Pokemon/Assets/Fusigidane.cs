using UnityEngine;
using System.Collections;

public class Fusigidane : Pokemon {
    
	// Use this for initialization
	void Awake () {
        type = 0;
        lv = 50;
        baseHP = 45;
        baseAttack = 49;
        baseDefence = 49;
        baseSpAttack = 65;
        baseSpDefence = 65;
        baseSpeed = 45;

        individualValue = Random.Range(0,30);
        effortValue = 0;
    }
	
	// Update is called once per frame
	void Update () {
              
    }
}
