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

    //! Exit ��ư�� ������ �� �θ� �Լ� -> ��ư ������Ʈ���� ���� �����ؾ� ������ �����ϴ�!
    public void OnExitButton()
    {
        //! ���� ���� �۷ι� �Լ� �� ���� ���� �Լ�!
        GioleFunc.QuitThisGame();
    }
}
