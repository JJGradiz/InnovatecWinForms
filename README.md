# InnoVatecPark — Aplicación Windows Forms

Resumen
-------
InnoVatecPark es una pequeña aplicación Windows Forms para manejar dos estructuras de datos educativas: 
- Un árbol general (organigrama) con operaciones de inserción, búsqueda, conteo y cálculo de niveles.
- Un grafo ponderado (no dirigido) con operaciones de añadir aristas y búsqueda de la ruta más corta con Dijkstra.

Este README describe la arquitectura general, los archivos principales, cómo usar la aplicación y recomendaciones de corrección/mejora del código.

Índice
------
- Arquitectura
- Archivos principales
- Capa de presentación (UI) — controles y uso
- Capa de estructuras de datos — resumen y correcciones recomendadas
- Cómo compilar / ejecutar
- Ejemplos de uso
- Notas y recomendaciones

Arquitectura
-----------
La aplicación está organizada en 3 capas:

1. Punto de entrada
   - `Program.cs` — Inicializa la aplicación y abre el formulario principal.

2. Capa de presentación (Windows Forms)
   - `InnoVatecPark` (Form1.cs + Form1.Designer.cs) — Interfaz que manipula el árbol y el grafo y muestra resultados.

3. Capa de estructuras de datos
   - `GeneralTree.cs` — Implementación de un árbol general con `TreeNode<T>` y `GeneralTree<T>`.
   - `Graph.cs` — Implementación de un grafo no dirigido con aristas ponderadas y el algoritmo de Dijkstra.

Archivos principales
--------------------
- Program.cs
- Form1.cs (InnoVatecPark)
- Form1.Designer.cs
- GeneralTree.cs
- Graph.cs

Capa de presentación (UI)
-------------------------
Controles principales (definidos en `Form1.Designer.cs`):

- Árbol (organigrama)
  - treeViewOrg — TreeView que muestra la estructura del árbol.
  - txtParent — Texto para indicar el nodo padre al insertar.
  - txtNewNode — Nombre del nuevo nodo a insertar / buscar / consultar.
  - Botones:
    - Insertar (btnInsertTree_Click)
    - Buscar (btnSearchTree_Click)
    - Contar (btnCountTree_Click)
    - Nivel (btnLevelTree_Click)

- Grafo
  - lstAdj — ListBox que muestra la lista de adyacencia.
  - txtA, txtB — Nodos que conectan la arista.
  - txtWeight — Peso de la arista.
  - txtStart, txtEnd — Inicio y fin para buscar ruta más corta.
  - Botones:
    - Agregar arista (btnAddEdge_Click)
    - Calcular ruta más corta (btnShortestPath_Click)

- Resultados
  - lblResult — Etiqueta para mostrar resultados de Dijkstra (ruta y distancia).

Operaciones disponibles (UI)
- Insertar nodo en el árbol: indicar `Parent` y `NewNode`.
- Buscar nodo en el árbol: indicar `NewNode`.
- Contar nodos.
- Consultar nivel (profundidad) de un nodo.
- Añadir arista en el grafo: indicar `A`, `B` y `Weight` (bidireccional).
- Mostrar lista de adyacencia.
- Calcular ruta más corta entre `Start` y `End` (Dijkstra).

Capa de estructuras de datos — Resumen y correcciones
----------------------------------------------------

GeneralTree (GeneralTree.cs)
- TreeNode<T>
  - Propiedades: Value, Children, Parent.
  - AddChild(TreeNode<T> child) establece la relación padre-hijo.

- GeneralTree<T>
  - Root: nodo raíz (ej. "CEO").
  - Insert(parentValue, newValue): busca el padre y añade un hijo.
  - SearchNode(...) : búsqueda DFS recursiva.
  - Count() / CountNodes(...) : cuenta total de nodos.
  - LevelOf(value) / FindLevel(...) : determina la profundidad (nivel) de un nodo.
  - Contains(value) : verifica si existe un nodo.

Corrección recomendada (visibilidad)
- Asegúrate que `Contains` es público si la UI la llama. Ejemplo correcto:
```csharp
public bool Contains(T value)
{
    return SearchNode(Root, value) != null;
}
```

Graph (Graph.cs)
- Edge: representando destino (`To`) y `Weight`.
- Graph:
  - adj: Dictionary<string, List<Edge>> (lista de adyacencia).
  - AddVertex(string v): crea la entrada en `adj`.
  - AddEdge(string a, string b, double weight): añade aristas bidireccionales.
  - GetAdj(string v): devuelve los edges adyacentes.
  - Dijkstra(start, end): algoritmo de Dijkstra que devuelve (distancia, camino).

Correcciones / mejoras recomendadas
1. AddVertex actualmente sobreescribe siempre la entrada:
```csharp
public void AddVertex(string v)
{
    adj[v] = new List<Edge>(); 
}
```
Mejor usar:
```csharp
public void AddVertex(string v)
{
    if (!adj.ContainsKey(v))
        adj[v] = new List<Edge>();
}
```

2. GetAdj puede lanzar una excepción si `v` no está en el diccionario. Mejor:
```csharp
public IEnumerable<Edge> GetAdj(string v)
{
    if (!adj.ContainsKey(v))
        return Enumerable.Empty<Edge>();
    return adj[v];
}
```

3. Evitar aristas duplicadas (opcional): antes de añadir, comprobar si ya existe una arista al mismo destino con el mismo peso.

4. Dijkstra: la implementación con `SortedSet<(double, string)>` funciona, pero hay que garantizar que las tuplas que se eliminan desde `pq.Remove((dist[e.To], e.To))` existen exactamente con esa clave — la lógica actual está bien si las tuplas se gestionan de forma consistente. Considera reemplazarlo por una PriorityQueue si tu versión de .NET lo soporta, para mayor claridad y rendimiento.

Fragmentos corregidos sugeridos
------------------------------
Aquí hay ejemplos de las correcciones sugeridas que puedes aplicar directamente.

GeneralTree.Contains (hacer pública):
```csharp
public bool Contains(T value)
{
    return SearchNode(Root, value) != null;
}
```

Graph.AddVertex y GetAdj corregidos:
```csharp
public void AddVertex(string v)
{
    if (!adj.ContainsKey(v))
        adj[v] = new List<Edge>();
}

public IEnumerable<Edge> GetAdj(string v)
{
    if (!adj.ContainsKey(v))
        return Enumerable.Empty<Edge>();
    return adj[v];
}
```

Cómo compilar y ejecutar
------------------------
Requisitos:
- Windows (WinForms).
- Visual Studio 2019/2022 o dotnet SDK si el proyecto está en .NET Core/5/6 con soporte WinForms.
- Si el proyecto es .NET Framework, ábrelo con Visual Studio y compílalo.

Pasos:
1. Abrir la solución/proyecto en Visual Studio.
2. Compilar (Build).
3. Ejecutar (Start) — se abrirá la ventana principal `InnoVatecPark`.
4. Usar los controles descritos en la UI para manipular el árbol y el grafo.

Ejemplos de uso
---------------
1. Árbol (organigrama)
   - Insertar: Parent="CEO", NewNode="CTO" -> botón Insertar => se añade "CTO" como hijo de "CEO".
   - Insertar: Parent="CTO", NewNode="Dev1" -> añade "Dev1" bajo "CTO".
   - Buscar: NewNode="Dev1" -> debe mostrar "Encontrado."
   - Contar: mostrará 3 si tienes CEO, CTO, Dev1.
   - Nivel: NewNode="Dev1" -> Nivel: 2 (0 = CEO).

2. Grafo
   - Añadir arista: A="A", B="B", Weight="2.5" -> crea arista A<->B con peso 2.5.
   - Lista de adyacencia: mostrará "A -> B(2.5)" y "B -> A(2.5)".
   - Ruta más corta: Start="A", End="C" -> si existe un camino se mostrará la ruta y la distancia.

# Fin.

