using System;
using UnityEngine;


namespace Ruinum.ECS.Core.Systems.Log
{
    public static class LogExtention
    {
        public static void Log(this string message)
        {
            Debug.Log(message);
        }

        public static void Log(this string message, LogType logType)
        {
            Debug.Log(message);

            switch (logType)
            {
                case LogType.Error:
                    Error(message);
                    break;
                case LogType.Assert:
                    Log(message);
                    break;
                case LogType.Warning:
                    Warning(message);
                    break;
                case LogType.Log:
                    Log(message);
                    break;
                case LogType.Exception:
                    Error("Exception: " + message);
                    break;
                default:
                    break;
            }
        }

        public static string ToStringLog(this object o)
        {
            var message = o.ToString();
            message.Log();
            return message;
        }

        public static void Warning(this string message)
        {
            Debug.LogWarning(message);
        }

        public static string ToStringWarning(this object o)
        {
            var message = o.ToString();
            message.Warning();
            return message;
        }

        public static void Error(this string message)
        {
            Debug.LogError(message);
        }

        public static string ToStringError(this object o)
        {
            var message = o.ToString();
            message.Error();
            return message;
        }

        public static void Exception(this Exception message)
        {
            Debug.LogException(message);
        }
    }
}