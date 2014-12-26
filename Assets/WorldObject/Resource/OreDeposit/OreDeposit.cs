﻿using UnityEngine;
using System.Collections;
using RTS;

public class OreDeposit : Resource {
    private int numBlocks;

	// Use this for initialization
	protected override void Start () {
        base.Start();

        numBlocks = GetComponentsInChildren<Ore>().Length;
        resourceType = ResourceType.Ore;
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();

        float percentLeft = (float)amountLeft / (float)capacity;
        if (percentLeft < 0) {
            percentLeft = 0;
        }

        int numBlocksToShow = (int)(percentLeft * numBlocks);
        Ore[] blocks = GetComponentsInChildren<Ore>();
        if (numBlocksToShow >= 0 && numBlocksToShow < blocks.Length) {
            Ore[] sortedBlocks = new Ore[blocks.Length];

            // Sort the list from highest to lowest
            foreach (Ore ore in blocks) {
                sortedBlocks[blocks.Length - int.Parse(ore.name)] = ore;
            }
            for (int i = numBlocksToShow; i < sortedBlocks.Length; i++) {
                sortedBlocks[i].renderer.enabled = false;
            }
            CalculateBounds();
        }
	}
}
