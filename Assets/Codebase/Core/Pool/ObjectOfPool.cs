using System;
using UnityEngine;

namespace Assets.Codebase.Core.Pool
{
    public abstract class ObjectOfPool : MonoBehaviour
    {
        public event Action<ObjectOfPool> OnDispose;
    }
}