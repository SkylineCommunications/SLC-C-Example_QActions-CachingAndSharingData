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

			/* Keep in mind that the Func passed to the GetOrAdd method could be called more than once for the same key even though the GetOrAdd method will guarantee that only one reference of the object is returned.
			 * This is due to the fact that it is called outside of the internal locks of the ConcurrentDictionary.
			 * This means that, it's important to follow the best practice of not performing any complex initialization within the constructor. */
		}

		public static void Cleanup(SLProtocol protocol)
		{
			string key = $"{protocol.DataMinerID}/{protocol.ElementID}";
			Data.TryRemove(key, out _);
		}
	}

	public class CachedAndShared
	{
		public int QA301_RunsCount { get; set; } = 0;

		public int QA302_RunsCount { get; set; } = 0;
	}
}
