using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockManager : MonoBehaviour
{
    public Block blockPrefab;
    public Sprite sprite;
    public Color[] colors;
    public float blockPositionX;
    public float blockPositionY;
    private GameObject blocksContainer;
    public List<Block> blocks { get; set; }
    public int rows;
    public int columns;

    public static int lives = 3;
    public static int points = 0;
    public static int totalBlocks = 0;
    public GUISkin layout;
    int count = 0;

    void Start()
    {
        this.blocksContainer = new GameObject("blocksContainer");
        this.generateBlocks();
    }

    void Update() {
        count = 1;
        if(totalBlocks <= totalBlocks - 3) {
            generateBlocks();
            lives++;
            if (count == 1) points += 500;
        }
    }

    private void generateBlocks()
    {
        float position_x = blockPositionX;
        float position_y = blockPositionY;

        this.blocks = new List<Block>();

        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.columns; j++)
            {
                int colorType = Random.Range(0, 4);
                totalBlocks++;

                Vector3 blockPosition = new Vector3(position_x, position_y,0.0f);
                Block block = Instantiate(blockPrefab, blockPosition, Quaternion.identity) as Block;
                block.Init(blocksContainer.transform,this.sprite, this.colors[colorType], colorType);
                this.blocks.Add(block);
                position_x += 11.0f;
            }
            position_x = -98.0f;
            position_y -= 11.0f;
        }
    }

    void OnGUI() {
        GUI.skin = layout;
        GUI.Label (new Rect (Screen.width / 2 - 300, 90, 100, 100), "PONTOS:");
        GUI.Label (new Rect (Screen.width / 2 - 300 + 65, 90, 100, 100), "" + points);
        GUI.Label (new Rect (Screen.width / 2 - 300, 110, 100, 100), "VIDAS:");

        for (int i = 0; i < lives; i++){
            GUI.Label (new Rect (Screen.width / 2 - 300 + 50 + (10 * i), 110, 100, 100), "X");
        }

        if (lives <= 0) {
            GUI.Label (new Rect (Screen.width / 2 - 40, Screen.height / 2, 100, 100), "GAME OVER");
            GUI.Label (new Rect (Screen.width / 2 - 60, Screen.height / 2 + 20, 1000, 100), "PONTUAÇÃO FINAL: " + BlockManager.points);
        }
    }
}
