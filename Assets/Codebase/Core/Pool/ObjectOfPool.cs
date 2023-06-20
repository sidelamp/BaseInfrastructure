using System;
using UnityEngine;

namespace Assets. Core.Pool
{
    public abstract class ObjectOfPool : MonoBehaviour
    {
        public event Action<ObjectOfPool> OnDispose;

        protected void CallDispose()
        {
            OnDispose?.Invoke(this);
        }
    }
}