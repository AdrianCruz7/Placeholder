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
    [SerializeField] Timer timer;

    [SerializeField] private float gameTimerMax = 60;

    [Header("Events")]
    [SerializeField] EventRouter startGameEvent;
    [SerializeField] EventRouter stopGameEvent;
    [SerializeField] EventRouter winGameEvent;

    public SimpleDiaolgueManager dialogue;
    public Dialogue endDiaglogue;
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
        GAME_END
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
                UIManager.Instance.ShowDeadScreen(false);
                UIManager.Instance.ShowGameEnd(false);

                break;
            case State.START_GAME:
                UIManager.Instance.ShowGameEnd(false);
                //Debug.Log("Start Game II");
                UIManager.Instance.SetScore((int)score);
                if (music != null)
                {
                    music.Play();
                }
                startGameEvent.Notify();
                UIManager.Instance.ShowTitle(false);

                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                score -= Time.deltaTime * 5;
                UIManager.Instance.SetScore((int)score);

                break;
            case State.GAME_OVER:

                UIManager.Instance.ShowDeadScreen();
                
                break;
            case State.GAME_END:


                break;
        }
        //Debug.Log(state);
        if (cplayer != null)
        {
            //Debug.Log(cplayer.transform.position);
        }
    }

    public void SetGameOver()
    {
        //stopGameEvent.Notify();
        state = State.GAME_OVER;

    }
    public void SetGameEnd()
    {

        UIManager.Instance.ShowGameEnd(true);
        state = State.GAME_END;

    }
    public void OnStartGame()
    {

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

    public void AddCoin()
    {
        coins++;
        UIManager.Instance.SetCoin(coins);
    }

    public void OnApplicationQuit()
    {
        playSFX.Play();
        Application.Quit();
<<<<<<< Updated upstream
        //EditorApplication.isPlaying = false;
=======
      //  EditorApplication.isPlaying = false;
>>>>>>> Stashed changes
    }

    public void EndOfDay()
    {
        dialogue.EndDialogue();
        UIManager.Instance.ShowEndOfDay(true);

        StartCoroutine(TimeCoroutine());
        if (timer.days == 3)
        {
            state = State.GAME_OVER;
        }

    }
    IEnumerator TimeCoroutine()
    {
        yield return new WaitForSeconds(2.0f);


        UIManager.Instance.ShowEndOfDay(false);
    }

    public void MainScreen()
    {
        UIManager.Instance.ShowTitle();
    }

}
