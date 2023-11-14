using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEditor : MonoBehaviour
{
    public static string text;
    public TMP_Text Text;
    void Update()
    {
        print(this.gameObject);
        Text.text = text;
    }
}
