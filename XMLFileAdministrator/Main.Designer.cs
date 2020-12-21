namespace XMLFileAdministrator
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label RutaLabel;
            System.Windows.Forms.GroupBox SaveAsGroupBox;
            System.Windows.Forms.Label ExtensionLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ExportProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.OutFileNameTextBox = new System.Windows.Forms.TextBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.FileExtensionComboBox = new System.Windows.Forms.ComboBox();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.DownloadTab = new System.Windows.Forms.TabPage();
            this.SatWebBrowser = new System.Windows.Forms.WebBrowser();
            this.EditTab = new System.Windows.Forms.TabPage();
            this.LoadDataProgressBar = new System.Windows.Forms.ProgressBar();
            this.CleanButton = new System.Windows.Forms.Button();
            this.XMLDataGridView = new System.Windows.Forms.DataGridView();
            this.EditGroupBox = new System.Windows.Forms.GroupBox();
            this.ColumnasCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.LoadFilesGroupBox = new System.Windows.Forms.GroupBox();
            this.TypeOfFileComboBox = new System.Windows.Forms.ComboBox();
            this.RutaSpan = new System.Windows.Forms.RichTextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.ExportTab = new System.Windows.Forms.TabPage();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.HomeButton = new System.Windows.Forms.ToolStripButton();
            this.DownloadButton = new System.Windows.Forms.ToolStripButton();
            this.CloseButton = new System.Windows.Forms.ToolStripButton();
            RutaLabel = new System.Windows.Forms.Label();
            SaveAsGroupBox = new System.Windows.Forms.GroupBox();
            ExtensionLabel = new System.Windows.Forms.Label();
            SaveAsGroupBox.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.DownloadTab.SuspendLayout();
            this.EditTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XMLDataGridView)).BeginInit();
            this.EditGroupBox.SuspendLayout();
            this.LoadFilesGroupBox.SuspendLayout();
            this.ExportTab.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // RutaLabel
            // 
            RutaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            RutaLabel.AutoEllipsis = true;
            RutaLabel.AutoSize = true;
            RutaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            RutaLabel.Location = new System.Drawing.Point(4, 61);
            RutaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            RutaLabel.Name = "RutaLabel";
            RutaLabel.Size = new System.Drawing.Size(83, 17);
            RutaLabel.TabIndex = 2;
            RutaLabel.Text = "Ruta del archivo";
            RutaLabel.UseCompatibleTextRendering = true;
            // 
            // SaveAsGroupBox
            // 
            SaveAsGroupBox.Controls.Add(this.ExportProgressBar);
            SaveAsGroupBox.Controls.Add(ExtensionLabel);
            SaveAsGroupBox.Controls.Add(this.label1);
            SaveAsGroupBox.Controls.Add(this.OutFileNameTextBox);
            SaveAsGroupBox.Controls.Add(this.ExportButton);
            SaveAsGroupBox.Controls.Add(this.FileExtensionComboBox);
            SaveAsGroupBox.Location = new System.Drawing.Point(7, 7);
            SaveAsGroupBox.Name = "SaveAsGroupBox";
            SaveAsGroupBox.Size = new System.Drawing.Size(381, 131);
            SaveAsGroupBox.TabIndex = 0;
            SaveAsGroupBox.TabStop = false;
            SaveAsGroupBox.Text = "Guardar como";
            // 
            // ExportProgressBar
            // 
            this.ExportProgressBar.Location = new System.Drawing.Point(6, 100);
            this.ExportProgressBar.Name = "ExportProgressBar";
            this.ExportProgressBar.Size = new System.Drawing.Size(268, 24);
            this.ExportProgressBar.TabIndex = 10;
            this.ExportProgressBar.Visible = false;
            // 
            // ExtensionLabel
            // 
            ExtensionLabel.AutoSize = true;
            ExtensionLabel.Location = new System.Drawing.Point(72, 74);
            ExtensionLabel.Name = "ExtensionLabel";
            ExtensionLabel.Size = new System.Drawing.Size(110, 17);
            ExtensionLabel.TabIndex = 9;
            ExtensionLabel.Text = "Tipo de archivo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre del archivo";
            // 
            // OutFileNameTextBox
            // 
            this.OutFileNameTextBox.Location = new System.Drawing.Point(6, 43);
            this.OutFileNameTextBox.Name = "OutFileNameTextBox";
            this.OutFileNameTextBox.Size = new System.Drawing.Size(369, 23);
            this.OutFileNameTextBox.TabIndex = 7;
            // 
            // ExportButton
            // 
            this.ExportButton.Enabled = false;
            this.ExportButton.Location = new System.Drawing.Point(280, 100);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(95, 24);
            this.ExportButton.TabIndex = 6;
            this.ExportButton.Text = "Guardar";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // FileExtensionComboBox
            // 
            this.FileExtensionComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.FileExtensionComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.FileExtensionComboBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FileExtensionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FileExtensionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FileExtensionComboBox.FormattingEnabled = true;
            this.FileExtensionComboBox.Items.AddRange(new object[] {
            "Excel",
            "Csv",
            "Texto"});
            this.FileExtensionComboBox.Location = new System.Drawing.Point(186, 71);
            this.FileExtensionComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FileExtensionComboBox.MaxDropDownItems = 2;
            this.FileExtensionComboBox.Name = "FileExtensionComboBox";
            this.FileExtensionComboBox.Size = new System.Drawing.Size(189, 24);
            this.FileExtensionComboBox.TabIndex = 5;
            this.FileExtensionComboBox.SelectedIndexChanged += new System.EventHandler(this.FileExtensionComboBox_SelectedIndexChanged);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.DownloadTab);
            this.MainTabControl.Controls.Add(this.EditTab);
            this.MainTabControl.Controls.Add(this.ExportTab);
            this.MainTabControl.Location = new System.Drawing.Point(8, 8);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(992, 555);
            this.MainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTabControl.TabIndex = 0;
            // 
            // DownloadTab
            // 
            this.DownloadTab.Controls.Add(this.ToolStrip);
            this.DownloadTab.Controls.Add(this.StatusStrip);
            this.DownloadTab.Controls.Add(this.SatWebBrowser);
            this.DownloadTab.Location = new System.Drawing.Point(4, 25);
            this.DownloadTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DownloadTab.Name = "DownloadTab";
            this.DownloadTab.Size = new System.Drawing.Size(984, 526);
            this.DownloadTab.TabIndex = 2;
            this.DownloadTab.Text = "Descargar XML";
            this.DownloadTab.UseVisualStyleBackColor = true;
            // 
            // SatWebBrowser
            // 
            this.SatWebBrowser.Location = new System.Drawing.Point(8, 12);
            this.SatWebBrowser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SatWebBrowser.MinimumSize = new System.Drawing.Size(13, 13);
            this.SatWebBrowser.Name = "SatWebBrowser";
            this.SatWebBrowser.Size = new System.Drawing.Size(853, 490);
            this.SatWebBrowser.TabIndex = 0;
            this.SatWebBrowser.TabStop = false;
            this.SatWebBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // EditTab
            // 
            this.EditTab.Controls.Add(this.LoadDataProgressBar);
            this.EditTab.Controls.Add(this.CleanButton);
            this.EditTab.Controls.Add(this.XMLDataGridView);
            this.EditTab.Controls.Add(this.EditGroupBox);
            this.EditTab.Controls.Add(this.LoadFilesGroupBox);
            this.EditTab.Location = new System.Drawing.Point(4, 25);
            this.EditTab.Name = "EditTab";
            this.EditTab.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.EditTab.Size = new System.Drawing.Size(984, 526);
            this.EditTab.TabIndex = 0;
            this.EditTab.Text = "Editar";
            this.EditTab.UseVisualStyleBackColor = true;
            // 
            // LoadDataProgressBar
            // 
            this.LoadDataProgressBar.Location = new System.Drawing.Point(666, 503);
            this.LoadDataProgressBar.Name = "LoadDataProgressBar";
            this.LoadDataProgressBar.Size = new System.Drawing.Size(315, 15);
            this.LoadDataProgressBar.TabIndex = 6;
            this.LoadDataProgressBar.Visible = false;
            // 
            // CleanButton
            // 
            this.CleanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.CleanButton.Location = new System.Drawing.Point(100, 477);
            this.CleanButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CleanButton.Name = "CleanButton";
            this.CleanButton.Size = new System.Drawing.Size(101, 21);
            this.CleanButton.TabIndex = 5;
            this.CleanButton.Text = "Limpiar tabla";
            this.CleanButton.UseVisualStyleBackColor = true;
            this.CleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // XMLDataGridView
            // 
            this.XMLDataGridView.AllowUserToAddRows = false;
            this.XMLDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XMLDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.XMLDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.XMLDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.XMLDataGridView.Location = new System.Drawing.Point(205, 5);
            this.XMLDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.XMLDataGridView.Name = "XMLDataGridView";
            this.XMLDataGridView.ReadOnly = true;
            this.XMLDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.XMLDataGridView.RowHeadersWidth = 62;
            this.XMLDataGridView.RowTemplate.Height = 28;
            this.XMLDataGridView.Size = new System.Drawing.Size(774, 493);
            this.XMLDataGridView.TabIndex = 4;
            // 
            // EditGroupBox
            // 
            this.EditGroupBox.Controls.Add(this.ColumnasCheckedListBox);
            this.EditGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EditGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.EditGroupBox.Location = new System.Drawing.Point(5, 217);
            this.EditGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EditGroupBox.Name = "EditGroupBox";
            this.EditGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EditGroupBox.Size = new System.Drawing.Size(196, 245);
            this.EditGroupBox.TabIndex = 3;
            this.EditGroupBox.TabStop = false;
            this.EditGroupBox.Text = "Editar columnas";
            // 
            // ColumnasCheckedListBox
            // 
            this.ColumnasCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ColumnasCheckedListBox.CheckOnClick = true;
            this.ColumnasCheckedListBox.FormattingEnabled = true;
            this.ColumnasCheckedListBox.Location = new System.Drawing.Point(4, 20);
            this.ColumnasCheckedListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ColumnasCheckedListBox.Name = "ColumnasCheckedListBox";
            this.ColumnasCheckedListBox.Size = new System.Drawing.Size(185, 216);
            this.ColumnasCheckedListBox.Sorted = true;
            this.ColumnasCheckedListBox.TabIndex = 0;
            this.ColumnasCheckedListBox.ThreeDCheckBoxes = true;
            this.ColumnasCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.ColumnasCheckedListBox_SelectedIndexChanged);
            // 
            // LoadFilesGroupBox
            // 
            this.LoadFilesGroupBox.Controls.Add(this.TypeOfFileComboBox);
            this.LoadFilesGroupBox.Controls.Add(this.RutaSpan);
            this.LoadFilesGroupBox.Controls.Add(RutaLabel);
            this.LoadFilesGroupBox.Controls.Add(this.AddButton);
            this.LoadFilesGroupBox.Controls.Add(this.OpenFileButton);
            this.LoadFilesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadFilesGroupBox.Location = new System.Drawing.Point(5, 5);
            this.LoadFilesGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadFilesGroupBox.Name = "LoadFilesGroupBox";
            this.LoadFilesGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadFilesGroupBox.Size = new System.Drawing.Size(196, 208);
            this.LoadFilesGroupBox.TabIndex = 1;
            this.LoadFilesGroupBox.TabStop = false;
            this.LoadFilesGroupBox.Tag = "";
            this.LoadFilesGroupBox.Text = "Cargar archivos";
            // 
            // TypeOfFileComboBox
            // 
            this.TypeOfFileComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TypeOfFileComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TypeOfFileComboBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TypeOfFileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeOfFileComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TypeOfFileComboBox.FormattingEnabled = true;
            this.TypeOfFileComboBox.Items.AddRange(new object[] {
            "Por archivo",
            "Por carpeta",
            "Carpeta comprimida (zip)"});
            this.TypeOfFileComboBox.Location = new System.Drawing.Point(4, 19);
            this.TypeOfFileComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TypeOfFileComboBox.MaxDropDownItems = 3;
            this.TypeOfFileComboBox.Name = "TypeOfFileComboBox";
            this.TypeOfFileComboBox.Size = new System.Drawing.Size(189, 24);
            this.TypeOfFileComboBox.TabIndex = 4;
            this.TypeOfFileComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeOfFileComboBox_SelectedIndexChanged);
            // 
            // RutaSpan
            // 
            this.RutaSpan.AutoWordSelection = true;
            this.RutaSpan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RutaSpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.RutaSpan.Location = new System.Drawing.Point(4, 79);
            this.RutaSpan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RutaSpan.Name = "RutaSpan";
            this.RutaSpan.ReadOnly = true;
            this.RutaSpan.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RutaSpan.Size = new System.Drawing.Size(188, 100);
            this.RutaSpan.TabIndex = 3;
            this.RutaSpan.Text = "";
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.AddButton.Location = new System.Drawing.Point(91, 183);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(101, 21);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Añadir";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.OpenFileButton.Location = new System.Drawing.Point(91, 51);
            this.OpenFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(101, 23);
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.Text = "Examinar";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // ExportTab
            // 
            this.ExportTab.BackColor = System.Drawing.Color.White;
            this.ExportTab.Controls.Add(SaveAsGroupBox);
            this.ExportTab.Location = new System.Drawing.Point(4, 25);
            this.ExportTab.Name = "ExportTab";
            this.ExportTab.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.ExportTab.Size = new System.Drawing.Size(984, 526);
            this.ExportTab.TabIndex = 1;
            this.ExportTab.Text = "Exportar";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 504);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(984, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "Carga";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(135, 17);
            this.StatusLabel.Text = "Descripción de la acción";
            // 
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HomeButton,
            this.DownloadButton,
            this.CloseButton});
            this.ToolStrip.Location = new System.Drawing.Point(863, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip.Size = new System.Drawing.Size(121, 504);
            this.ToolStrip.TabIndex = 2;
            this.ToolStrip.Text = "Barra de Herramientas";
            // 
            // HomeButton
            // 
            this.HomeButton.AutoSize = false;
            this.HomeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.Image = global::XMLFileAdministrator.Properties.Resources.home;
            this.HomeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HomeButton.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(105, 80);
            this.HomeButton.Text = "Inicio";
            this.HomeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.HomeButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.HomeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.HomeButton.ToolTipText = "Regresar a inicio";
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.AutoSize = false;
            this.DownloadButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadButton.Image = global::XMLFileAdministrator.Properties.Resources.download;
            this.DownloadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DownloadButton.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(105, 80);
            this.DownloadButton.Text = "Descargar";
            this.DownloadButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DownloadButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DownloadButton.ToolTipText = "Descargar archivos";
            this.DownloadButton.Visible = false;
            // 
            // CloseButton
            // 
            this.CloseButton.AutoSize = false;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.Image = global::XMLFileAdministrator.Properties.Resources.close;
            this.CloseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(105, 80);
            this.CloseButton.Text = "Cerrar sesión";
            this.CloseButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.CloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CloseButton.Visible = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1008, 576);
            this.Controls.Add(this.MainTabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1024, 615);
            this.MinimumSize = new System.Drawing.Size(1024, 615);
            this.Name = "Inicio";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XMLFileConverter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inicio_FormClosing);
            SaveAsGroupBox.ResumeLayout(false);
            SaveAsGroupBox.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.DownloadTab.ResumeLayout(false);
            this.DownloadTab.PerformLayout();
            this.EditTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XMLDataGridView)).EndInit();
            this.EditGroupBox.ResumeLayout(false);
            this.LoadFilesGroupBox.ResumeLayout(false);
            this.LoadFilesGroupBox.PerformLayout();
            this.ExportTab.ResumeLayout(false);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage EditTab;
        private System.Windows.Forms.TabPage ExportTab;
        private System.Windows.Forms.ProgressBar LoadDataProgressBar;
        private System.Windows.Forms.Button CleanButton;
        private System.Windows.Forms.DataGridView XMLDataGridView;
        private System.Windows.Forms.GroupBox EditGroupBox;
        private System.Windows.Forms.CheckedListBox ColumnasCheckedListBox;
        private System.Windows.Forms.GroupBox LoadFilesGroupBox;
        private System.Windows.Forms.ComboBox TypeOfFileComboBox;
        private System.Windows.Forms.RichTextBox RutaSpan;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OutFileNameTextBox;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.ComboBox FileExtensionComboBox;
        private System.Windows.Forms.ProgressBar ExportProgressBar;
        private System.Windows.Forms.TabPage DownloadTab;
        private System.Windows.Forms.WebBrowser SatWebBrowser;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton HomeButton;
        private System.Windows.Forms.ToolStripButton DownloadButton;
        private System.Windows.Forms.ToolStripButton CloseButton;
    }
}

