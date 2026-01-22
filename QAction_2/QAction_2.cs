using System;

using Skyline.DataMiner.Scripting;
using Skyline.Protocol.Sharing;

/// <summary>
/// DataMiner QAction Class: After Startup.
/// </summary>
public class QAction : IDisposable
{
	private SLProtocol protocol;

	/// <summary>
	/// The QAction entry point.
	/// </summary>
	/// <param name="protocol">Link with SLProtocol process.</param>
	public void Run(SLProtocol protocol)
	{
		try
		{
			// Store protocol instance for access within Dispose.
			this.protocol = protocol;

			// Clean up ShareData to prevent issues with stale data.
			CachedAndShared_Dictionary.Cleanup(protocol);
		}
		catch (Exception ex)
		{
			protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
		}
	}

	/// <summary>
	/// Disposes resources.
	/// </summary>
	public void Dispose()
	{
		try
		{
			// Clean up ShareData to prevent a memory leak.
			CachedAndShared_Dictionary.Cleanup(protocol);
		}
		catch
		{
			/* Dispose method should never throw exceptions. */
		}
	}
}
