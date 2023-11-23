using System.Collections;
using UnityEngine;

namespace Code.CoroutineActivator
{
    public interface ICoroutineActivator
    {
        public void ActiveitCoroutine(IEnumerator coroutine);
    }
}