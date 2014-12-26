using UnityEngine;
using System.Collections;

class WarFactory : Building {

    protected override void Start() {
        base.Start();
        actions = new string[] { "Tank", "ConvoyTruck" };
    }

    protected override bool ShouldMakeDecision() {
        return false;
    }

    public override void PerformAction(string actionToPerform) {
        base.PerformAction(actionToPerform);
        CreateUnit(actionToPerform);
    }
}
