using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text _text;
    private string _template;
    private int _currentPoints;
    
    void Awake()
    {
        _text = GetComponent<Text>();
        _template = _text.text;
    }

    public void AddPoint()
    {
        _currentPoints++;
        _text.text = _template.Replace("XXX", _currentPoints.ToString());
    }
}
