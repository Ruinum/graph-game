using Ruinum.ECS.Components;

using System;


namespace Ruinum.Editor
{
    public static class EditorExtensions 
    {
        public static bool HasEditorComponentAttribute(this Type type)
        {
            return Attribute.IsDefined(type, typeof(EditorComponentAttribute));
        }
    }
}