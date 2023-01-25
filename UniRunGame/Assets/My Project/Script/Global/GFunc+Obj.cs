using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    //특정 오브젝트의 자식 오브젝트를 서치해서 찾아주는 함수
    public static GameObject FindChildObj(this GameObject targetObj_, string objName_)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;
        //loop : 검색하고자하는 오브젝트의 자식갯수 만큼
        for (int i = 0; i < targetObj_.transform.childCount; i++)
        {
            //자식오브젝트 i번째를 searchTarget에 저장
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            //searchTarget의 이름이 objName_와 같으면 찾은거임
            if (searchTarget.name.Equals(objName_))
            {
                //이름이 동일하니 searchResult에 저장
                searchResult = searchTarget;
                //리턴
                return searchResult;
            }
            else
            {
                //이름이 동일하지않으면 searchTarget 안의 자식오브젝트중에서 찾도록 재귀함수
                searchResult = FindChildObj(searchTarget, objName_);
            }
        } //loop
        //방어로직
        if(searchResult == null || searchResult == default)
        {
            //pass
        }
        else
        {
            return searchResult;
        }
        return searchResult;
    }

    //씬의 루트 오브젝트를 서치해서 찾아주는 함수
    public static GameObject GetRootObj(string objName_)
    {
        Scene activeScene_ = GetActiveScene();
        GameObject[] rootObj_ = activeScene_.GetRootGameObjects();

        GameObject targetObj_ = default;
        foreach (GameObject rootObj in rootObj_)
        {
            if (rootObj.name.Equals(objName_))
            {
                targetObj_ = rootObj;
                return targetObj_;
            }
            else
            {
                continue;
            }
        } //loop

        return targetObj_;
    } //GetRootObj

    //현재 활성화 되어 있는 씬을 찾아주는 함수
    public static Scene GetActiveScene()
    {
        Scene activeScene_ = SceneManager.GetActiveScene();
        return activeScene_;
    } //GetActiveScene
} //GFunc
