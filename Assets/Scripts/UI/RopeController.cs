using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class RopeController : MonoBehaviour {

		private LineRenderer m_lineRenderer;

		public Transform m_startPos;
		public Transform m_endPos;

		// Use this for initialization
		void Start() {
			m_lineRenderer = GetComponent<LineRenderer>();
			m_lineRenderer.numPositions = 2;
			m_lineRenderer.SetPosition(0 , m_startPos.position);
		}

		// Update is called once per frame
		void Update() {
			
			m_lineRenderer.SetPosition(1 , m_endPos.position);
		}
	}
}