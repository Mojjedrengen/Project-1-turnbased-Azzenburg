using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Help from https://pavcreations.com/turn-based-battle-and-transition-from-a-game-world-unity/
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOST };

public class BattleSystemManager : MonoBehaviour
{
    private GameObject enemy;
    private GameObject player;

    public Transform enemyBattlePosition;
    public Transform playerBattlePosition;

    /*
    public CharacterStatus playerStatus;
    public CharacterStatus enemyStatus;

    public StatusHUD playerStatusHUD;
    public StatusHUD enemyStatusHUD;
    */
    private BattleState battleState;

    private bool hasClicked = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
