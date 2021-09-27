using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    public GameObject TV_Table;
    public GameObject TV;
    public GameObject Teapoy;
    public GameObject Sofa;
    public GameObject Table;
    public GameObject Romoter;
    public GameObject Carpet;
    public GameObject Catcus;
    public GameObject Painting;
    public GameObject Windows;
    public GameObject Milk;
    public GameObject Platte;

    public int MoodValue_max = 10;
    int currentMoodValue;
   
    public int CleanValue_max = 10;
    int currentCleanValue;

    static ObjectManager s_Instance;
    public static ObjectManager Instance => s_Instance;

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
        currentMoodValue = 0;
        currentCleanValue = 0;
        UI_MoodBar.instance.SetValue(currentMoodValue / (float)MoodValue_max);
        UI_CleanBar.instance.SetValue(currentCleanValue / (float)CleanValue_max);
    }

    public void OpenTV()
    {
        if (TV.gameObject.GetComponent<Television>().isTurnedOn == true)
        {
            ChangeMood(1);
        }
    }

    public void ChangeMood(int amount)
    {
        currentMoodValue = Mathf.Clamp(currentMoodValue + amount, 0, MoodValue_max);
        UI_MoodBar.instance.SetValue(currentMoodValue / (float)MoodValue_max);
    }

    public void ChangeClean(int amount)
    {
        currentCleanValue = Mathf.Clamp(currentCleanValue + amount, 0, CleanValue_max);
        UI_CleanBar.instance.SetValue(currentCleanValue / (float)CleanValue_max);
    }

}
