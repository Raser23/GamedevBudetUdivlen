using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{

    public readonly Node[] lookPoints;
	public readonly Line[] turnBoundaries;
	public readonly int finishLineIndex;

    public Path(Node[] waypoints, Vector3 startPos, float turnDst)
	{
        lookPoints = waypoints;
		turnBoundaries = new Line[lookPoints.Length];
		finishLineIndex = turnBoundaries.Length - 1;

		Vector2 previousPoint = V3ToV2(startPos);
        for (int i = 0; i < lookPoints.Length; i++)
		{
            Vector2 currentPoint = V3ToV2(lookPoints[i].position);
			Vector2 dirToCurrentPoint = (currentPoint - previousPoint).normalized;
			Vector2 turnBoundaryPoint = (i == finishLineIndex) ? currentPoint : currentPoint - dirToCurrentPoint * turnDst;
			turnBoundaries[i] = new Line(turnBoundaryPoint, previousPoint - dirToCurrentPoint * turnDst);
			previousPoint = turnBoundaryPoint;
		}
	}

	Vector2 V3ToV2(Vector3 v3)
	{
		return new Vector2(v3.x, v3.y);
	}

	public void DrawWithGizmos()
	{

		Gizmos.color = Color.black;
        foreach (Node p in lookPoints)
		{
            Gizmos.DrawCube(p.position , Vector3.one);
		}

		Gizmos.color = Color.white;
		foreach (Line l in turnBoundaries)
		{
			l.DrawWithGizmos(3);
		}

	}

}