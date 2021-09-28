using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MoodBar : MonoBehaviour
{
    public Image mask;
    private float originalSize;

    static UI_MoodBar s_Instance;
    public static UI_MoodBar Instance => s_Instance;

    void Awake()
    {
        if (s_Instance != null)
        {
            Destroy(this);
            return;
        }

        s_Instance = this;
    }

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }


    /// <param name="fillPercent">填充百分比</param>
    public void SetValue(float fillPercent)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.
            Axis.Horizontal, originalSize * fillPercent);
    }
}
