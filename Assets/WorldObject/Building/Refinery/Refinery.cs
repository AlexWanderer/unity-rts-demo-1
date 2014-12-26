using UnityEngine;
using System.Collections;

public class Refinery : Building {

	// Use this for initialization
	protected override void Start () {
        base.Start();

        actions = new string[] { "Harvester" };
	}

    protected override bool ShouldMakeDecision() {
        return false;
    }

    public override void PerformAction(string actionToPerform) {
        base.PerformAction(actionToPerform);

        CreateUnit(actionToPerform);
    }
}
