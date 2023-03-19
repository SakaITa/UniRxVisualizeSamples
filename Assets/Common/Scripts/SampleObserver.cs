using System;
using UniRx;
using UnityEngine;

namespace UniRxVisualizeSamples.Common
{
    public class SampleObserver : MonoBehaviour, IObserver<ObserveData>
    {
        [Header("Icon")] 
        [SerializeField] private ObserveIcon iconPrefab = default;
        
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(ObserveData value)
        {
            // 配下にアイコンオブジェクトを追加する
            var observeIcon = Instantiate(iconPrefab, transform);
            
            observeIcon.Shape = value.IconShape;
            observeIcon.Color = value.IconColor;
            observeIcon.Index = value.Index;
        }
    }
}