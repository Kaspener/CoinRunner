using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetCoinsCount : MonoBehaviour
{
    public TMP_Text text;
    void Start()
    {
        text.text = PlayerPrefs.GetInt("coins").ToString();
    }
}
