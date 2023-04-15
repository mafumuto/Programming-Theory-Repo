using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TMP_InputField enterUserName;
    public string userName;
    public TextMeshProUGUI inputText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetUserName()
    {
        userName = enterUserName.text;
    }
}
