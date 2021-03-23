using System;
using Object = UnityEngine.Object;

namespace Entitas.VisualDebugging.Unity.Editor
{
public class VdHub
{
    public static VdHub _instance;
    public static VdHub I => _instance ?? (_instance = new VdHub());

    public Action<Object/*target*/,Object[]/*targets*/> EntityOnInspectorGUI = EntityInspector.OnInspectorGUIDefault;
    public Action<IEntity> EntityDrawEntity = EntityDrawer.DrawEntity;
    public Action<IEntity[]> EntityDrawEntities = EntityDrawer.DrawMultipleEntities;
    public Action<IEntity> EntityDrawComponents = EntityDrawer.DrawComponents;
    public Func<IComponent,string> BuildComponentName = EntityDrawer.BuildComponentNameDefault;
    public Action< bool[] /*unfoldedComponents*/
        , string[] /*componentMemberSearch*/
        , IEntity /*entity*/
        , int /*index*/
        , IComponent /*component*/> EntityDrawComponent
        = EntityDrawer.DrawComponent;
}
}