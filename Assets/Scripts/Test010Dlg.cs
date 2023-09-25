using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test010Dlg : MonoBehaviour
{
    [SerializeField] ScrollRect m_scroll = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] GameObject m_preItem = null;

    string[] m_City = { "서울", "도쿄", "파리", "오타와", "베른" };

    ItemText m_curItem = null;

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        CreateItem();
    }

    void CreateItem()
    {
        for (int i = 0; i < m_City.Length; i++)
        {
            GameObject go = Instantiate(m_preItem, m_scroll.content);
            ItemText item = go.GetComponent<ItemText>();
            item.m_txt.text = m_City[i];

            item.m_btn.onClick.AddListener(() => SelectedItem(item));
        }
    }

    void SelectedItem(ItemText item)
    {
        if(m_curItem != null)
            m_curItem.m_txt.color = Color.white;

        item.m_txt.color = Color.red;

        m_txtResult.text = item.m_txt.text;

        m_curItem = item;
    }

    void OnClicked_Ok()
    {
        if (m_curItem == null)
        {
            m_txtResult.text = "도시를 선택해주세요.";
            return;
        }

        m_txtResult.text = $"당신이 선택한 도시는 {m_curItem.m_txt.text}입니다.";
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "초기화";
        if (m_curItem != null)
            m_curItem.m_txt.color = Color.white;
        m_curItem = null;
    }

    void DestroyItem()
    {
        for (int i = 0; i < m_scroll.content.childCount; i++)
        {
            Destroy(m_scroll.content.GetChild(i).gameObject);
        }
    }

    private void OnDestroy()
    {
        DestroyItem();
    }
}
