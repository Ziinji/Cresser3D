using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageMenu : MonoBehaviour
{
    public Text StageSelect;
    public static int stage = 1;

    public void changeStage()
    {
        if (int.TryParse(StageSelect.text, out stage))
        {
            Debug.Log("Parsed");
            stage = int.Parse(StageSelect.text);
        }
        else
        {
            Debug.Log("Parsing failed");
            Debug.Log(StageSelect.text.Length);
            Debug.Log(StageSelect.text);
        }
    }
}
