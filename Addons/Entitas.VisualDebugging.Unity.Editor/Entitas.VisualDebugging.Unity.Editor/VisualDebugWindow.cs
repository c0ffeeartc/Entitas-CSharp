using UnityEditor;
using UnityEngine;

namespace Entitas.VisualDebugging.Unity.Editor
{
public class VisualDebugWindow: EditorWindow
{
	public static void Open(IEntity entity)
	{
		var window = (VisualDebugWindow)GetWindow(typeof(VisualDebugWindow));
		window.Init(entity);
		window.Show();
	}

	private IEntity _entity;
	private int _entityCreationIndex;
	Vector2 _scrollViewPosition;

	private void Init(IEntity entity)
	{
		_entity = entity;
		_entityCreationIndex = _entity.creationIndex;
		_scrollViewPosition = Vector2.zero;
	}

	private void OnGUI( )
	{
		if ( _entity == null
			|| !_entity.isEnabled
			|| _entityCreationIndex != _entity.creationIndex )
		{
			return;
		}

		_scrollViewPosition = EditorGUILayout.BeginScrollView(_scrollViewPosition);
		{
			VdHub.I.EntityDrawEntity.Invoke(_entity);
		}
		EditorGUILayout.EndScrollView();
	}
}
}