using UnityEngine;
using UnityEngine.UI;
using Utils;

public class Score : MonoBehaviour, IMediatorEvent
{
    [SerializeField] Text _scoreText;

    MediatorManager _mediatorManager;

    int _score;
    int _ryoikiTenkaiScore = 100;

    void Start()
    {
        _mediatorManager = GenericSingleton<MediatorManager>.Instance;
        _mediatorManager.Register(EMediatorEventType.AddScore, this);
        ShowScore();
    }

    void ShowScore()
    {
        _scoreText.text = $"Á¡¼ö : {_score}";
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        Debug.Log($"HandleEvent : {data}");
        _score += (int)data;
        ShowScore();
        if (_ryoikiTenkaiScore <= _score)
            _mediatorManager.Notify(EMediatorEventType.RyoikiTenkaiEvent);
    }
}