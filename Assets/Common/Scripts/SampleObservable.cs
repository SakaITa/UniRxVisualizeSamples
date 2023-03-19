using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxVisualizeSamples.Common
{
    public class SampleObservable : MonoBehaviour
    {
        [Header("Icon")] 
        [SerializeField] private ObserveIcon icon = default;

        [Header("Buttons")]
        [SerializeField] private Button onNextButton = default;
        [SerializeField] private Button onCompleteButton = default;

        private readonly Subject<ObserveData> observable = new();
        public IObservable<ObserveData> Observable => observable;

        private Sprite iconShape = default;
        private Color iconColor = Color.white;

        private void Start()
        {
            iconShape = icon.Shape;
            iconColor = icon.Color;
            
            var currentIndex = new ReactiveProperty<int>(1);

            // 現在のインデックスを表示に反映
            currentIndex
                .Subscribe(index => icon.Index = index)
                .AddTo(this);

            // OnNextボタンが押されたら通知を送る
            onNextButton
                .OnClickAsObservable()
                .Select(_ => new ObserveData(
                    iconShape,
                    iconColor,
                    currentIndex.Value))
                // インデックスを進める（ただし、1桁で折り返す）
                .Do(_ => currentIndex.Value = (currentIndex.Value + 1) % 10)
                .Subscribe(data => observable.OnNext(data))
                .AddTo(this);

            // OnCompleteボタンが押されたら完了にする
            onCompleteButton
                .OnClickAsObservable()
                .Do(_ => DisableButtons())
                .Subscribe(_ => observable.OnCompleted())
                .AddTo(this);
        }

        /// <summary>
        /// ボタンを利用不可にする
        /// </summary>
        private void DisableButtons()
        {
            onNextButton.interactable = false;
            onCompleteButton.interactable = false;
        }
    }
}

