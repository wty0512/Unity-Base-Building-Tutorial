﻿using UnityEngine;
using System.Collections;

public class FurnitureActions {

	public static void Door_UpdateAction(Furniture furn, float deltaTime) {
		if (furn.furnParameters["is_opening"] >= 1) {
			furn.furnParameters["openness"] += deltaTime * 4;
			if (furn.furnParameters["openness"] >= 1) {
				furn.furnParameters["is_opening"] = 0;
			}
		} else {
			furn.furnParameters["openness"] -= deltaTime * 4;
		}
		furn.furnParameters["openness"] = Mathf.Clamp01(furn.furnParameters["openness"]);

		if (furn.cbOnChanged != null)
			furn.cbOnChanged(furn);
 	}

	public static Enterability Door_IsEnterable(Furniture furn) {
		furn.furnParameters["is_opening"] = 1;

		if (furn.furnParameters["openness"] >= 1) {
			return Enterability.Yes;
		} else {
			return Enterability.Soon;
		}
	}
}