using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool playerTurn;
    public static bool newFight;
    
    public GameObject enemy;
    private GameObject clone;


    private static bool lockTurn;
    void Start()
    {
        playerTurn = true;
        newFight = true;
        lockTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (newFight)
            InitFight();
        if (!lockTurn)
            HandleTurn();
    }

    void InitFight()
    {
        newFight = false;
        print("I made an enemy!");

        clone = Instantiate(enemy, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
    }

    void HandleTurn()
    {
        lockTurn = true;
        if (!playerTurn)
        {
            clone.GetComponent<Enemy>().DoTurn();
            playerTurn = true;
        }
        lockTurn = false;
    }
}
