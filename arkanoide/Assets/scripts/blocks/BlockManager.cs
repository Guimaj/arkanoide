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

    void Start()
    {
        this.blocksContainer = new GameObject("blocksContainer");
        this.generateBlocks();
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

                Vector3 blockPosition = new Vector3(position_x, position_y,0.0f);
                Block block = Instantiate(blockPrefab, blockPosition, Quaternion.identity) as Block;
                block.Init(blocksContainer.transform,this.sprite,this.colors[colorType]);
                this.blocks.Add(block);
                position_x += 11.0f;
            }
            position_x = -98.0f;
            position_y -= 11.0f;
        }
    }
}
