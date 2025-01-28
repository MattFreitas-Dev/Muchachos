using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBlock : MonoBehaviour
{

	[field: SerializeField] public DirectionalInformation[] BlockDirectionInformation { get; private set; }

	[field: SerializeField] public PhaseTime BlockWindowStart { get; private set; }

	[field: SerializeField] public PhaseTime BlockWindowEnd { get; private set; }

	[field: SerializeField] public GameObject Particles { get; private set; }

	[field: SerializeField] public Vector2 ParticlesOffset { get; private set; }

	public bool IsBlocked(float angle, out DirectionalInformation directionalInformation)
	{
		directionalInformation = null;

		foreach (var directionInformation in BlockDirectionInformation)
		{
			var blocked = directionInformation.IsAngleBetween(angle);

			if (!blocked)
				continue;

			directionalInformation = directionInformation;
			return true;
		}

		return false;
	}
}
