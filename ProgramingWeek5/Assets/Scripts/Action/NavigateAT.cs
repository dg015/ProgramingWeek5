using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class NavigateAT : ActionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		
		public BBParameter<Vector3> targetPosition;
		public float sampleRate;
		public float sampleDistance;


        private NavMeshAgent navAgent;
        private float timeSinceLastSample = 0f;
		private Vector3 lastDestination;

		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();


			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//set where the navmesh agent is moving
			timeSinceLastSample += Time.deltaTime;

			if (timeSinceLastSample > sampleRate)
			{
				if (lastDestination != targetPosition.value)
				{
					lastDestination = targetPosition.value;

					NavMeshHit navMeshHit;
					bool foundPoint = NavMesh.SamplePosition(targetPosition.value, out navMeshHit, sampleDistance, NavMesh.AllAreas);
					
					if(foundPoint)
					{
						navAgent.SetDestination(targetPosition.value);
					}

					navAgent.SetDestination(targetPosition.value);
				}

			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}