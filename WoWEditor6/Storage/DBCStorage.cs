﻿using WoWEditor6.IO.Files;

namespace WoWEditor6.Storage
{
    static class DbcStorage
    {
        public static DbcFile Map { get; } = new DbcFile();
        public static DbcFile LoadingScreen { get; } = new DbcFile();
        public static DbcFile Light { get; } = new DbcFile();
        public static DbcFile LightData { get; } = new DbcFile();
        public static DbcFile LightParams { get; } = new DbcFile();
        public static DbcFile ZoneLight { get; } = new DbcFile();
        public static DbcFile ZoneLightPoint { get; } = new DbcFile();
	    public static DbcFile LightIntBand { get; } = new DbcFile();
	    public static DbcFile LightFloatBand { get; } = new DbcFile();

		public static void Initialize()
		{
			Map.Load(@"DBFilesClient\Map.dbc");
			LoadingScreen.Load(@"DBFilesClient\LoadingScreens.dbc");
			Light.Load(@"DBFilesClient\Light.dbc");

			if (IO.FileManager.Instance.Version <= IO.FileDataVersion.Mists)
				InitLightsMop();

			if(IO.FileManager.Instance.Version == IO.FileDataVersion.Lichking)
			{
				LightIntBand.Load(@"DBFilesClient\LightIntBand.dbc");
				LightFloatBand.Load(@"DBFilesClient\LightFloatBand.dbc");
			}

			MapFormatGuess.Initialize();
			IO.Files.Sky.SkyManager.Instance.Initialize();
		}

	    private static void InitLightsMop()
		{
			LightData.Load(@"DBFilesClient\LightData.dbc");
			LightParams.Load(@"DBFilesClient\LightParams.dbc");
			ZoneLight.Load(@"DBFilesClient\ZoneLight.dbc");
			ZoneLightPoint.Load(@"DBFilesClient\ZoneLightPoint.dbc");
		}
    }
}
