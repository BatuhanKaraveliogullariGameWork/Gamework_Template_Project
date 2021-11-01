using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoolEvent), editorForChildClasses: true)]
public class BoolEventEditor : GameEventEditor
{
    public bool value;
    private bool clicked;
    public override void OnInspectorGUI()
    {
        clicked = false;
        base.OnInspectorGUI();
        EditorGUILayout.Toggle("Value", value);
        if(Event.current.button == 0 && !clicked && !assetDescriptionClicked) value = !value;
    }

    public override void ButtonClicked()
    {
        clicked = true;
        BoolEvent e = target as BoolEvent;
        e.Raise(value);
    }
}
