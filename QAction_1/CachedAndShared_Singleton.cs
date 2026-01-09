namespace Skyline.Protocol.Sharing
{
	public class CachedAndShared_Singleton
	{
		private static CachedAndShared_Singleton singleton;

		private CachedAndShared_Singleton()
		{
		}

		public int QA301_RunsCount { get; set; } = 0;

		public int QA302_RunsCount { get; set; } = 0;

		public static CachedAndShared_Singleton GetInstance()
		{
			if (singleton == null)
			{
				singleton = new CachedAndShared_Singleton();
			}

			return singleton;
		}
	}
}