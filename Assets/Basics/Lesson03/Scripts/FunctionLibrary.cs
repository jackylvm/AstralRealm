// ***********************************************************************************
// FileName: FunctionLibrary.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2025-10-16 21:46:56
// ==============================================
// History update record:
// 
// ==============================================
// *************************************************************************************

using UnityEngine;

namespace Basics.Lesson03
{
    public static class FunctionLibrary
    {
        public static float Wave(float x, float t)
        {
            return Mathf.Sin(Mathf.PI * (x + t));
        }
    }
}