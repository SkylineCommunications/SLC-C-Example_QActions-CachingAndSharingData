using System;

using Skyline.DataMiner.Scripting;
using Skyline.Protocol.Storing;

/// <summary>
/// DataMiner QAction Class: Store Across Multiple QActions - QA101.
/// </summary>
public static class QAction
{
	/// <summary>
	/// The QAction entry point.
	/// </summary>
	/// <param name="protocol">Link with SLProtocol process.</param>
	public static void Run(SLProtocol protocol)
	{
		try
		{
			var dataSerialized = Convert.ToString(protocol.GetParameter(Parameter.storing_dataparameter));
			var data = StoredAndShared.Deserialize(dataSerialized);

			data.QA101_RunsCount++;
			protocol.Log($"QA{protocol.QActionID}|Run|QA101 Run Count '{data.QA101_RunsCount}' - QA102 Run Count '{data.QA102_RunsCount}'", LogType.DebugInfo, LogLevel.NoLogging);

			protocol.SetParameter(Parameter.storing_dataparameter, data.Serialize());
		}
		catch (Exception ex)
		{
			protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
		}
	}
}