/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2020.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Leap.Unity.Recording {

  [CanEditMultipleObjects]
  [CustomEditor(typeof(TransitionBehaviour), editorForChildClasses: true, isFallback = true)]
  public class TransitionBehaviourEditor : CustomEditorBase<TransitionBehaviour> {

    protected override void OnEnable() {
      base.OnEnable();

      specifyCustomDrawer("transitionState", drawIndentedTransitionState);
    }

    private void drawIndentedTransitionState(SerializedProperty prop) {
      EditorGUI.indentLevel++;

      if (prop.objectReferenceValue == null) {
        GUI.contentColor = new Color(0.7f, 0.7f, 0.7f, 1);
      }

      EditorGUILayout.PropertyField(prop);
      EditorGUI.indentLevel--;
      GUI.contentColor = Color.white;

      EditorGUILayout.Space();
    }

    public override void OnInspectorGUI() {
      base.OnInspectorGUI();

      if (targets.Length == 1 && Application.isPlaying) {
        if (GUILayout.Button("Execute Transition")) {
          target.Transition();
        }
      }
    }
  }
}
