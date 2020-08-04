// ----------------------------------------------------------------------------
// The MIT License
// LeopotamGroupLibrary https://github.com/Leopotam/LeopotamGroupLibraryUnity
// Copyright (c) 2012-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;


namespace Caxapexac.Common.Sharp.Runtime.Animation
{
    /// <summary>
    /// Set Animator trigger parameter to new state on node enter.
    /// </summary>
    public sealed class SetTriggerOnStateEnter : StateMachineBehaviour
    {
        [SerializeField]
        private string TriggerName = "";

        [SerializeField]
        private bool TriggerValue = false;

        private int _fieldHash = -1;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            if (_fieldHash == -1)
            {
#if UNITY_EDITOR
                if (string.IsNullOrEmpty(TriggerName))
                {
                    Debug.LogWarning("Trigger field name is empty", animator);
                    return;
                }
#endif
                _fieldHash = Animator.StringToHash(TriggerName);
            }

            if (TriggerValue)
            {
                animator.SetTrigger(_fieldHash);
            }
            else
            {
                animator.ResetTrigger(_fieldHash);
            }
        }
    }
}