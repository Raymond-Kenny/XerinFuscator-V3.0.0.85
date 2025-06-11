namespace XProtections.AntiCrack.Globals
{
	public static class Global
	{
		public static string excludeString;

		public static string api;

		public static string webhookLink;

		public static string customMessage;

		public static bool Normal;

		public static bool Exclude;

		public static bool Silent;

		public static bool Bsod;

		static Global()
		{
			excludeString = "";
			api = "";
			webhookLink = "";
			customMessage = "";
			Normal = false;
			Exclude = false;
			Silent = false;
			Bsod = false;
		}
	}
}
