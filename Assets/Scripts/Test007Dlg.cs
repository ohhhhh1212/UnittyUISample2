using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test007Dlg : MonoBehaviour
{
    [SerializeField] Scrollbar m_scroll = null;
    [SerializeField] Text m_result = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnStop = null;

    bool isStart = false;
    float time = 0f;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (isStart)
        {
            if (m_scroll.value >= 1f)
                return;

            if (time >= 0.5f)
            {
                m_scroll.value += 0.05f;
                PrintResult(m_scroll.value);

                time = 0f;
            }

            time += Time.deltaTime;
        }
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
        m_scroll.onValueChanged.AddListener(OnValueChanged_Scroll);
    }

    void OnClicked_Ok()
    {
        m_scroll.value = 0;
        isStart = true;
    }

    void OnClicked_Stop()
    {
        isStart = false;
    }

    void OnValueChanged_Scroll(float value)
    {
        Color color = m_result.color;
        color.a = value;
        m_result.color = color;

        PrintResult(value);
    }

    void PrintResult(float value)
    {
        m_result.text = string.Format("{0:0.00}", value);
    }
}
