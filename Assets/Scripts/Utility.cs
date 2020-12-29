using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static bool ContainsAllPositions(List<Position> positions, List<Position> wantedPositions)
	{
		foreach (Position tmpWPos in wantedPositions)
		{
			if (!positions.Contains(tmpWPos))
			{
				return false;
			}
		}
		return true;
	}
}
