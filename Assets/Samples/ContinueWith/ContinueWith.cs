using UniRx;
using UniRxVisualizeSamples.Common;
using UnityEngine;

namespace UniRxVisualizeSamples.Samples.ContinueWith
{
    public class ContinueWith : MonoBehaviour
    {
        [Header("Observable")] [SerializeField]
        private SampleObservable observableSource = default;

        [SerializeField] private SampleObservable observableOther = default;

        [Header("Observer")] [SerializeField] private SampleObserver observer = default;

        private void Start()
        {
            observableSource
                .Observable
                .ContinueWith(
                    observableOther.Observable)
                .Subscribe(observer)
                .AddTo(this);
        }
    }
}