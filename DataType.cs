using System;
using System.Collections.Generic;
using System.IO;

namespace asdf {
	internal class DataType {
		public static Map mapData = new Map();
		public static Scenario scenarioData = new Scenario();

		public static string[] sectionNameList = {
			"TYPE", "VER ", "IVER", "IVE2", "VCOD",
			"IOWN", "OWNR", "ERA ", "DIM ", "SIDE",
			"MTXM", "PUNI", "UPGR", "PTEC", "UNIT",
			"ISOM", "TILE", "DD2 ", "THG2", "MASK",
			"STR ", "STRx", "UPRP", "UPUS", "MRGN",
			"TRIG", "MBRF", "SPRP", "FORC", "WAV ",
			"UNIS", "UPGS", "TECS", "SWNM", "COLR",
			"CRGB", "PUPx", "PTEx", "UNIx", "UPGx",
			"TECx"
		};
	}

	public class Map {
		private string path;
		private string name;
		private string hexstr;

		public void SetPath(string _path) {
			path = _path;
			string[] tmpDelimiter = path.Split('\\');
			name = tmpDelimiter[tmpDelimiter.Length - 1];
		}

		public string GetPath() {
			return path;
		}

		public string GetName() {
			return name;
		}

		public void SetString(string _hexstr) {
			hexstr = _hexstr;
		}

		public string GetString() {
			return hexstr;
		}
	}

	public class Scenario {
		private string path = "staredit\\scenario.chk";
		public LinkedList<byte[]>[] sectionMap = new LinkedList<byte[]>[41];

		public Scenario() {
			for (int i = 0; i < 41; i++) {
				sectionMap[i] = new LinkedList<byte[]>();
			}
		}

		public string GetPath() {
			return path;
		}
	}
}
