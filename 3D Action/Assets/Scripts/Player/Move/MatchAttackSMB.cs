using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchAttackSMB : StateMachineBehaviour
{
    IMatchTarget target;
    [SerializeField] AvatarTarget _targetBodyPart = AvatarTarget.Root;
    [SerializeField] Vector2 _efffectiveRange;
    [SerializeField, Range(0, 1)] float _assistPower = 1;
    [SerializeField, Range(0, 10)] float _assistDistance = 1;

    MatchTargetWeightMask _weightMask;

    bool isSkip = false;
    bool isInitialized = false;
    public IMatchTarget Target { get => target; set => target = value; }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!isInitialized)
        {
            var weight = new Vector3(_assistPower, 0, _assistPower);
            _weightMask = new MatchTargetWeightMask(weight, 0);
            isInitialized = true;
        }
        if (target != null)
        {
            isSkip = Vector3.Distance(target.TargetPosition, animator.rootPosition) > _assistDistance;
        }
        
    }

    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isSkip || animator.IsInTransition(layerIndex) || target == null)
        {
            return;
        }
        if (stateInfo.normalizedTime > _efffectiveRange.y)
        {
            animator.InterruptMatchTarget(false);
        }
        else
        {
            animator.MatchTarget(
                target.TargetPosition,
                animator.bodyRotation,
                _targetBodyPart,
                _weightMask,
                _efffectiveRange.x, _efffectiveRange.y);
        }
    }
}
public interface IMatchTarget
{
    Vector3 TargetPosition { get; }
}

