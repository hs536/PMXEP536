namespace PMXEP536
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.button1 = new System.Windows.Forms.Button();
            this.mat_default_setting = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bone_rename = new System.Windows.Forms.CheckBox();
            this.bone_setup_eyes = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mo_setup_view = new System.Windows.Forms.CheckBox();
            this.test_invalid_value = new System.Windows.Forms.CheckBox();
            this.bone_setup_legIK = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.console_box = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.console_box_filter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.sep = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bone_add_stdbone = new System.Windows.Forms.CheckBox();
            this.bone_sort = new System.Windows.Forms.CheckBox();
            this.bone_setup_view = new System.Windows.Forms.CheckBox();
            this.bone_visible = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(16, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(744, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "実行ｵﾅｼｬｽ！";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.execute);
            // 
            // mat_default_setting
            // 
            this.mat_default_setting.AutoSize = true;
            this.mat_default_setting.BackColor = System.Drawing.SystemColors.Control;
            this.mat_default_setting.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.mat_default_setting.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mat_default_setting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mat_default_setting.Location = new System.Drawing.Point(288, 40);
            this.mat_default_setting.Name = "mat_default_setting";
            this.mat_default_setting.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mat_default_setting.Size = new System.Drawing.Size(200, 20);
            this.mat_default_setting.TabIndex = 1;
            this.mat_default_setting.Text = "基本設定(拡1/反0/環0.5)";
            this.mat_default_setting.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "■ 読み込み設定：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(272, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "■ ボーン設定：";
            // 
            // bone_rename
            // 
            this.bone_rename.AutoSize = true;
            this.bone_rename.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.bone_rename.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bone_rename.Location = new System.Drawing.Point(32, 40);
            this.bone_rename.Name = "bone_rename";
            this.bone_rename.Size = new System.Drawing.Size(197, 20);
            this.bone_rename.TabIndex = 1;
            this.bone_rename.Text = "ボーン変換 [Unity->MMD]";
            this.bone_rename.UseVisualStyleBackColor = true;
            // 
            // bone_setup_eyes
            // 
            this.bone_setup_eyes.AutoSize = true;
            this.bone_setup_eyes.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.bone_setup_eyes.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bone_setup_eyes.Location = new System.Drawing.Point(288, 120);
            this.bone_setup_eyes.Name = "bone_setup_eyes";
            this.bone_setup_eyes.Size = new System.Drawing.Size(142, 20);
            this.bone_setup_eyes.TabIndex = 1;
            this.bone_setup_eyes.Text = "両目ボーンの設定";
            this.bone_setup_eyes.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(536, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "■ モーフ設定：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(536, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "■ テスト：";
            // 
            // mo_setup_view
            // 
            this.mo_setup_view.AutoSize = true;
            this.mo_setup_view.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.mo_setup_view.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mo_setup_view.Location = new System.Drawing.Point(552, 40);
            this.mo_setup_view.Name = "mo_setup_view";
            this.mo_setup_view.Size = new System.Drawing.Size(143, 20);
            this.mo_setup_view.TabIndex = 1;
            this.mo_setup_view.Text = "モーフ表示枠設定";
            this.mo_setup_view.UseVisualStyleBackColor = true;
            // 
            // test_invalid_value
            // 
            this.test_invalid_value.AutoSize = true;
            this.test_invalid_value.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.test_invalid_value.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.test_invalid_value.Location = new System.Drawing.Point(552, 184);
            this.test_invalid_value.Name = "test_invalid_value";
            this.test_invalid_value.Size = new System.Drawing.Size(120, 20);
            this.test_invalid_value.TabIndex = 1;
            this.test_invalid_value.Text = "不正値の検証";
            this.test_invalid_value.UseVisualStyleBackColor = true;
            // 
            // bone_setup_legIK
            // 
            this.bone_setup_legIK.AutoSize = true;
            this.bone_setup_legIK.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.bone_setup_legIK.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bone_setup_legIK.Location = new System.Drawing.Point(288, 152);
            this.bone_setup_legIK.Name = "bone_setup_legIK";
            this.bone_setup_legIK.Size = new System.Drawing.Size(102, 20);
            this.bone_setup_legIK.TabIndex = 1;
            this.bone_setup_legIK.Text = "足IKの設定";
            this.bone_setup_legIK.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(16, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "■ コンソール：";
            // 
            // console_box
            // 
            this.console_box.BackColor = System.Drawing.SystemColors.Window;
            this.console_box.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.console_box.Location = new System.Drawing.Point(16, 360);
            this.console_box.Name = "console_box";
            this.console_box.ReadOnly = true;
            this.console_box.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.console_box.Size = new System.Drawing.Size(744, 272);
            this.console_box.TabIndex = 5;
            this.console_box.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // console_box_filter
            // 
            this.console_box_filter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.console_box_filter.FormattingEnabled = true;
            this.console_box_filter.Items.AddRange(new object[] {
            "DEBUG",
            "INFO",
            "WARN",
            "ERROR"});
            this.console_box_filter.Location = new System.Drawing.Point(672, 334);
            this.console_box_filter.Name = "console_box_filter";
            this.console_box_filter.Size = new System.Drawing.Size(88, 20);
            this.console_box_filter.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(576, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "出力フィルタ：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 334);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 20);
            this.button2.TabIndex = 8;
            this.button2.Text = "CLEAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.clear_console_click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(272, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "■ 材質設定：";
            // 
            // sep
            // 
            this.sep.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.sep.Location = new System.Drawing.Point(256, 8);
            this.sep.Multiline = true;
            this.sep.Name = "sep";
            this.sep.Size = new System.Drawing.Size(2, 264);
            this.sep.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Location = new System.Drawing.Point(520, 8);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(2, 264);
            this.textBox1.TabIndex = 9;
            // 
            // bone_add_stdbone
            // 
            this.bone_add_stdbone.AutoSize = true;
            this.bone_add_stdbone.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.bone_add_stdbone.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bone_add_stdbone.Location = new System.Drawing.Point(32, 96);
            this.bone_add_stdbone.Name = "bone_add_stdbone";
            this.bone_add_stdbone.Size = new System.Drawing.Size(210, 20);
            this.bone_add_stdbone.TabIndex = 1;
            this.bone_add_stdbone.Text = "MMD必須ボーン追加 [標準]";
            this.bone_add_stdbone.UseVisualStyleBackColor = true;
            // 
            // bone_sort
            // 
            this.bone_sort.AutoSize = true;
            this.bone_sort.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.bone_sort.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bone_sort.Location = new System.Drawing.Point(288, 184);
            this.bone_sort.Name = "bone_sort";
            this.bone_sort.Size = new System.Drawing.Size(101, 20);
            this.bone_sort.TabIndex = 1;
            this.bone_sort.Text = "ボーンソート";
            this.bone_sort.UseVisualStyleBackColor = true;
            // 
            // bone_setup_view
            // 
            this.bone_setup_view.AutoSize = true;
            this.bone_setup_view.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.bone_setup_view.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bone_setup_view.Location = new System.Drawing.Point(288, 248);
            this.bone_setup_view.Name = "bone_setup_view";
            this.bone_setup_view.Size = new System.Drawing.Size(145, 20);
            this.bone_setup_view.TabIndex = 1;
            this.bone_setup_view.Text = "ボーン表示枠設定";
            this.bone_setup_view.UseVisualStyleBackColor = true;
            // 
            // bone_visible
            // 
            this.bone_visible.AutoSize = true;
            this.bone_visible.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.bone_visible.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bone_visible.Location = new System.Drawing.Point(288, 216);
            this.bone_visible.Name = "bone_visible";
            this.bone_visible.Size = new System.Drawing.Size(129, 20);
            this.bone_visible.TabIndex = 1;
            this.bone_visible.Text = "ボーン表示設定";
            this.bone_visible.UseVisualStyleBackColor = true;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(778, 645);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.sep);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.console_box_filter);
            this.Controls.Add(this.console_box);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.test_invalid_value);
            this.Controls.Add(this.bone_visible);
            this.Controls.Add(this.bone_setup_view);
            this.Controls.Add(this.mo_setup_view);
            this.Controls.Add(this.bone_sort);
            this.Controls.Add(this.bone_setup_legIK);
            this.Controls.Add(this.bone_setup_eyes);
            this.Controls.Add(this.bone_add_stdbone);
            this.Controls.Add(this.bone_rename);
            this.Controls.Add(this.mat_default_setting);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PMXEP536";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox mat_default_setting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox bone_rename;
        private System.Windows.Forms.CheckBox bone_setup_eyes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox mo_setup_view;
        private System.Windows.Forms.CheckBox test_invalid_value;
        private System.Windows.Forms.CheckBox bone_setup_legIK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox console_box;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox console_box_filter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox sep;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox bone_add_stdbone;
        private System.Windows.Forms.CheckBox bone_sort;
		private System.Windows.Forms.CheckBox bone_setup_view;
        private System.Windows.Forms.CheckBox bone_visible;
	}
}