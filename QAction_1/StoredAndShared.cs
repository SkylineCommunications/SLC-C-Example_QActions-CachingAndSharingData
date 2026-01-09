namespace Skyline.Protocol.Storing
{
	using Newtonsoft.Json;

	using Skyline.DataMiner.Utils.SecureCoding.SecureSerialization.Json.Newtonsoft;

	public class StoredAndShared
	{
		public int QA101_RunsCount { get; set; } = 0;

		public int QA102_RunsCount { get; set; } = 0;

		public static StoredAndShared Deserialize(string serialized)
		{
			if (string.IsNullOrWhiteSpace(serialized))
			{
				return new StoredAndShared();
			}

			return SecureNewtonsoftDeserialization.DeserializeObject<StoredAndShared>(serialized);
		}

		public string Serialize()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
