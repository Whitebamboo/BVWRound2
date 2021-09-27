using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    HappinessState,
    CleaningState,
    EndingState
}

public class GameManager : MonoBehaviour
{
    static GameManager s_Instance;
    public static GameManager Instance => s_Instance;

    public float happinessStateTime;
    public float cleaningStateTime;

    [HideInInspector] public GameState state;

    float m_currentStateTime;
    public float CurrentStateTime => m_currentStateTime;

    void Awake()
    {
        if (s_Instance != null)
        {
            Destroy(this);
            return;
        }

        s_Instance = this;
    }

    private void Start()
    {
        state = GameState.HappinessState;

        m_currentStateTime = happinessStateTime;
        ProcessHappinessState();
    }

    void Update()
    {
        m_currentStateTime -= Time.deltaTime;

        if(m_currentStateTime < 0 && state == GameState.HappinessState)
        {
            m_currentStateTime = cleaningStateTime;

            state = GameState.CleaningState;
            ProcessCleaningState();          
        }

        if(m_currentStateTime < 0 && state == GameState.CleaningState)
        {
            state = GameState.EndingState;
            ProcessEndingState();
        }
    }

    void ProcessHappinessState()
    {
        MusicManager.Instance.PlayHappinessStateClip();
    }

    void ProcessCleaningState()
    {
        StartCoroutine(MusicManager.Instance.PlayCleaningStateClip());
        
    }

    void ProcessEndingState()
    {
        SceneManager.LoadScene("EndScene");
    }
}
