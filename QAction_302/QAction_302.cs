using System;

using Skyline.DataMiner.Scripting;
using Skyline.Protocol.Sharing;

/// <summary>
/// DataMiner QAction Class: Share Across Multiple QActions - QA101.
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
			/* Via singleton will work at first sight but elements running in the same SLScripting process will interfere with each other.
			 */
			{
				var data = CachedAndShared_Singleton.GetInstance();

				data.QA302_RunsCount++;
				protocol.Log($"QA{protocol.QActionID}|Singleton|QA301 Run Count '{data.QA301_RunsCount}' - QA302 Run Count '{data.QA302_RunsCount}'", LogType.DebugInfo, LogLevel.NoLogging);
			}

			/* Via static dictionary will work fine but will require cleanup when element is stopped.
			 */
			{
				var data = CachedAndShared_Dictionary.GetData(protocol);

				data.QA302_RunsCount++;
				protocol.Log($"QA{protocol.QActionID}|Dictionary|QA301 Run Count '{data.QA301_RunsCount}' - QA302 Run Count '{data.QA302_RunsCount}'", LogType.DebugInfo, LogLevel.NoLogging);
			}
		}
		catch (Exception ex)
		{
			protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
		}
	}
}