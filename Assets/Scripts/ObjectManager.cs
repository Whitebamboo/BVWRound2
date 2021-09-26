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

    public int MoodValue_max=100;
    public int MoodValue_current;


    public int CleanValue_max=100;
    public int CleanValue_current;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeMood(int amount)
    {

        MoodValue_current = Mathf.Clamp(MoodValue_current + amount, 0, MoodValue_max);

       
        UI_MoodBar.instance.SetValue(MoodValue_current / (float)MoodValue_max);
    }



    public void ChangeClean(int amount)
    {

        CleanValue_current = Mathf.Clamp(CleanValue_current + amount, 0, CleanValue_max);


        UI_CleanBar.instance.SetValue(CleanValue_current / (float)CleanValue_max);
    }

}