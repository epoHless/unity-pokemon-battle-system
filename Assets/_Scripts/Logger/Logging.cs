using UnityEngine;

namespace MobileFramework.Analytics
{
    /// <summary>
    /// Simple class that includes a bunch of customized Debug.Log methods automatically excluded from builds.  
    /// </summary>
    public static class Logging
    {
        /// <summary>
        /// Log a basic error.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        public static void Error(string message)
        {
#if  UNITY_EDITOR
            Debug.Log(message);
            Debug.Break();
#endif
        }
        
        /// <summary>
        /// Log a basic error.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        /// <param name="color">Your desired color for the message.</param>
        public static void Error(string message, Color color)
        {
#if  UNITY_EDITOR
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>");
            Debug.Break();
#endif
        }

        /// <summary>
        /// Log a basic error.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        /// <param name="color">Your desired color for the message.</param>
        /// <param name="bold">Make the text bold or not.</param>
        public static void Error(string message, Color color, bool bold)
        {
#if  UNITY_EDITOR
            message = bold ? $"<b><color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color></b>" : $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>";
            Debug.Log($"{message}");
            Debug.Break();
#endif
        }

        /// <summary>
        /// Log a basic error.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        /// <param name="color">Your desired color for the message.</param>
        /// <param name="size">Change the size of the message.</param>
        public static void Error(string message, Color color, int size)
        {
#if  UNITY_EDITOR
            Debug.Log($"<size={size}><color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color></size>");
            Debug.Break();
#endif
        }

        /// <summary>
        /// Log a basic error.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        /// <param name="color">Your desired color for the message.</param>
        /// <param name="bold">Make the text bold or not.</param>
        /// <param name="size">Change the size of the message.</param>
        public static void Error(string message, Color color, bool bold, int size)
        {
#if  UNITY_EDITOR
            message = bold ? $"<b><color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color></b>" : $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>";
            Debug.Log($"<size={size}>{message}</size>");
            Debug.Break();
#endif
        }

        /// <summary>
        /// Log a basic warning.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        public static void Warning(string message)
        {
#if  UNITY_EDITOR
            Debug.LogWarning(message);
#endif
        }

        /// <summary>
        /// Log a basic warning.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        /// <param name="color">Your desired color for the message.</param>
        public static void Warning(string message, Color color)
        {
#if  UNITY_EDITOR
            Debug.LogWarning($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>");
#endif
        }

        /// <summary>
        /// Log a basic warning.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        /// <param name="color">Your desired color for the message.</param>
        /// <param name="bold">Make the text bold or not.</param>
        public static void Warning(string message, Color color, bool bold)
        {
#if  UNITY_EDITOR
            message = bold ? $"<b><color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color></b>" : $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>";
            Debug.LogWarning($"{message}");
#endif
        }

        /// <summary>
        /// Log a basic warning.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        /// <param name="color">Your desired color for the message.</param>
        /// <param name="size">Change the size of the message.</param>
        public static void Warning(string message, Color color, int size)
        {
#if  UNITY_EDITOR
            Debug.LogWarning($"<size={size}><color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color></size>");
#endif
        }

        /// <summary>
        /// Log a basic warning.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        /// <param name="color">Your desired color for the message.</param>
        /// <param name="bold">Make the text bold or not.</param>
        /// <param name="size">Change the size of the message.</param>
        public static void Warning(string message, Color color, bool bold, int size)
        {
#if  UNITY_EDITOR
            message = bold ? $"<b><color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color></b>" : $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>";
            Debug.LogWarning($"<size={size}>{message}</size>");
#endif
        }

        /// <summary>
        /// Log a basic message.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        public static void Message(string message)
        {
#if  UNITY_EDITOR
            Debug.Log(message);
#endif
        }

        /// <summary>
        /// Log a basic message.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        /// <param name="color">Your desired color for the message.</param>
        public static void Message(string message, Color color)
        {
#if  UNITY_EDITOR
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>");
#endif
        }
        
        /// <summary>
        /// Log a basic message.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        /// <param name="color">Your desired color for the message.</param>
        /// <param name="bold">Make the text bold or not.</param>
        public static void Message(string message, Color color, bool bold)
        {
#if  UNITY_EDITOR
            message = bold ? $"<b><color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color></b>" : $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>";
            Debug.Log($"{message}");
#endif
        }
        
        /// <summary>
        /// Log a basic message.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        /// <param name="color">Your desired color for the message.</param>
        /// <param name="size">Change the size of the message.</param>
        public static void Message(string message, Color color, int size)
        {
#if  UNITY_EDITOR
            Debug.Log($"<size={size}><color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color></size>");
#endif
        }
        
        /// <summary>
        /// Log a basic message.
        /// </summary>
        /// <param name="message">Your message to show.</param>
        /// <param name="color">Your desired color for the message.</param>
        /// <param name="bold">Make the text bold or not.</param>
        /// <param name="size">Change the size of the message.</param>
        public static void Message(string message, Color color, bool bold, int size)
        {
#if  UNITY_EDITOR
            message = bold ? $"<b><color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color></b>" : $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>";
            Debug.Log($"<size={size}>{message}</size>");
#endif
        }
    }
}