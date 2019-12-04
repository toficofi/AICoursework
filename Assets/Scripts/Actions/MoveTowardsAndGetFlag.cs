﻿using UnityEngine;

namespace Assets.Scripts.Actions
{
    class MoveTowardsAndGetFlag : UtilityAction
    {
        public override void Execute(Agent agent, World world, float t)
        {
            if (world.agentWithFlag != null)
            {
                Debug.Log("Tried to MoveTorwardsAndGetFlag when agent " + world.agentWithFlag.agentName + " already has it", agent.gameObject);
                return;
            }

            Vector3 direction = world.flag.transform.position - agent.transform.position;

            // tries to get the flag if it's near enough
            agent.GetFlag(world);

            world.StartCoroutine(MoveInDirection(agent, direction, t));
        }

        public override string ToString()
        {
            return "MoveTowardsAndGetFlag";
        }
    }
}