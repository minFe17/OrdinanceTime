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

    public EStudentType CurrentType { get=>_currentType; }


    #region Unity Lifecycle
    void Start()
    {
        _studentManager = GenericSingleton<StudentManager>.Instance;
        SetState();
    }

    void Update()
    {
        Loop();
    }
    #endregion

    #region FSM
    void SetState()
    {
        _studentStateDict = new Dictionary<EStudentType, IStudentState>
        {
            { EStudentType.Gymnastics, new GymnasticsType(this) },
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
        if(_currentState != null)
            _currentState.Exit();
        _currentType = type;
        _currentState = _studentStateDict[_currentType];
        _currentState.Enter();
    }
    #endregion

    #region Animation
    public void ChangeAnimation(string name, bool value)
    {
        // SetBool
    }

    public void ChangeAnimation(string name)
    {
        // SetTrigger
    }

    public float GetAnimationTime()
    {
        AnimatorStateInfo state =  _animator.GetCurrentAnimatorStateInfo(0);
        return state.normalizedTime % 1f;
    }

    public void ReturnToGymnastics()
    {
        float time = _studentManager.GetCurrentAnimationTime();
        //_animator.Play("", 0, time);
        ChangeState(EStudentType.Gymnastics);   
    }
    #endregion

    #region Unity Click Event
    public void OnMouseDown()
    {
        if (_currentType == _studentManager.TargetStateType)
        {
            GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.ChangeHP, -1);
        }
        else
        {
            GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.AddScore, 50);
        }
    }
    #endregion
}