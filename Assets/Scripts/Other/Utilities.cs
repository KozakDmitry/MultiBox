using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Other
{
    public static class Utilities 
    {
        public const string CLIP_NAME_OUT = "Out";
        public const string CLIP_NAME_IN = "In";
        public static IEnumerator PlayAnimAndSetStateWhenFinished(GameObject parent,Animator animator, string clipName, bool activeStateAtTheEnd = true)
        {
            animator.Play(clipName);
            float animatorLength = animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSecondsRealtime(animatorLength);
            parent.SetActive(activeStateAtTheEnd);
        }
    }
}