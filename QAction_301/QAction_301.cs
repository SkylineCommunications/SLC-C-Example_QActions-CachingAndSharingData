using System;

using Skyline.DataMiner.Scripting;
using Skyline.Protocol.Sharing;

/// <summary>
/// DataMiner QAction Class: Share Across Multiple QActions - QA100.
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
			/* Use static ConcurrentDictionary in order to isolate data per element.
			 */
			var data = CachedAndShared_Dictionary.GetData(protocol);

			data.QA301_RunsCount++;
			protocol.Log($"QA{protocol.QActionID}|Dictionary|QA301 Run Count '{data.QA301_RunsCount}' - QA302 Run Count '{data.QA302_RunsCount}'", LogType.DebugInfo, LogLevel.NoLogging);

			/* !!! Don't use Singleton !!!
			 * It will seem to work at first sight but elements running in the same SLScripting process will interfere with each other.
			 */
			////var data = CachedAndShared_Singleton.GetInstance();

			////data.QA301_RunsCount++;
			////protocol.Log($"QA{protocol.QActionID}|Singleton|QA301 Run Count '{data.QA301_RunsCount}' - QA302 Run Count '{data.QA302_RunsCount}'", LogType.DebugInfo, LogLevel.NoLogging);
		}
		catch (Exception ex)
		{
			protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
		}
	}
}