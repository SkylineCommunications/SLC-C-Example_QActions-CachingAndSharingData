using System;

using QAction_200;

using Skyline.DataMiner.Scripting;

/// <summary>
/// DataMiner QAction Class: Share Across Multiple Runs of the Same QAction.
/// </summary>
public class QAction
{
	private readonly ShareData data = new ShareData();

	/// <summary>
	/// The QAction entry point.
	/// </summary>
	/// <param name="protocol">Link with SLProtocol process.</param>
	public void Run(SLProtocol protocol)
	{
		try
		{
			data.QActionRunsCount++;
			protocol.Log($"QA{protocol.QActionID}|Run|data.QActionRunsCount '{data.QActionRunsCount}'", LogType.Error, LogLevel.NoLogging);
		}
		catch (Exception ex)
		{
			protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
		}
	}
}