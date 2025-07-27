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
        // 현재 재생 중인 애니메이션의 normalizedTime을 반환 (0 ~ 1)
        AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
        return state.normalizedTime % 1f;
    }

    public int GetAnimationHash()
    {
        // 현재 재생 중인 애니메이션의 fullPathHash 값을 반환
        AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
        return state.fullPathHash;
    }

    // 체조로 복귀
    public void ReturnToGymnastics()
    {
        // 현재 애니메이션 정보 가져오기
        int currentHash = _studentManager.GetCurrentAnimationHash();
        float currentTime = _studentManager.GetCurrentAnimationTime();

        // 동일한 애니메이션을 같은 타이밍에서 재생
        _animator.Play(currentHash, 0, currentTime);

        // 상태 전환
        _currentType = EStudentType.Gymnastics;
        _currentState = _studentStateDict[_currentType];
    }

    public void ReturnToGymnastics(int hash, float time)
    {
        _animator.Play(hash, 0, time);
        _currentType = EStudentType.Gymnastics;
        _currentState = _studentStateDict[_currentType];
    }

    public void ChangeAnimationSpeed(float speed)
    {
        _animator.speed = speed;
    }

    public float GetAnimationSpeed()
    {
        return _animator.speed;
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
            ReturnToGymnastics();
        }
    }
    #endregion
}