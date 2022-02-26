using System.Collections;
using DG.Tweening;
using UnityEngine;
using Utils;

namespace Level
{
    public class LevelHandler : MonoBehaviourSingleton<LevelHandler>
    {
        private IEnumerator Start()
        {
            Sequence seq = DOTween.Sequence();
            seq.Join(transform.DOMove(transform.position, 1f));
            seq.Join(transform.DORotate(Vector3.zero, 5f));
            yield return seq.WaitForCompletion();
            Debug.Log("aa");
        }
    }
}
