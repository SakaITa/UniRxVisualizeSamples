using System;
using System.Linq;
using UniRx;
using UniRxVisualizeSamples.Common;
using UnityEngine;

namespace UniRxVisualizeSamples.Samples.Concat
{
    public class Concat : MonoBehaviour
    {
        [Header("Observable")] 
        [SerializeField] private SampleObservable[] observables  = default;

        [Header("Observer")] 
        [SerializeField] private SampleObserver observer = default;

        private void Start()
        {
            observables
                .Select(observable => observable.Observable)
                .Concat()
                .Subscribe(observer)
                .AddTo(this);
        }
    }
}