using UnityEngine;
using EventVariableAssets;

namespace EventVariableAssets.Examples
{
    public class Example1 : MonoBehaviour
    {
        [SerializeField] GenericEvent m_resetEvent = null;
        [SerializeField] IntVariableReference m_textSizeVariable = null;

        void Start()
        {
            if (m_resetEvent != null)
                m_resetEvent.Raise();
        }

        public void IncreaseTextSize()
        {
            if (m_textSizeVariable != null)
                m_textSizeVariable.Value += 1;
        }

        public void DecreaseTextSize()
        {
            if (m_textSizeVariable != null)
                m_textSizeVariable.Value = Mathf.Max(1, m_textSizeVariable.Value - 1);
        }
    }
}