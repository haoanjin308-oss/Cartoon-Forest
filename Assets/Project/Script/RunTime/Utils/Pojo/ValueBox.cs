using System;
using UnityEngine;

namespace Project.Script.RunTime.Utils.Pojo
{
    [Serializable]
    public class ValueBox<T>
    {
        public Action<T> changeValue;
        [field:SerializeField]
        private T showValue;
        public T Value
        {
            get => showValue;
            set
            {
                if (Equals(showValue, value)) return;
                showValue = value;
                changeValue?.Invoke(value);
            }
        }

        public ValueBox(T value)
        {
            showValue = value;
        }

        public ValueBox()
        {
            showValue = default(T);
        }
    }
}