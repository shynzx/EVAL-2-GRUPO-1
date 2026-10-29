using UnityEngine;
using UnityEditor;

public static class DuplicarConFlechas
{
    private static float distanciaMovimiento = 1.5f;

    // % = Ctrl/Cmd, # = Shift, & = Alt
    [MenuItem("Edit/Duplicar y Mover/Izquierda %#LEFT")]
    private static void DuplicarIzquierda() => DuplicarYDesplazar(Vector3.left);

    [MenuItem("Edit/Duplicar y Mover/Derecha %#RIGHT")]
    private static void DuplicarDerecha() => DuplicarYDesplazar(Vector3.right);

    [MenuItem("Edit/Duplicar y Mover/Arriba %#UP")]
    private static void DuplicarArriba() => DuplicarYDesplazar(Vector3.up);

    [MenuItem("Edit/Duplicar y Mover/Abajo %#DOWN")]
    private static void DuplicarAbajo() => DuplicarYDesplazar(Vector3.down);

    private static void DuplicarYDesplazar(Vector3 direccion)
    {
        GameObject original = Selection.activeGameObject;
        if (original == null) return;

        // Duplicar correctamente (respeta prefabs)
        GameObject duplicado;
        GameObject prefab = PrefabUtility.GetCorrespondingObjectFromSource(original);
        if (prefab != null)
            duplicado = (GameObject)PrefabUtility.InstantiatePrefab(prefab, original.transform.parent);
        else
            duplicado = Object.Instantiate(original, original.transform.parent);

        duplicado.name = original.name;
        duplicado.transform.position = original.transform.position + direccion * distanciaMovimiento;

        Undo.RegisterCreatedObjectUndo(duplicado, "Duplicar con Flechas");
        Selection.activeGameObject = duplicado;
    }
}