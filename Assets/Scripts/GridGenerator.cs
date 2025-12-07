// 12/6/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int rows = 10; // Number of rows in the grid
    public int columns = 10; // Number of columns in the grid
    public float squareSize = 0.3048f; // 1 ft in meters

    public Material lavaMaterial; // Material for lava tiles
    public Material rockMaterial_Uncracked; // Material for uncracked rock tiles
    public Material rockMaterial_Cracked; // Material for cracked rock tiles
    public Material rockMaterial_VergeOfCrumbling; // Material for rock tiles on verge of crumbling
    public Material backgroundMaterial; // Material for background

    public GameObject[,] grid; // Store references to grid tiles
    private Material[] rockMaterials; // Array to store rock materials by state

    void Start()
    {
        // Initialize rock materials array for easy access by state index
        rockMaterials = new Material[]
        {
            rockMaterial_Uncracked,
            rockMaterial_Cracked,
            rockMaterial_VergeOfCrumbling
        };

        GenerateGrid(); // Call the method to generate the grid when the scene starts
    }

    void GenerateGrid()
    {
        float startX = -(columns / 2) * squareSize;
        float startZ = -(rows / 2) * squareSize;

        GameObject gridParent = new GameObject("Grid");
        grid = new GameObject[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject square = GameObject.CreatePrimitive(PrimitiveType.Cube);
                square.transform.localScale = new Vector3(squareSize, 0.01f, squareSize);
                square.transform.position = new Vector3(startX + j * squareSize, 0, startZ + i * squareSize);
                square.transform.parent = gridParent.transform;

                // Randomize tile type
                Renderer renderer = square.GetComponent<Renderer>();
                float randomValue = Random.value;

                if (randomValue < 0.2f) // 20% chance to be lava
                {
                    square.AddComponent<LavaTile>();
                    renderer.material = lavaMaterial;
                }
                else // 80% chance to be rock
                {
                    RockTile rockTile = square.AddComponent<RockTile>();
                    int randomState = Random.Range(0, 3); // Randomize rock state (0-2)
                    rockTile.SetInitialState(randomState);
                    renderer.material = rockMaterials[randomState]; // Assign material based on state
                }

                grid[i, j] = square;
            }
        }

        // Create black background
        GameObject background = GameObject.CreatePrimitive(PrimitiveType.Plane);
        background.transform.localScale = new Vector3(columns * squareSize / 10, 1, rows * squareSize / 10);
        background.transform.position = new Vector3(0, -0.01f, 0); // Slightly below the grid
        background.GetComponent<Renderer>().material = backgroundMaterial;
        background.name = "Background";
    }

    void Update()
    {
        // Check for tiles that have been converted to lava
        foreach (GameObject tile in grid)
        {
            if (tile != null && tile.CompareTag("ConvertedLava"))
            {
                Renderer renderer = tile.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = lavaMaterial;
                }
                tile.tag = "Untagged"; // Reset tag after conversion
            }
        }
    }

    public Material GetRockMaterialForState(int state)
    {
        if (state >= 0 && state < rockMaterials.Length)
        {
            return rockMaterials[state];
        }
        return rockMaterials[0]; // Default to uncracked
    }
}
