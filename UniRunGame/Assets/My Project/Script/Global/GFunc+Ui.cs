using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static partial class GFunc
{
    //텍스트메쉬프로 형태의 컴포넌트의 텍스트를 설정하는 함수
    public static void SetTmpText(GameObject obj_, string text_)
    {
        TMP_Text tmpText = obj_.GetComponent<TMP_Text>();
        // if : 가져올 텍스트메쉬 컴포넌트가 없는 경우
        if (tmpText == null || tmpText == default)
        {
            return;
        }

        //가져올 텍스트메쉬 컴포넌트가 존재하는 경우
        tmpText.text = text_;
    } //SetTmpText
} //GFunc
