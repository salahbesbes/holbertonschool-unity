using System.Collections.Generic;
using UnityEngine;

public class PathRequestManager : MonoBehaviour
{
	private Queue<PathRequest> pathRequestQueue = new Queue<PathRequest>();
	private PathRequest currentPathRequest;
	public static PathRequestManager Instance;
	private bool isProcessing = false;

	private void Awake()
	{
		if (Instance == null) Instance = this;
	}

	public static void RequestPath(Node startNode, Node endNode, ActionType callback)
	{
		PathRequest newRequest = new PathRequest(startNode, endNode, callback);
		Instance.pathRequestQueue.Enqueue(newRequest);
		Instance.TryProcessNext();
	}

	private void TryProcessNext()
	{
		// if we are not processing and the que queue is not empty
		if (!isProcessing && pathRequestQueue.Count > 0)
		{
			isProcessing = true;
			currentPathRequest = pathRequestQueue.Dequeue();
			//FindPath.StartFindPath(currentPathRequest.startNode, currentPathRequest.endNode);
		}
	}

	public void finishedProcessingPath()
	{
		isProcessing = false;
		//currentPathRequest.callback();
		TryProcessNext();
	}
}

public class PathRequest
{
	public ActionType callback;
	public Node startNode;
	public Node endNode;

	public PathRequest(Node startNode, Node endNode, ActionType callback)
	{
		this.callback = callback;
		this.startNode = startNode;
		this.endNode = endNode;
	}
}