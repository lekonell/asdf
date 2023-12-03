using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TkMPQLib;
using static asdf.DataType;

namespace asdf {
	public partial class Form1 : Form {

		public TkMPQ tkMPQ = null;

		public Form1() {
			InitializeComponent();
		}

		private void btnOpenMap_Click(object sender, EventArgs e) {
			dlgOpenFile.ShowDialog();
		}

		public static string ByteToHex(byte[] bytes) {
			string hex = BitConverter.ToString(bytes);

			return hex.Replace("-", "");
		}

		private void LoadMap(string filePath) {
			Byte[] mapBytes = File.ReadAllBytes(filePath);
			mapData.SetString(ByteToHex(mapBytes));

			Byte[] MPQSignature = { 0x4D, 0x50, 0x51, 0x1A };

			bool isMPQ = true;
			for (int i = 0; i < 4; i++) {
				if (mapBytes[i] != MPQSignature[i]) {
					isMPQ = false;
					break;
				}
			}

			// MPQ File
			if (isMPQ) {
				try {
					tkMPQ = new TkMPQ(filePath);
				}
				catch (Exception ex) {
					return;
				}

				MPQReader tkMPQReader = tkMPQ.GetFile("staredit\\scenario.chk");
				string[] MPQPathList = tkMPQ.Listfile.GetPaths();

				try {
					FileStream fs = new FileStream("scenario.chk", FileMode.Create, FileAccess.Write);
					tkMPQReader.WriteTo(fs);
					fs.Flush();
					fs.Close();
				}
				catch {
					return;
				}

				tkMPQReader.Close();
			}

			// Scenario.chk File
			else {
				File.WriteAllBytes("scenario.chk", mapBytes);
			}

			string[] pathSplitted = filePath.Split('\\');
			string tmpLogName = pathSplitted[pathSplitted.Length - 1];

			int pos;
			for (pos = tmpLogName.Length - 1; pos >= 0; pos--) {
				if (tmpLogName[pos] == '.') {
					break;
				}
			}

			LoadSection();
			RepairTerrian();
		}

		public static byte[] GetSection(string sectionName) {
			int sectionIndex = Array.IndexOf(sectionNameList, sectionName);

			if (scenarioData.sectionMap[sectionIndex].Count == 0) {
				return null;
			}

			return scenarioData.sectionMap[sectionIndex].First.Value;
		}

		public static void SetSection(string sectionName, Byte[] data) {
			int sectionIndex = Array.IndexOf(sectionNameList, sectionName);

			scenarioData.sectionMap[sectionIndex].Clear();
			scenarioData.sectionMap[sectionIndex].AddLast(data);
		}

		private void btnProtect_Click(object sender, EventArgs e) {
			Byte[] ERABytes = GetSection("ERA ");
			ERABytes[0] &= 0b00000111;
			ERABytes[0] |= 0b00001000;

			SetSection("ERA ", ERABytes);
		}

		private void btnSaveMapAs_Click(object sender, EventArgs e) {
			dlgSaveFile.FileName = mapData.GetName();
			dlgSaveFile.ShowDialog();
		}

		private void btnSaveMap_Click(object sender, EventArgs e) {
			SaveMap(mapData.GetPath());
		}

		public int AppendSaveByte(ref Byte[] saveBytes, string sectionName, int prevSize) {
			int sectionIndex = Array.IndexOf(sectionNameList, sectionName);
			if (scenarioData.sectionMap[sectionIndex].Count() == 0)
				return prevSize;

			byte[] sectionNameToBytes = Encoding.Default.GetBytes(sectionName);
			byte[] sectionLengthToBytes = BitConverter.GetBytes(scenarioData.sectionMap[sectionIndex].First.Value.Length);
			byte[] sectionBytes = scenarioData.sectionMap[sectionIndex].First.Value;
			int newSize = prevSize;

			newSize += sectionNameToBytes.Length;
			Array.Resize(ref saveBytes, newSize);
			Buffer.BlockCopy(sectionNameToBytes, 0, saveBytes, newSize - sectionNameToBytes.Length, sectionNameToBytes.Length);

			newSize += 4;
			Array.Resize(ref saveBytes, newSize);
			Buffer.BlockCopy(sectionLengthToBytes, 0, saveBytes, newSize - sectionLengthToBytes.Length, sectionLengthToBytes.Length);

			newSize += sectionBytes.Length;
			Array.Resize(ref saveBytes, newSize);
			Buffer.BlockCopy(sectionBytes, 0, saveBytes, newSize - sectionBytes.Length, sectionBytes.Length);

			return newSize;
		}

		private void SaveMap(string savePath) {
			int newSize = 0;
			Byte[] saveBytes = new byte[0];

			for (int i = 0; i < sectionNameList.Length; i++) {
				newSize = AppendSaveByte(ref saveBytes, sectionNameList[i], newSize);
			}

			if (savePath.EndsWith(".chk")) {
				File.WriteAllBytes(savePath, saveBytes);
			}
			else {
				int idxScenarioChk = tkMPQ.FindFile("staredit\\scenario.chk");
				tkMPQ.Delete(idxScenarioChk);

				MPQWriter tkMPQWriter = tkMPQ.CreateFile("staredit\\scenario.chk");
				tkMPQWriter.Write(saveBytes, 0, saveBytes.Length);
				tkMPQWriter.Flush();

				tkMPQ.WriteFile(tkMPQWriter);
				tkMPQWriter.Close();

				FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
				tkMPQ.SaveMPQ(fs);
				fs.Close();
			}
		}

		private void dlgOpenFile_FileOk_1(object sender, CancelEventArgs e) {
			string selectedFile = dlgOpenFile.FileName;

			if (mapData.GetString() == selectedFile)
				return;
			mapData.SetPath(selectedFile);

			btnSaveMap.Enabled = true;
			btnSaveMapAs.Enabled = true;
			btnProtect.Enabled = true;

			LoadMap(selectedFile);
		}

		private void dlgSaveFile_FileOk(object sender, CancelEventArgs e) {
			string savePath = dlgSaveFile.FileName;
			SaveMap(savePath);
		}

		private void RepairTerrian() {
			Byte[] MTXMBytes = GetSection("MTXM");

			int dataPos = 0;
			while (dataPos < MTXMBytes.Length) {
				uint tileID = BitConverter.ToUInt16(MTXMBytes, dataPos);
				if (tileID == 0) {
					MTXMBytes[dataPos] = 0x01;
				}

				dataPos += 2;
			}

			SetSection("MTXM", MTXMBytes);
			SetSection("TILE", MTXMBytes);
		}

		public static int GetLittleEndianIntegerFromByteArray(byte[] data, int startIndex) {
			return (data[startIndex + 3] << 24)
				 | (data[startIndex + 2] << 16)
				 | (data[startIndex + 1] << 8)
				 | data[startIndex];
		}

		private void LoadSection() {
			Byte[] dataBytes = File.ReadAllBytes("scenario.chk");
			int dataPos = 0;
			while (dataPos < dataBytes.Length) {
				string sectionName = "";

				for (int i = 0; i < 4; i++) {
					sectionName += Convert.ToChar(dataBytes.GetValue(dataPos + i));
				}
				dataPos += 4;
				
				int sectionIndex = Array.IndexOf(sectionNameList, sectionName);
				int sectionLength = GetLittleEndianIntegerFromByteArray(dataBytes, dataPos);
				dataPos += 4;

				// illegal section
				if (sectionIndex == -1) {
					dataPos += sectionLength;
					continue;
				}

				// overflow
				if (sectionLength < 0 || dataPos > dataBytes.Length)
					break;

				Byte[] sectionBytes = new byte[sectionLength];
				Array.Copy(dataBytes, dataPos, sectionBytes, 0, sectionLength);
				dataPos += sectionLength;

				scenarioData.sectionMap[sectionIndex].AddLast(sectionBytes);
			}
		}

		private void Form1_Load(object sender, EventArgs e) {

		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			File.Delete("scenario.chk");
		}
	}
}
