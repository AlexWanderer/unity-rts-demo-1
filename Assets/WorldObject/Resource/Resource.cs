﻿using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

using RTS;

public class Resource : WorldObject {
    public float capacity;

    protected float amountLeft;
    protected ResourceType resourceType;

	// Use this for initialization
	protected override void Start () {
        base.Start();

        resourceType = ResourceType.Unknown;
        if (loadedSavedValues) {
            return;
        }

        amountLeft = capacity;
	}

    protected override void CalculateCurrentHealth(float lowSplit, float highSplit) {
        healthPercentage = amountLeft / capacity;
        healthStyle.normal.background = ResourceManager.GetResourceHealthBar(resourceType);
    }

    public override void SaveDetails(JsonWriter writer) {
        base.SaveDetails(writer);
        SaveManager.WriteFloat(writer, "AmountLeft", amountLeft);
    }

    public void Remove(float amount) {
        amountLeft -= amount;
        if (amountLeft < 0) {
            amountLeft = 0;
        }
    }

    public bool isEmpty() {
        return amountLeft <= 0;
    }

    public ResourceType GetResourceType() {
        return resourceType;
    }

    protected override void HandleLoadedProperty(JsonTextReader reader, string propertyName, object readValue) {
        base.HandleLoadedProperty(reader, propertyName, readValue);
        switch (propertyName) {
            case "AmountLeft":
                amountLeft = (float)(double)readValue;
                break;
            default:
                break;
        }
    }

    protected override bool ShouldMakeDecision() {
        return false;
    }
}
