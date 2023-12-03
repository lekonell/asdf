namespace asdf {
	partial class Form1 {
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnSaveMapAs = new System.Windows.Forms.Button();
			this.btnSaveMap = new System.Windows.Forms.Button();
			this.btnOpenMap = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnProtect = new System.Windows.Forms.Button();
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnSaveMapAs);
			this.groupBox1.Controls.Add(this.btnSaveMap);
			this.groupBox1.Controls.Add(this.btnOpenMap);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(216, 152);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "File";
			// 
			// btnSaveMapAs
			// 
			this.btnSaveMapAs.Enabled = false;
			this.btnSaveMapAs.Location = new System.Drawing.Point(157, 90);
			this.btnSaveMapAs.Margin = new System.Windows.Forms.Padding(4);
			this.btnSaveMapAs.Name = "btnSaveMapAs";
			this.btnSaveMapAs.Size = new System.Drawing.Size(49, 46);
			this.btnSaveMapAs.TabIndex = 2;
			this.btnSaveMapAs.Text = "As";
			this.btnSaveMapAs.UseVisualStyleBackColor = true;
			this.btnSaveMapAs.Click += new System.EventHandler(this.btnSaveMapAs_Click);
			// 
			// btnSaveMap
			// 
			this.btnSaveMap.Enabled = false;
			this.btnSaveMap.Location = new System.Drawing.Point(9, 90);
			this.btnSaveMap.Margin = new System.Windows.Forms.Padding(4);
			this.btnSaveMap.Name = "btnSaveMap";
			this.btnSaveMap.Size = new System.Drawing.Size(140, 48);
			this.btnSaveMap.TabIndex = 1;
			this.btnSaveMap.Text = "Save";
			this.btnSaveMap.UseVisualStyleBackColor = true;
			this.btnSaveMap.Click += new System.EventHandler(this.btnSaveMap_Click);
			// 
			// btnOpenMap
			// 
			this.btnOpenMap.Location = new System.Drawing.Point(9, 30);
			this.btnOpenMap.Margin = new System.Windows.Forms.Padding(4);
			this.btnOpenMap.Name = "btnOpenMap";
			this.btnOpenMap.Size = new System.Drawing.Size(199, 51);
			this.btnOpenMap.TabIndex = 0;
			this.btnOpenMap.Text = "Open";
			this.btnOpenMap.UseVisualStyleBackColor = true;
			this.btnOpenMap.Click += new System.EventHandler(this.btnOpenMap_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnProtect);
			this.groupBox2.Location = new System.Drawing.Point(237, 13);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox2.Size = new System.Drawing.Size(216, 152);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Protect";
			// 
			// btnProtect
			// 
			this.btnProtect.Enabled = false;
			this.btnProtect.Location = new System.Drawing.Point(9, 30);
			this.btnProtect.Margin = new System.Windows.Forms.Padding(4);
			this.btnProtect.Name = "btnProtect";
			this.btnProtect.Size = new System.Drawing.Size(199, 106);
			this.btnProtect.TabIndex = 0;
			this.btnProtect.Text = "Protect";
			this.btnProtect.UseVisualStyleBackColor = true;
			this.btnProtect.Click += new System.EventHandler(this.btnProtect_Click);
			// 
			// dlgOpenFile
			// 
			this.dlgOpenFile.Filter = "스타크래프트 맵 파일 (*.scm, *.scx, *.chk)|*.scm;*.scx;*.chk|모든 파일 (*.*)|*.*";
			this.dlgOpenFile.FileOk += new System.ComponentModel.CancelEventHandler(this.dlgOpenFile_FileOk_1);
			// 
			// dlgSaveFile
			// 
			this.dlgSaveFile.Filter = "스타크래프트 맵 파일 (*.scm, *.scx, *.chk)|*.scm;*.scx;*.chk|모든 파일 (*.*)|*.*";
			this.dlgSaveFile.FileOk += new System.ComponentModel.CancelEventHandler(this.dlgSaveFile_FileOk);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(463, 178);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "asdf";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSaveMapAs;
		private System.Windows.Forms.Button btnSaveMap;
		private System.Windows.Forms.Button btnOpenMap;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnProtect;
		private System.Windows.Forms.OpenFileDialog dlgOpenFile;
		private System.Windows.Forms.SaveFileDialog dlgSaveFile;
	}
}

