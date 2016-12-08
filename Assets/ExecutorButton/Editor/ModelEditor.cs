using System;
using System.CodeDom;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Reflection;
using Assets.ExecutorButton;
using UnityEditor;

namespace Assets.ExecutorButton.Editor {

    [CustomEditor(typeof (Model),true)]
    public class ModelEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if( !EditorApplication.isPlaying ) return;
            

            Type type = target.GetType();
            
            var methodInfos = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                .Where( m => Attribute.GetCustomAttribute(m,typeof(ExecutorButtonAttribute)) != null)
                .Where( m => !m.GetParameters().Any());

            foreach (var mi in methodInfos)
            {
                if (GUILayout.Button(mi.Name))
                {
                    mi.Invoke(target, new object[0]);
                }
            }
        }
    }
}
