using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public MusicPlayer musicPlayer;
    
    private Text _text;
    private string _template;
    private int _currentPoints = -1;
    
    void Awake()
    {
        _text = GetComponent<Text>();
        _template = _text.text;
        AddPoint();
    }

    public void AddPoint()
    {
        _currentPoints++;
        _text.text = _template.Replace("XXX", _currentPoints.ToString());

        if (_currentPoints == 1)
        {
            musicPlayer.PlayWin();
        }
    }
}
