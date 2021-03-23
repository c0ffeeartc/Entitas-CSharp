using System.Linq;
using UnityEditor;

namespace Entitas.VisualDebugging.Unity.Editor {

    [CustomEditor(typeof(EntityBehaviour)), CanEditMultipleObjects]
    public class EntityInspector : UnityEditor.Editor {

        public override void OnInspectorGUI() {
            VdHub.I.EntityOnInspectorGUI.Invoke(target, targets);
        }

        public static void OnInspectorGUIDefault(UnityEngine.Object target, UnityEngine.Object[] targets) {
            if (targets.Length == 1) {
                var entityBehaviour = (EntityBehaviour)target;
                VdHub.I.EntityDrawEntity.Invoke(entityBehaviour.entity);
            } else {
                var entities = targets
                        .Select(t => ((EntityBehaviour)t).entity)
                        .ToArray();

                VdHub.I.EntityDrawEntities.Invoke(entities);
            }

            if (target != null) {
                EditorUtility.SetDirty(target);
            }
        }
    }
}
