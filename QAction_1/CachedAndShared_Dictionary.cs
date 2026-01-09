namespace Skyline.Protocol.Sharing
{
	using System.Collections.Concurrent;

	using Skyline.DataMiner.Scripting;

	public static class CachedAndShared_Dictionary
	{
		private static readonly ConcurrentDictionary<string, CachedAndShared> Data = new ConcurrentDictionary<string, CachedAndShared>();

		public static CachedAndShared GetData(SLProtocol protocol)
		{
			string key = $"{protocol.DataMinerID}/{protocol.ElementID}";
			return Data.GetOrAdd(key, (k) => new CachedAndShared());
		}
	}

	public class CachedAndShared
	{
		public int QA301_RunsCount { get; set; } = 0;

		public int QA302_RunsCount { get; set; } = 0;
	}
}
