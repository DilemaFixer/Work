using System.Collections;
using UnityEngine;

namespace Code.CoroutineActivator
{
    public interface ICoroutineActivator
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}