using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static partial class GioleFunc
{
    public static void SetTmpText(this GameObject obj_, string text_)
    {
        //! 텍스트매쉬프로 형태의 컴포넌트의 텍스트를 설정하는 경우
        TMP_Text tmpTXT = obj_.GetComponent<TMP_Text>();
        if(tmpTXT == null || tmpTXT == default){
            return;
        }       // if: 가져올 텍스트매쉬 컴포넌트가 없는 경우 리턴
        

        // 가져올 텍스트매쉬 컴포넌트가 존재하는 경우
        tmpTXT.text = text_;
    }       // SetTextMeshPro()
}
