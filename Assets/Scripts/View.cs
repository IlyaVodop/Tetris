using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] Text score;
    
    public void Init(IScoreSender sender)
    {
        sender.OnScoreSend += (scoreCount) =>
        {
            score.text = scoreCount.ToString();
        };
    }
}
