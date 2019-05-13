using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// サンプル動作用クラス
/// </summary>
public class SampleManager : MonoBehaviour
{
    [SerializeField]
    private Text numberText = null;

    private SampleUserData userData;

    //セーブデータのファイル名
    private string saveFileName = "UserData";

    private void Start()
    {
        bool cheack = ClassDataFomater.DataCheack(UnityEngine.Application.persistentDataPath + "/" + saveFileName);
        Debug.Log("データは" + cheack);
        userData = new SampleUserData();
        numberText.text = userData.countNum.ToString();
    }

    public void OnClickAddButton()
    {
        userData.countNum++;
        numberText.text = userData.countNum.ToString();
    }

    public void OnClickSaveButton()
    {
        ClassDataFomater.Seialize<SampleUserData>(UnityEngine.Application.persistentDataPath + "/" + saveFileName, userData);
    }

    public void OnClickLoadButton()
    {
        userData = ClassDataFomater.Deserialize<SampleUserData>(UnityEngine.Application.persistentDataPath + "/" + saveFileName);
        numberText.text = userData.countNum.ToString();
    }
}

[Serializable]
public class SampleUserData
{
    public int countNum = 0;
}