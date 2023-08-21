using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Unity.VisualScripting;
using System;
using UnityEditor;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Texture2D mouseCursor;

    [SerializeField] AudioData gameMusic;
    [SerializeField] AudioSource playSFX;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerStart;

    [SerializeField] private float gameTimerMax = 60;

    [Header("Events")]
    [SerializeField] EventRouter startGameEvent;
    [SerializeField] EventRouter stopGameEvent;
    [SerializeField] EventRouter winGameEvent;

    public SimpleDiaolgueManager dialogue;
    GameObject cplayer;

    DateTime startTime = DateTime.Now;
    //DateTime endTime;
    private float score = 5000;
    private int coins = 0;
    
   
    public enum State
    { 
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER,
        GAME_WON
    }

    State state = State.TITLE;
    float stateTimer = 0;
    private void Start()
    {
        if (mouseCursor != null) Cursor.SetCursor(mouseCursor, Vector2.zero, CursorMode.Auto);
        UIManager.Instance.SetCoin(coins);
        //foreach (var enemies in FindObjectsOfType<AICharacter2D>())
        //{
        //    totalEnemies++;
        //}
    }

	private void Update()
	{
        if (Input.GetMouseButtonDown(1)) SetGameOver();
        //float timeSpeed = FindObjectOfType<TimeManager>().timeSpeed;
        var music = GetComponent<AudioSource>();

        switch (state)
        {
            case State.TITLE:
                //Debug.Log("Title");
                music.Stop();
                //gameMusic.Play(transform);
                //if (!gameMusicPlayer.isPlaying) gameMusicPlayer.Play();
                
                
                UIManager.Instance.ShowTitle(true);
                UIManager.Instance.ShowGameOver(false);

				break;
            case State.START_GAME:
                //Debug.Log("Start Game II");
                UIManager.Instance.SetScore((int)score);
                if (music != null)
                {
                    //music.clip = gameMusic.audioClips[0];
                    music.Play();
                }
                startGameEvent.Notify();
				//gameTimer = gameTimerMax;
                //gameMusicPlayer.Stop();
                //gameMusicPlayer.clip = gameMusic;
                //gameMusicPlayer.Play();
                UIManager.Instance.ShowTitle(false);

                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                score -= Time.deltaTime * 5;
                UIManager.Instance.SetScore((int)score);

                break;
            case State.GAME_OVER:
                //Debug.Log("Game Over");
                if (music != null)
                {
                    music.Stop();
                }
                stateTimer -= Time.deltaTime;
                if (stateTimer <= 0)
                {
                    UIManager.Instance.ShowGameOver(false);
                    state = State.TITLE;
                }
                break;
            case State.GAME_WON:

                stateTimer -= Time.deltaTime;
				if (stateTimer <= 0)
				{
					UIManager.Instance.ShowGameWin(false);
					state = State.TITLE;
				}
				break;
		}
        //Debug.Log(state);
        if (cplayer != null)
        {
            //Debug.Log(cplayer.transform.position);
        }
	}

	private void FixedUpdate()
	{
		//var player = FindObjectOfType<RollerPlayer>();
  //      if (player != null) 
  //      { 
  //          transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.2f);
  //      }
	}

	
    //public void AddTime(float time)
    //{
    //    gameTimer+= time;
    //    gameTimer = Mathf.Clamp(gameTimer, 0, gameTimerMax);
    //}

    public void SetGameOver()
    {
		stopGameEvent.Notify();
		//gameMusic.Stop();
		UIManager.Instance.ShowGameOver(true);
        state = State.GAME_OVER;
        stateTimer = 3;
        //Debug.Log("gameover");
    }
	public void SetGameWon()
	{
		//gameMusicPlayer.Stop();
		UIManager.Instance.ShowGameWin(true);
        //UIManager.Instance.SetTimer(DateTime.Now - startTime);
		state = State.GAME_WON;
		stateTimer = 5;
	}
	public void OnStartGame()
    {
        //FindObjectOfType<ArenaManager>().ResetArena();
        //var respawns = FindObjectsOfType<Respawnable>();
        //foreach (var respawn in respawns)
        //{
        //    respawn.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //}
        startGameEvent.Notify();
        playSFX.Play();
        //Debug.Log("Start game");
        state = State.START_GAME;
    }
    public void AddScore(int score)
    {
        this.score += score;
        UIManager.Instance.SetScore((int)this.score);
    }
    //public void AddKill()
    //{
    //    enemyKills++;
    //}
    public void AddCoin()
    {
        coins++;
        UIManager.Instance.SetCoin(coins);
    }

    public void OnApplicationQuit()
    {
        playSFX.Play();
        Application.Quit();
        EditorApplication.isPlaying = false;
    }

    public void EndOfDay()
    {
        dialogue.EndDialogue();
        UIManager.Instance.ShowEndOfDay(true);

        StartCoroutine(TimeCoroutine());

    }
    IEnumerator TimeCoroutine()
    {
        yield return new WaitForSeconds(2.0f);


        UIManager.Instance.ShowEndOfDay(false);
    }
}
