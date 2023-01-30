using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //! Exit 버튼을 눌렀을 때 부를 함수 -> 버튼 컴포넌트에서 직접 설정해야 실행이 가능하다!
    public void OnExitButton()
    {
        //! 내가 만든 글로벌 함수 중 게임 종료 함수!
        GioleFunc.QuitThisGame();
    }
}
