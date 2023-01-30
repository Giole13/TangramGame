using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class GioleFunc
{

    // 게임 종료 함수
    public static void QuitThisGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }       // QuitThisGame()


    public static void HyungJun24Func(this GameObject obj_)
    {
        // 내가 만든 확장 함수!
        Debug.Log("이것은 내가 만든 함수가 분명하다.");
    }


    public static void LoadScene(string sceneName)
    {
        //! 다른 씬을 로드하는 함수
        SceneManager.LoadScene(sceneName);
    }
}
