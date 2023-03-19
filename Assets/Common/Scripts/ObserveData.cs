using UnityEngine;

namespace UniRxVisualizeSamples.Common
{
    public readonly struct ObserveData
    {
        public ObserveData(Sprite iconShape, Color iconColor, int index)
        {
            IconShape = iconShape;
            IconColor = iconColor;
            Index = index;
        }

        public Sprite IconShape { get; }
        public Color IconColor { get; }
        public int Index { get; }
    }
}