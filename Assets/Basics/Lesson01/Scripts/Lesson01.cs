// ***********************************************************************************
// FileName: Lesson01.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2025-10-15 18:54:52
// ==============================================
// History update record:
// 
// ==============================================
// *************************************************************************************

using System;
using UnityEngine;

namespace Basics.Lesson01
{
    public class Lesson01 : MonoBehaviour
    {
        private const float Hours2Degrees = -30.0f;
        private const float Minutes2Degrees = -6.0f;
        private const float Seconds2Degrees = -6.0f;

        [SerializeField] private bool showStyle;

        [SerializeField] private Transform hoursPivot;
        [SerializeField] private Transform minutesPivot;
        [SerializeField] private Transform secondsPivot;

        /// <summary>
        /// Awake 函数会在游戏对象被实例化之后立即调用，而且在所有对象的 Start 函数调用之前执行。一般在 Awake 函数里进行以下操作：
        /// <para>1. 初始化引用：查找并存储对其他组件或者游戏对象的引用，确保后续代码能够方便地访问这些对象。</para>
        /// <para>2. 初始化设置：对脚本中的变量进行初始赋值。</para>
        /// <para>3. 建立连接：比如和数据库或者网络服务建立连接。</para>
        /// </summary>
        private void Awake()
        {
            var now = DateTime.Now;
            hoursPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, Hours2Degrees * now.Hour);
            minutesPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, Minutes2Degrees * now.Minute);
            secondsPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, Seconds2Degrees * now.Second);
        }

        private void Update()
        {
            if (showStyle)
            {
                var now = DateTime.Now.TimeOfDay;

                hoursPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, Hours2Degrees * (float)now.TotalHours);
                minutesPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, Minutes2Degrees * (float)now.TotalMinutes);
                secondsPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, Seconds2Degrees * (float)now.TotalSeconds);
            }
            else
            {
                var now = DateTime.Now;

                hoursPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, Hours2Degrees * now.Hour);
                minutesPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, Minutes2Degrees * now.Minute);
                secondsPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, Seconds2Degrees * now.Second);
            }
        }
    }
}