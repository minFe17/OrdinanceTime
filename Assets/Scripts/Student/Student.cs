using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Student : MonoBehaviour
{
    Dictionary<EStudentType, IStudentState> _studentStateDict;

    EStudentType _currentType;
    IStudentState _currentState;

    Animator _animator;
    StudentManager _studentManager;

    public EStudentType CurrentType { get => _currentType; }


    #region Unity Lifecycle
    void Start()
    {
        _animator = GetComponent<Animator>();
        _studentManager = GenericSingleton<StudentManager>.Instance;
        SetState();
        Init();
    }

    void Update()
    {
        Loop();
    }
    #endregion

    void Init()
    {
        GenericSingleton<StudentManager>.Instance.AddStudent(this);
    }

    #region FSM
    void SetState()
    {
        _studentStateDict = new Dictionary<EStudentType, IStudentState>
        {
            { EStudentType.Gymnastics, new GymnasticsState(this) },
            { EStudentType.Idle, new IdleState(this) },
            {EStudentType.Stop, new StopState(this) },
            {EStudentType.NanigaSuki, new NanigaSukiState(this) }
            ,{EStudentType.Waflash, new WaflashState(this) }
        };
        ChangeState(EStudentType.Gymnastics);
    }

    void Loop()
    {
        if (_currentState == null)
            return;
        _currentState.Loop();
    }

    public void ChangeState(EStudentType type)
    {
        if (_currentState == _studentStateDict[type])
            return;
        if (_currentState != null)
            _currentState.Exit();
        _currentType = type;
        _currentState = _studentStateDict[_currentType];
        _currentState.Enter();
    }
    #endregion

    #region Animation
    public void ChangeAnimation(string name)
    {
        _animator.Play(name);
    }

    public void ChangeAnimation(string name, int value)
    {
        _animator.SetInteger(name, value);
    }

    public void ChangeAnimationTrigger(string name)
    {
        _animator.SetTrigger(name);
    }

    public float GetAnimationTime()
    {
        AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
        return state.normalizedTime % 1f;
    }

    public int GetAnimationHash()
    {
        AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
        return state.fullPathHash;
    }

    public void ReturnToGymnastics(int hash, float time)
    {
        _animator.CrossFade(hash, 0.2f, 0, time);
        _currentType = EStudentType.Gymnastics;
        _currentState = _studentStateDict[_currentType];
    }

    public void ChangeAnimationSpeed(float speed)
    {
        _animator.speed = speed;
    }
    #endregion

    #region Unity Click Event
    public void OnMouseDown()
    {
        if (_currentType == _studentManager.TargetStateType)
        {
            Debug.Log("Already in target state.");
            GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.ChangeHP, -1);
        }
        else
        {
            Debug.Log($"ChangeState : {_studentManager.TargetStateType}");
            GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.AddScore, 50);
            GameObject temp = Instantiate(GenericSingleton<PrefabManager>.Instance.EffectPrefabLoad.EffectPrefab);
            temp.transform.position += transform.position;
            ChangeState(_studentManager.TargetStateType);
            ReturnToGymnastics(_studentManager.GetCurrentAnimationHash(), _studentManager.GetCurrentAnimationTime());
        }
    }
    #endregion
}