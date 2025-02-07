using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

namespace NodeCanvas.Tasks.Actions {

	public class OrbitAT : ActionTask {


        public BBParameter<Vector3> targetPosition;

        public Transform target;
        public float speed;

		public float radius;
		//math part

		public float angle;

		public float offset;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			GetAngle();
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}



		private void GetAngle()
		{



			//angle value that increases over time


			//Vector currentTarget = (cos(angle), 0,  sin(angle)) * orbitSize;


			//angle = Vector3.Angle(agent.transform.position, target.transform.position);
			angle += speed * Time.deltaTime;
			Vector3 currentAngle = target.position + new Vector3(Mathf.Cos(angle),0, Mathf.Sin(angle)) * radius;

			Debug.DrawLine(currentAngle, agent.transform.position,Color.red);

            targetPosition.value = currentAngle;

            //Debug.DrawLine();
        }


		/*override public void OnDrawGizmos()
		{
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(target.transform.position, radius);
			
		}*/
	}
}