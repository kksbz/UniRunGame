using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GFunc
{
    //Debug항목들 랩핑함 에러로그를 숨기기위해 만듬
    #region Print log func
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message) //Object = UnityEngine.Object임 using System을쓰면 비쥬얼스튜디오꺼랑 겹쳐서
                                           //명시적으로 UnityEngine.Object라 해줘야됨
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message, Object context)
    {
#if DEBUG_MODE
        Debug.Log(message, context);
#endif
    }
    #endregion // Print log func

    #region Assert for debug
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }


    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition, object message)
    {
#if DEBUG_MODE
        Debug.Assert(condition, message);
#endif
    }
    #endregion //Assert for debug

    //Vaild체크하는 함수
    #region Vaild Func
    public static bool IsValid<T>(this T component_)
    {
        bool isValid = component_.Equals(null) == false;

        return isValid;
    }
    #endregion //Vaild Func
}
