using UnityEditor;
using UnityEngine;

class CreatePrefabFromSelected
{

    const string menuTitle = "Cards/Create Card From Selected";
    const string menuTitle2 = "Cards/UpdateCards";

    /// <summary>
    /// Creates a prefab from the selected game object.
    /// </summary>

    [MenuItem(menuTitle)]
    static void CreatePrefab(GameObject o = null)
    {

        GameObject obj;

        if (o == null)
            obj = Selection.activeGameObject;
        else
            obj = o;

        string name = obj.name;

        Object prefab = EditorUtility.CreateEmptyPrefab("Assets/Prefabs/Cards/Deck/" + name + ".prefab");
        EditorUtility.ReplacePrefab(obj, prefab);
        AssetDatabase.Refresh();

    }

    [MenuItem(menuTitle2)]
    static void UpdatePrefabs()
    {

        GameObject[] objs = Selection.gameObjects;

        foreach (GameObject o in objs)
        {
            CreatePrefab(o);
        }

    }


    /// <summary>
    /// Validates the menu.
    /// </summary>
    /// <remarks>The item will be disable if no game object is selected.</remarks>

    [MenuItem(menuTitle, true)]
    static bool ValidateCreatePrefab()
    {
        return Selection.activeGameObject != null;
    }

    [MenuItem(menuTitle2, true)]
    static bool ValidateUpdateCreatePrefab()
    {
        return Selection.activeGameObject != null;
    }



}