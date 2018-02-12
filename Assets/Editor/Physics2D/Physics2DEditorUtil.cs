using UnityEditor;
using UnityEngine;

public class Physics2DEditorUtil {
    [MenuItem("UnityEditorUtil/Physics2D/Clear All Layer Collision Matrix")]
    public static void ClearAllLayerCollisionMatrix() {
        const string Path = "ProjectSettings/Physics2DSettings.asset";

        var serialized = new SerializedObject(AssetDatabase.LoadAssetAtPath<Object>(Path));
        if ( serialized == null ) {
            return;
        }

        var matrix = serialized.FindProperty("m_LayerCollisionMatrix");
        if ( matrix == null ) {
            return;
        }

        if ( !matrix.isArray ) {
            return;
        }

        for ( int i = 0 ; i < matrix.arraySize ; ++i ) {
            var value = matrix.GetArrayElementAtIndex(i);
            value.intValue = 0;
        }

        serialized.ApplyModifiedProperties();

        AssetDatabase.SaveAssets();
    }
}
