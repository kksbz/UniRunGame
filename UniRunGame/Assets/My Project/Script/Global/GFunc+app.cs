using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static partial class GFunc //static 을 붙이면 아무것도 상속받지 않음 
                                  //기본적으로 mono를 상속받으면 인스턴스화 하겠다는 거임
                                  //유니티엔진과 관련없는 static class이기 때문에 파일명이랑 class명이랑 같을 필요가 없음
                                  //유니티엔진과 관련있는 class는 파일명이랑 class명이 동일해야 인식됨
{
    //static class를 쓰는 이유 => 인스턴스화하지않는 코드들을 static으로 묶어서 관리가능함
    //어디서든 불러쓸 수 있음 => 생산성을 높일 수 있음

    //게임을 종료하는 함수
    public static void QuitThisGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    } //QuitThisGame

    //다른 씬을 로드하는 함수
    public static void LoadScene(string sceneName_)
    {
        SceneManager.LoadScene(sceneName_);
    }

    //extend 함수 쓰는법
    public static void KksFunc(this GameObject obj_)
    {
        Debug.Log("이것은 내가 만든 함수가 분명하다");
    }
} //GFunc
