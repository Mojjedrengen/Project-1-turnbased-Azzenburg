using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOST };
public class NewBattleSystemManager : MonoBehaviour
{
    public GameObject turn;

    public GameObject player;
    public GameObject enemy;

    //public static CurrChar currPlayer = new CurrChar();
    public CurrChar currPlayer;
    public CurrEnemy currEnemy = new CurrEnemy(EnemyMove.name);

    public StatusHUD playerStatusHUD;
    public StatusHUD enemyStatusHUD;

    private BattleState battleState;

    private bool hasClicked = true;

    // Start is called before the first frame update
    void Start()
    {
        battleState = BattleState.START;
        StartCoroutine(BeginBattle());
    }

    // Update is called once per frame
    void Update()
    {
        turn.GetComponent<TextMeshProUGUI>().text = battleState.ToString();
    }

    IEnumerator BeginBattle()
    {
        Debug.Log(currPlayer.name);
        player.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load(currPlayer.name, typeof(Sprite));
        enemy.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load(EnemyMove.name, typeof(Sprite));
        //makes them invisible in the start
        enemy.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

        // Sets up the HUD
        playerStatusHUD.SetStatusHUD(currPlayer);
        enemyStatusHUD.SetStatusHUDEnemy(currEnemy);

        yield return new WaitForSeconds(1);

        // Fades in the character
        yield return StartCoroutine(FadeInOpponents());

        yield return new WaitForSeconds(2);

        // Player Tyrn!
        battleState = BattleState.PLAYERTURN;

        //lets player do their turn
        yield return StartCoroutine(PlayerTurn());
    }

    IEnumerator FadeInOpponents(int steps = 10)
    {
        float totalTransperencyPerStep = 1 / (float)steps;

        for (int i = 0; i < steps; i++)
        {
            setSpriteOpacity(player, totalTransperencyPerStep);
            setSpriteOpacity(enemy, totalTransperencyPerStep);
            yield return new WaitForSeconds(0.05F);
        }
    }
    private void setSpriteOpacity(GameObject ob, float transPerStep)
    {
        Color currColor = ob.GetComponent<SpriteRenderer>().color;
        float alpha = currColor.a;
        alpha += transPerStep;
        ob.GetComponent<SpriteRenderer>().color = new Color(currColor.r, currColor.g, currColor.b, alpha);
    }

    IEnumerator PlayerTurn()
    {
        // Starting player turn
        yield return new WaitForSeconds(1);

        // release the blockade on clicking 
        // so that player can click on 'attack' button
        hasClicked = false;
    }

    public void OnAttackButtonPress(int i)
    {
        // Don't allow player to click on "attack" button if its not their turn
        if (battleState != BattleState.PLAYERTURN)
        {
            return;
        }
        // allow only a single action per turn
        if (!hasClicked)
        {
            StartCoroutine(PlayerAttack(i));

            // block user from repeatedly 
            // pressing attack button  
            hasClicked = true;
        }
    }

    IEnumerator PlayerAttack(int i)
    {
        // trigger the execution of attack animation
        // in 'BattlePresence' animator
        player.GetComponent<Animator>().SetTrigger("Attack");

        yield return new WaitForSeconds(1);

        player.GetComponent<Animator>().SetTrigger("Idle");

        // decrease enemy health by a fixed
        // amount of 10. You probably want to have some
        // more complex logic here.
        // will change this later
        enemyStatusHUD.SetEnemyHP(currEnemy, 10);

        if (currEnemy.hp <= 0)
        {
            // if the enemy health drops to 0 
            // we won!
            battleState = BattleState.WIN;
            yield return StartCoroutine(EndBattle());
        }
        else
        {
            // if the enemy health is still
            // above 0 when the turn finishes
            // it's enemy's turn!
            battleState = BattleState.ENEMYTURN;
            yield return StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        // as before, decrease playerhealth by a fixed
        // amount of 10. You probably want to have some
        // more complex logic here.
        //will also change this later
        playerStatusHUD.SetHP(currPlayer, currEnemy.dmg);

        // play attack animation by triggering
        // it inside the enemy animator
        enemy.GetComponent<Animator>().SetTrigger("Attack");

        yield return new WaitForSeconds(1);

        enemy.GetComponent<Animator>().SetTrigger("Idle");

        if (currPlayer.hp <= 0)
        {
            // if the player health drops to 0 
            // we have lost the battle...
            battleState = BattleState.LOST;
            yield return StartCoroutine(EndBattle());
        }
        else
        {
            // if the player health is still
            // above 0 when the turn finishes
            // it's our turn again!
            battleState = BattleState.PLAYERTURN;
            yield return StartCoroutine(PlayerTurn());
        }
    }

    IEnumerator EndBattle()
    {
        // check if we won
        if (battleState == BattleState.WIN)
        {
            // you may wish to display some kind
            // of message or play a victory fanfare
            // here
            yield return new WaitForSeconds(2);
            Debug.Log("Won!");
            SceneManager.LoadScene(2);
        }
        // otherwise check if we lost
        // You probably want to display some kind of
        // 'Game Over' screen to communicate to the 
        // player that the game is lost
        else if (battleState == BattleState.LOST)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("LOST :c");
        }
    }
}
