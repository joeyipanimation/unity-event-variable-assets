using UnityEngine;
using UnityEngine.Events;

namespace EventVariableAssets
{
    public class GenericEventListener : GenericEventListenerBase
    {
        //public GenericEvent Event;
        public UnityEvent Response;

        //void OnEnable()
        //{
        //    Event.RegisterListener(this);
        //}

        //void OnDisable()
        //{
        //    Event.UnregisterListener(this);
        //}

        public override void OnEventRaised()
        {
            Response.Invoke();
        }

        //public void ClearChildren()
        //{
        //    ClearChildren(this.transform);
        //}

        //public void ClearChildren(Transform t)
        //{
        //    RectTransform[] children = t.GetComponentsInChildren<RectTransform>(true);
        //    for (int i = children.Length - 1; i >= 0; i--)
        //    {
        //        if (children[i].gameObject != t.gameObject)
        //            DestroyImmediate(children[i].gameObject);
        //    }
        //}
    }
}