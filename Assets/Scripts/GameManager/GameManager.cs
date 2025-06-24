using UnityEngine;

public class GameManager : MonoBehaviour
{
    Hp _hp = new Hp();
    Score _score = new Score();

    public void Init()
    {
        _hp.Init();
        _score.Init();
    }
}