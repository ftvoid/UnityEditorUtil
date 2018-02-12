using UnityEditor;
using UnityEngine;

public class PhysicsEditorUtil {
    [MenuItem("UnityEditorUtil/Physics/Clear All Layer Collision Matrix")]
    public static void ClearAllLayerCollisionMatrix() {
        const string Path = "ProjectSettings/DynamicsManager.asset";

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
