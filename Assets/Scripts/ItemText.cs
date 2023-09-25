using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemText : MonoBehaviour
{
    public Text m_txt = null;
    public Button m_btn = null;

    private void Awake()
    {
        m_txt = GetComponent<Text>();
        m_btn = GetComponent<Button>();
    }
}
