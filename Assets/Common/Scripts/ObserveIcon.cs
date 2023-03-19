using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxVisualizeSamples.Common
{
    public class ObserveIcon : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage = default;
        [SerializeField] private TMP_Text indexText = default;

        public Sprite Shape
        {
            get => backgroundImage.sprite;
            set => backgroundImage.sprite = value;
        }

        public Color Color
        {
            get => backgroundImage.color;
            set => backgroundImage.color = value;
        }

        public int Index
        {
            get => int.Parse(indexText.text);
            set => indexText.text = value.ToString();
        }
    }
}