using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StudentInfo
{
    public string m_id = "";
    public string m_name = "";
    public int m_kor = 0;
    public int m_eng = 0;
    public int m_math = 0;

    public int Total
    {
        get { return m_kor + m_eng + m_math; }
    }

    public float Average
    {
        get { return (float)Total / 3f; }
    }

    public StudentInfo(string id, string name, int kor, int eng, int math)
    {
        m_id = id;
        m_name = name;
        m_kor = kor;
        m_eng = eng;
        m_math = math;
    }


}

public class ScrollTestDlg : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] InputField m_inputId = null;
    [SerializeField] InputField m_inputName = null;
    [SerializeField] InputField m_inputKor = null;
    [SerializeField] InputField m_inputEng = null;
    [SerializeField] InputField m_inputMath = null;
    [Header("Button")]
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnEdit = null;
    [SerializeField] Button m_btnDelete = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnSort = null;
    [Header("기타")]
    [SerializeField] ScrollRect m_scroll = null;
    [SerializeField] GameObject m_preItem = null;

    List<Item3> m_itemList = new List<Item3>();

    Item3 m_curItem = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnEdit.onClick.AddListener(OnClicked_Edit);
        m_btnDelete.onClick.AddListener(OnClicked_Delete);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnSort.onClick.AddListener(OnClicked_Sort);
    }

    void OnClicked_Add()
    {
        StudentInfo stu = GetInput();

        if (stu == null)
            return;

        CreateItem(stu);
    }

    void CreateItem(StudentInfo stu)
    {
        GameObject go = Instantiate(m_preItem, m_scroll.content);

        Item3 item = go.GetComponent<Item3>();
        item.Init(stu);
        item.m_btn.onClick.AddListener(() => SelectedItem(item));

        m_itemList.Add(item);

        ClearInput();
    }

    StudentInfo GetInput()
    {
        if (!CheckInput())
            return null;


        string id = m_inputId.text;
        string name = m_inputName.text;
        int kor = int.Parse(m_inputKor.text);
        int eng = int.Parse(m_inputEng.text);
        int math = int.Parse(m_inputMath.text);

        StudentInfo stu = new StudentInfo(id, name, kor, eng, math);
        return stu;
    }

    bool CheckInput()
    {
        if(m_inputId.text == null || m_inputName.text == null || m_inputKor.text == null || m_inputEng.text == null || m_inputMath.text == null)
        {
            Debug.Log("값을 입력해주세요.");
            return false;
        }

        int kor = int.Parse(m_inputKor.text);
        int eng = int.Parse(m_inputEng.text);
        int math = int.Parse(m_inputMath.text);
        if (kor < 0 || kor > 100 || eng < 0 || eng > 100 || math < 0 || math > 100)
        {
            Debug.Log("값이 범위를 벗어났습니다.");
            return false;
        }

        return true;
    }

    void SelectedItem(Item3 item)
    {
        if (m_curItem != null)
            m_curItem.m_img.color = Color.white;

        item.m_img.color = Color.green;

        StudentInfo stu = item.m_stu;

        m_inputId.text = stu.m_id;
        m_inputName.text = stu.m_name;
        m_inputKor.text = stu.m_kor.ToString();
        m_inputEng.text = stu.m_eng.ToString();
        m_inputMath.text = stu.m_math.ToString();

        m_curItem = item;
    }

    void OnClicked_Edit()
    {
        StudentInfo stu = GetInput();

        if (stu == null)
            return;

        m_curItem.Init(stu);
    }

    void OnClicked_Delete()
    {
        ClearInput();

        for (int i = 0; i < m_itemList.Count; i++)
        {
            if (m_curItem.m_stu.m_id == m_itemList[i].m_stu.m_id)
            {
                m_itemList.RemoveAt(i);
                Destroy(m_curItem.gameObject);
                return;
            }
        }
    }

    void OnClicked_Clear()
    {
        ClearInput();
        ClearScroll();
        if (m_curItem != null)
            m_curItem.m_img.color = Color.white;
        m_curItem = null;
        m_itemList.Clear();
    }

    void OnClicked_Sort()
    {
        SortScroll();
    }

    void SortScroll()
    {
        m_itemList.Sort((a, b) => a.m_stu.Total < b.m_stu.Total ? 1 : -1);

        ClearScroll();

        for (int i = 0; i < m_itemList.Count; i++)
        {
            StudentInfo stu = m_itemList[i].m_stu;
            GameObject go = Instantiate(m_preItem, m_scroll.content);

            Item3 item = go.GetComponent<Item3>();
            item.Init(stu);
            item.m_btn.onClick.AddListener(() => SelectedItem(item));
        }
    }

    void OnClicked_Save()
    {
        SaveFile();
    }

    void SaveFile()
    {
        StreamWriter sw = new StreamWriter("Item3.txt");

        sw.WriteLine(m_itemList.Count);

        for (int i = 0; i < m_itemList.Count; i++)
        {
            StudentInfo stu = m_itemList[i].m_stu;

            sw.WriteLine(stu.m_id);
            sw.WriteLine(stu.m_name);
            sw.WriteLine(stu.m_kor);
            sw.WriteLine(stu.m_eng);
            sw.WriteLine(stu.m_math);
        }

        sw.Close();
    }

    void OnClicked_Load()
    {
        LoadFile();
    }

    void LoadFile()
    {
        m_itemList.Clear();

        StreamReader sr = new StreamReader("Item3.txt");

        int count = int.Parse(sr.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string id = sr.ReadLine();
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());

            StudentInfo stu = new StudentInfo(id, name, kor, eng, math);
            CreateItem(stu);
        }

        sr.Close();
    }

    void ClearInput()
    {
        m_inputId.text = string.Empty;
        m_inputName.text = string.Empty;
        m_inputKor.text = string.Empty;
        m_inputEng.text = string.Empty;
        m_inputMath.text = string.Empty;
    }

    void ClearScroll()
    {
        for (int i = 0; i < m_scroll.content.childCount; i++)
        {
            Destroy(m_scroll.content.GetChild(i).gameObject);
        }
    }

    private void OnDestroy()
    {
        ClearScroll();
    }
}
