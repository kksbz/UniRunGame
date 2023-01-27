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
        if (searchResult == null || searchResult == default)
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

    //컴포넌트 가져오는 함수
    //제네릭 T는 개발자마음대로 이름을 바꿔도됨 정통적으로 T(템플릿)라고 씀
    //this를 붙인 이유는 this (GameObject) ()안의 타입의 확장함수를 만든다는 것임
    //여기선 GameObject의 확장함수를 만든다는 것으로 gameObject. 점을 찍으면 GetComponentMust가 나옴
    public static T GetComponentMust<T>(this GameObject obj)
    {
        T component_ = obj.GetComponent<T>();
        //제네릭을 사용해서 뭐든지 받을거기 때문에 default 사용불가해서 IsValid 함수를 만들어 사용했음
        //여기서 (as는 부모클래스로 Component를 상속받은 것만) Component로 캐스팅하겠다는 것임
        //bool isComponentValid = ((Component)(component_ as Component)).IsValid();

        //위의 코드랑 같은기능 IsValid를 사용하지않고 이런식으로도 사용할 수 있음
        //bool isComponentValid = component_.Equals(null) == false;

        //현재 IsValid함수는 위의 코드를 기반으로 수정한 상태
        GFunc.Assert(component_.IsValid<T>() != false,
        string.Format("{0}에서 {1}을(를) 찾을 수 없습니다.", obj.name, component_.GetType().Name));
        return component_;
    } //컴포넌트 가져오는 함수

    //트랜스폼을 사용해서 오브젝트를 움직이는 함수 (Translate가 Vector3만 받아서 Vector2를 받게 오버로딩한 함수)
    public static void Translate(this Transform transform_, Vector2 moveVector)
    {
        transform_.Translate(moveVector.x, moveVector.y, 0f);
    } //Translate

    //RectTransform에서 sizeDelta를 찾아서 리턴하는 함수
    public static Vector2 GetRectSizeDelta(this GameObject obj_)
    {
        return obj_.GetComponentMust<RectTransform>().sizeDelta;
    }

    //오브젝트의 로컬 포지션을 변경하는 함수
    public static void SetLocalPos(this GameObject obj_, float x, float y, float z)
    {
        obj_.transform.localPosition = new Vector3(x,y,z);
    }

    //오브젝트의 로컬 포지션을 연상하는 함수
    public static void AddLocalPos(this GameObject obj_, float x, float y, float z)
    {
        obj_.transform.localPosition = obj_.transform.localPosition + new Vector3(x, y, z);
        
    }
} //GFunc
