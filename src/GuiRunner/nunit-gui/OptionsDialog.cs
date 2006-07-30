#region Copyright (c) 2002-2003, James W. Newkirk, Michael C. Two, Alexei A. Vorontsov, Charlie Poole, Philip A. Craig
/************************************************************************************
'
' Copyright  2002-2003 James W. Newkirk, Michael C. Two, Alexei A. Vorontsov, Charlie Poole
' Copyright  2000-2002 Philip A. Craig
'
' This software is provided 'as-is', without any express or implied warranty. In no 
' event will the authors be held liable for any damages arising from the use of this 
' software.
' 
' Permission is granted to anyone to use this software for any purpose, including 
' commercial applications, and to alter it and redistribute it freely, subject to the 
' following restrictions:
'
' 1. The origin of this software must not be misrepresented; you must not claim that 
' you wrote the original software. If you use this software in a product, an 
' acknowledgment (see the following) in the product documentation is required.
'
' Portions Copyright  2002-2003 James W. Newkirk, Michael C. Two, Alexei A. Vorontsov, Charlie Poole
' or Copyright  2000-2002 Philip A. Craig
'
' 2. Altered source versions must be plainly marked as such, and must not be 
' misrepresented as being the original software.
'
' 3. This notice may not be removed or altered from any source distribution.
'
'***********************************************************************************/
#endregion

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using NUnit.Util;
using NUnit.UiKit;

namespace NUnit.Gui
{
	/// <summary>
	/// Summary description for OptionsDialog.
	/// </summary>
	public class OptionsDialog : System.Windows.Forms.Form
	{
		private OptionSettings options;

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.HelpProvider helpProvider1;
		private System.Windows.Forms.CheckBox clearResultsCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox initialDisplayComboBox;
		private System.Windows.Forms.CheckBox reloadOnChangeCheckBox;
		private System.Windows.Forms.CheckBox reloadOnRunCheckBox;
		private System.Windows.Forms.CheckBox visualStudioSupportCheckBox;
		private System.Windows.Forms.CheckBox loadLastProjectCheckBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox recentFilesCountTextBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox labelTestOutputCheckBox;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.CheckBox failureToolTips;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.RadioButton multiDomainRadioButton;
		private System.Windows.Forms.RadioButton singleDomainRadioButton;
		private System.Windows.Forms.CheckBox mergeAssembliesCheckBox;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.RadioButton autoNamespaceSuites;
		private System.Windows.Forms.RadioButton flatTestList;
		private System.Windows.Forms.CheckBox rerunOnChangeCheckBox;
		private System.Windows.Forms.CheckBox enableWordWrap;

		private UserSettings _userSettings;
		private UserSettings UserSettings
		{
			get
			{
				if ( _userSettings == null )
					_userSettings = (UserSettings)GetService( typeof( UserSettings ) );
				return _userSettings;
			}
		}

		public OptionsDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OptionsDialog));
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.loadLastProjectCheckBox = new System.Windows.Forms.CheckBox();
			this.clearResultsCheckBox = new System.Windows.Forms.CheckBox();
			this.reloadOnChangeCheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.initialDisplayComboBox = new System.Windows.Forms.ComboBox();
			this.reloadOnRunCheckBox = new System.Windows.Forms.CheckBox();
			this.visualStudioSupportCheckBox = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.recentFilesCountTextBox = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rerunOnChangeCheckBox = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.failureToolTips = new System.Windows.Forms.CheckBox();
			this.labelTestOutputCheckBox = new System.Windows.Forms.CheckBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.flatTestList = new System.Windows.Forms.RadioButton();
			this.autoNamespaceSuites = new System.Windows.Forms.RadioButton();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.mergeAssembliesCheckBox = new System.Windows.Forms.CheckBox();
			this.singleDomainRadioButton = new System.Windows.Forms.RadioButton();
			this.multiDomainRadioButton = new System.Windows.Forms.RadioButton();
			this.enableWordWrap = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.AccessibleDescription = resources.GetString("okButton.AccessibleDescription");
			this.okButton.AccessibleName = resources.GetString("okButton.AccessibleName");
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("okButton.Anchor")));
			this.okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okButton.BackgroundImage")));
			this.okButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("okButton.Dock")));
			this.okButton.Enabled = ((bool)(resources.GetObject("okButton.Enabled")));
			this.okButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("okButton.FlatStyle")));
			this.okButton.Font = ((System.Drawing.Font)(resources.GetObject("okButton.Font")));
			this.helpProvider1.SetHelpKeyword(this.okButton, resources.GetString("okButton.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.okButton, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("okButton.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.okButton, resources.GetString("okButton.HelpString"));
			this.okButton.Image = ((System.Drawing.Image)(resources.GetObject("okButton.Image")));
			this.okButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("okButton.ImageAlign")));
			this.okButton.ImageIndex = ((int)(resources.GetObject("okButton.ImageIndex")));
			this.okButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("okButton.ImeMode")));
			this.okButton.Location = ((System.Drawing.Point)(resources.GetObject("okButton.Location")));
			this.okButton.Name = "okButton";
			this.okButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("okButton.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.okButton, ((bool)(resources.GetObject("okButton.ShowHelp"))));
			this.okButton.Size = ((System.Drawing.Size)(resources.GetObject("okButton.Size")));
			this.okButton.TabIndex = ((int)(resources.GetObject("okButton.TabIndex")));
			this.okButton.Text = resources.GetString("okButton.Text");
			this.okButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("okButton.TextAlign")));
			this.okButton.Visible = ((bool)(resources.GetObject("okButton.Visible")));
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.AccessibleDescription = resources.GetString("cancelButton.AccessibleDescription");
			this.cancelButton.AccessibleName = resources.GetString("cancelButton.AccessibleName");
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cancelButton.Anchor")));
			this.cancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelButton.BackgroundImage")));
			this.cancelButton.CausesValidation = false;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cancelButton.Dock")));
			this.cancelButton.Enabled = ((bool)(resources.GetObject("cancelButton.Enabled")));
			this.cancelButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cancelButton.FlatStyle")));
			this.cancelButton.Font = ((System.Drawing.Font)(resources.GetObject("cancelButton.Font")));
			this.helpProvider1.SetHelpKeyword(this.cancelButton, resources.GetString("cancelButton.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.cancelButton, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("cancelButton.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.cancelButton, resources.GetString("cancelButton.HelpString"));
			this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
			this.cancelButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cancelButton.ImageAlign")));
			this.cancelButton.ImageIndex = ((int)(resources.GetObject("cancelButton.ImageIndex")));
			this.cancelButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cancelButton.ImeMode")));
			this.cancelButton.Location = ((System.Drawing.Point)(resources.GetObject("cancelButton.Location")));
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cancelButton.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.cancelButton, ((bool)(resources.GetObject("cancelButton.ShowHelp"))));
			this.cancelButton.Size = ((System.Drawing.Size)(resources.GetObject("cancelButton.Size")));
			this.cancelButton.TabIndex = ((int)(resources.GetObject("cancelButton.TabIndex")));
			this.cancelButton.Text = resources.GetString("cancelButton.Text");
			this.cancelButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cancelButton.TextAlign")));
			this.cancelButton.Visible = ((bool)(resources.GetObject("cancelButton.Visible")));
			// 
			// helpProvider1
			// 
			this.helpProvider1.HelpNamespace = resources.GetString("helpProvider1.HelpNamespace");
			// 
			// loadLastProjectCheckBox
			// 
			this.loadLastProjectCheckBox.AccessibleDescription = resources.GetString("loadLastProjectCheckBox.AccessibleDescription");
			this.loadLastProjectCheckBox.AccessibleName = resources.GetString("loadLastProjectCheckBox.AccessibleName");
			this.loadLastProjectCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("loadLastProjectCheckBox.Anchor")));
			this.loadLastProjectCheckBox.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("loadLastProjectCheckBox.Appearance")));
			this.loadLastProjectCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadLastProjectCheckBox.BackgroundImage")));
			this.loadLastProjectCheckBox.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("loadLastProjectCheckBox.CheckAlign")));
			this.loadLastProjectCheckBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("loadLastProjectCheckBox.Dock")));
			this.loadLastProjectCheckBox.Enabled = ((bool)(resources.GetObject("loadLastProjectCheckBox.Enabled")));
			this.loadLastProjectCheckBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("loadLastProjectCheckBox.FlatStyle")));
			this.loadLastProjectCheckBox.Font = ((System.Drawing.Font)(resources.GetObject("loadLastProjectCheckBox.Font")));
			this.helpProvider1.SetHelpKeyword(this.loadLastProjectCheckBox, resources.GetString("loadLastProjectCheckBox.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.loadLastProjectCheckBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("loadLastProjectCheckBox.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.loadLastProjectCheckBox, resources.GetString("loadLastProjectCheckBox.HelpString"));
			this.loadLastProjectCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("loadLastProjectCheckBox.Image")));
			this.loadLastProjectCheckBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("loadLastProjectCheckBox.ImageAlign")));
			this.loadLastProjectCheckBox.ImageIndex = ((int)(resources.GetObject("loadLastProjectCheckBox.ImageIndex")));
			this.loadLastProjectCheckBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("loadLastProjectCheckBox.ImeMode")));
			this.loadLastProjectCheckBox.Location = ((System.Drawing.Point)(resources.GetObject("loadLastProjectCheckBox.Location")));
			this.loadLastProjectCheckBox.Name = "loadLastProjectCheckBox";
			this.loadLastProjectCheckBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("loadLastProjectCheckBox.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.loadLastProjectCheckBox, ((bool)(resources.GetObject("loadLastProjectCheckBox.ShowHelp"))));
			this.loadLastProjectCheckBox.Size = ((System.Drawing.Size)(resources.GetObject("loadLastProjectCheckBox.Size")));
			this.loadLastProjectCheckBox.TabIndex = ((int)(resources.GetObject("loadLastProjectCheckBox.TabIndex")));
			this.loadLastProjectCheckBox.Text = resources.GetString("loadLastProjectCheckBox.Text");
			this.loadLastProjectCheckBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("loadLastProjectCheckBox.TextAlign")));
			this.loadLastProjectCheckBox.Visible = ((bool)(resources.GetObject("loadLastProjectCheckBox.Visible")));
			// 
			// clearResultsCheckBox
			// 
			this.clearResultsCheckBox.AccessibleDescription = resources.GetString("clearResultsCheckBox.AccessibleDescription");
			this.clearResultsCheckBox.AccessibleName = resources.GetString("clearResultsCheckBox.AccessibleName");
			this.clearResultsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("clearResultsCheckBox.Anchor")));
			this.clearResultsCheckBox.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("clearResultsCheckBox.Appearance")));
			this.clearResultsCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("clearResultsCheckBox.BackgroundImage")));
			this.clearResultsCheckBox.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("clearResultsCheckBox.CheckAlign")));
			this.clearResultsCheckBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("clearResultsCheckBox.Dock")));
			this.clearResultsCheckBox.Enabled = ((bool)(resources.GetObject("clearResultsCheckBox.Enabled")));
			this.clearResultsCheckBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("clearResultsCheckBox.FlatStyle")));
			this.clearResultsCheckBox.Font = ((System.Drawing.Font)(resources.GetObject("clearResultsCheckBox.Font")));
			this.helpProvider1.SetHelpKeyword(this.clearResultsCheckBox, resources.GetString("clearResultsCheckBox.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.clearResultsCheckBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("clearResultsCheckBox.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.clearResultsCheckBox, resources.GetString("clearResultsCheckBox.HelpString"));
			this.clearResultsCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("clearResultsCheckBox.Image")));
			this.clearResultsCheckBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("clearResultsCheckBox.ImageAlign")));
			this.clearResultsCheckBox.ImageIndex = ((int)(resources.GetObject("clearResultsCheckBox.ImageIndex")));
			this.clearResultsCheckBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("clearResultsCheckBox.ImeMode")));
			this.clearResultsCheckBox.Location = ((System.Drawing.Point)(resources.GetObject("clearResultsCheckBox.Location")));
			this.clearResultsCheckBox.Name = "clearResultsCheckBox";
			this.clearResultsCheckBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("clearResultsCheckBox.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.clearResultsCheckBox, ((bool)(resources.GetObject("clearResultsCheckBox.ShowHelp"))));
			this.clearResultsCheckBox.Size = ((System.Drawing.Size)(resources.GetObject("clearResultsCheckBox.Size")));
			this.clearResultsCheckBox.TabIndex = ((int)(resources.GetObject("clearResultsCheckBox.TabIndex")));
			this.clearResultsCheckBox.Text = resources.GetString("clearResultsCheckBox.Text");
			this.clearResultsCheckBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("clearResultsCheckBox.TextAlign")));
			this.clearResultsCheckBox.Visible = ((bool)(resources.GetObject("clearResultsCheckBox.Visible")));
			// 
			// reloadOnChangeCheckBox
			// 
			this.reloadOnChangeCheckBox.AccessibleDescription = resources.GetString("reloadOnChangeCheckBox.AccessibleDescription");
			this.reloadOnChangeCheckBox.AccessibleName = resources.GetString("reloadOnChangeCheckBox.AccessibleName");
			this.reloadOnChangeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("reloadOnChangeCheckBox.Anchor")));
			this.reloadOnChangeCheckBox.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("reloadOnChangeCheckBox.Appearance")));
			this.reloadOnChangeCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reloadOnChangeCheckBox.BackgroundImage")));
			this.reloadOnChangeCheckBox.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("reloadOnChangeCheckBox.CheckAlign")));
			this.reloadOnChangeCheckBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("reloadOnChangeCheckBox.Dock")));
			this.reloadOnChangeCheckBox.Enabled = ((bool)(resources.GetObject("reloadOnChangeCheckBox.Enabled")));
			this.reloadOnChangeCheckBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("reloadOnChangeCheckBox.FlatStyle")));
			this.reloadOnChangeCheckBox.Font = ((System.Drawing.Font)(resources.GetObject("reloadOnChangeCheckBox.Font")));
			this.helpProvider1.SetHelpKeyword(this.reloadOnChangeCheckBox, resources.GetString("reloadOnChangeCheckBox.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.reloadOnChangeCheckBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("reloadOnChangeCheckBox.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.reloadOnChangeCheckBox, resources.GetString("reloadOnChangeCheckBox.HelpString"));
			this.reloadOnChangeCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("reloadOnChangeCheckBox.Image")));
			this.reloadOnChangeCheckBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("reloadOnChangeCheckBox.ImageAlign")));
			this.reloadOnChangeCheckBox.ImageIndex = ((int)(resources.GetObject("reloadOnChangeCheckBox.ImageIndex")));
			this.reloadOnChangeCheckBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("reloadOnChangeCheckBox.ImeMode")));
			this.reloadOnChangeCheckBox.Location = ((System.Drawing.Point)(resources.GetObject("reloadOnChangeCheckBox.Location")));
			this.reloadOnChangeCheckBox.Name = "reloadOnChangeCheckBox";
			this.reloadOnChangeCheckBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("reloadOnChangeCheckBox.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.reloadOnChangeCheckBox, ((bool)(resources.GetObject("reloadOnChangeCheckBox.ShowHelp"))));
			this.reloadOnChangeCheckBox.Size = ((System.Drawing.Size)(resources.GetObject("reloadOnChangeCheckBox.Size")));
			this.reloadOnChangeCheckBox.TabIndex = ((int)(resources.GetObject("reloadOnChangeCheckBox.TabIndex")));
			this.reloadOnChangeCheckBox.Text = resources.GetString("reloadOnChangeCheckBox.Text");
			this.reloadOnChangeCheckBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("reloadOnChangeCheckBox.TextAlign")));
			this.reloadOnChangeCheckBox.Visible = ((bool)(resources.GetObject("reloadOnChangeCheckBox.Visible")));
			this.reloadOnChangeCheckBox.CheckedChanged += new System.EventHandler(this.reloadOnChangeCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
			this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
			this.helpProvider1.SetHelpKeyword(this.label1, resources.GetString("label1.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.label1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label1.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.label1, resources.GetString("label1.HelpString"));
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
			// 
			// initialDisplayComboBox
			// 
			this.initialDisplayComboBox.AccessibleDescription = resources.GetString("initialDisplayComboBox.AccessibleDescription");
			this.initialDisplayComboBox.AccessibleName = resources.GetString("initialDisplayComboBox.AccessibleName");
			this.initialDisplayComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("initialDisplayComboBox.Anchor")));
			this.initialDisplayComboBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("initialDisplayComboBox.BackgroundImage")));
			this.initialDisplayComboBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("initialDisplayComboBox.Dock")));
			this.initialDisplayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.initialDisplayComboBox.Enabled = ((bool)(resources.GetObject("initialDisplayComboBox.Enabled")));
			this.initialDisplayComboBox.Font = ((System.Drawing.Font)(resources.GetObject("initialDisplayComboBox.Font")));
			this.helpProvider1.SetHelpKeyword(this.initialDisplayComboBox, resources.GetString("initialDisplayComboBox.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.initialDisplayComboBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("initialDisplayComboBox.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.initialDisplayComboBox, resources.GetString("initialDisplayComboBox.HelpString"));
			this.initialDisplayComboBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("initialDisplayComboBox.ImeMode")));
			this.initialDisplayComboBox.IntegralHeight = ((bool)(resources.GetObject("initialDisplayComboBox.IntegralHeight")));
			this.initialDisplayComboBox.ItemHeight = ((int)(resources.GetObject("initialDisplayComboBox.ItemHeight")));
			this.initialDisplayComboBox.Items.AddRange(new object[] {
																		resources.GetString("initialDisplayComboBox.Items"),
																		resources.GetString("initialDisplayComboBox.Items1"),
																		resources.GetString("initialDisplayComboBox.Items2"),
																		resources.GetString("initialDisplayComboBox.Items3")});
			this.initialDisplayComboBox.Location = ((System.Drawing.Point)(resources.GetObject("initialDisplayComboBox.Location")));
			this.initialDisplayComboBox.MaxDropDownItems = ((int)(resources.GetObject("initialDisplayComboBox.MaxDropDownItems")));
			this.initialDisplayComboBox.MaxLength = ((int)(resources.GetObject("initialDisplayComboBox.MaxLength")));
			this.initialDisplayComboBox.Name = "initialDisplayComboBox";
			this.initialDisplayComboBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("initialDisplayComboBox.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.initialDisplayComboBox, ((bool)(resources.GetObject("initialDisplayComboBox.ShowHelp"))));
			this.initialDisplayComboBox.Size = ((System.Drawing.Size)(resources.GetObject("initialDisplayComboBox.Size")));
			this.initialDisplayComboBox.TabIndex = ((int)(resources.GetObject("initialDisplayComboBox.TabIndex")));
			this.initialDisplayComboBox.Text = resources.GetString("initialDisplayComboBox.Text");
			this.initialDisplayComboBox.Visible = ((bool)(resources.GetObject("initialDisplayComboBox.Visible")));
			// 
			// reloadOnRunCheckBox
			// 
			this.reloadOnRunCheckBox.AccessibleDescription = resources.GetString("reloadOnRunCheckBox.AccessibleDescription");
			this.reloadOnRunCheckBox.AccessibleName = resources.GetString("reloadOnRunCheckBox.AccessibleName");
			this.reloadOnRunCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("reloadOnRunCheckBox.Anchor")));
			this.reloadOnRunCheckBox.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("reloadOnRunCheckBox.Appearance")));
			this.reloadOnRunCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reloadOnRunCheckBox.BackgroundImage")));
			this.reloadOnRunCheckBox.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("reloadOnRunCheckBox.CheckAlign")));
			this.reloadOnRunCheckBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("reloadOnRunCheckBox.Dock")));
			this.reloadOnRunCheckBox.Enabled = ((bool)(resources.GetObject("reloadOnRunCheckBox.Enabled")));
			this.reloadOnRunCheckBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("reloadOnRunCheckBox.FlatStyle")));
			this.reloadOnRunCheckBox.Font = ((System.Drawing.Font)(resources.GetObject("reloadOnRunCheckBox.Font")));
			this.helpProvider1.SetHelpKeyword(this.reloadOnRunCheckBox, resources.GetString("reloadOnRunCheckBox.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.reloadOnRunCheckBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("reloadOnRunCheckBox.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.reloadOnRunCheckBox, resources.GetString("reloadOnRunCheckBox.HelpString"));
			this.reloadOnRunCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("reloadOnRunCheckBox.Image")));
			this.reloadOnRunCheckBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("reloadOnRunCheckBox.ImageAlign")));
			this.reloadOnRunCheckBox.ImageIndex = ((int)(resources.GetObject("reloadOnRunCheckBox.ImageIndex")));
			this.reloadOnRunCheckBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("reloadOnRunCheckBox.ImeMode")));
			this.reloadOnRunCheckBox.Location = ((System.Drawing.Point)(resources.GetObject("reloadOnRunCheckBox.Location")));
			this.reloadOnRunCheckBox.Name = "reloadOnRunCheckBox";
			this.reloadOnRunCheckBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("reloadOnRunCheckBox.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.reloadOnRunCheckBox, ((bool)(resources.GetObject("reloadOnRunCheckBox.ShowHelp"))));
			this.reloadOnRunCheckBox.Size = ((System.Drawing.Size)(resources.GetObject("reloadOnRunCheckBox.Size")));
			this.reloadOnRunCheckBox.TabIndex = ((int)(resources.GetObject("reloadOnRunCheckBox.TabIndex")));
			this.reloadOnRunCheckBox.Text = resources.GetString("reloadOnRunCheckBox.Text");
			this.reloadOnRunCheckBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("reloadOnRunCheckBox.TextAlign")));
			this.reloadOnRunCheckBox.Visible = ((bool)(resources.GetObject("reloadOnRunCheckBox.Visible")));
			// 
			// visualStudioSupportCheckBox
			// 
			this.visualStudioSupportCheckBox.AccessibleDescription = resources.GetString("visualStudioSupportCheckBox.AccessibleDescription");
			this.visualStudioSupportCheckBox.AccessibleName = resources.GetString("visualStudioSupportCheckBox.AccessibleName");
			this.visualStudioSupportCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("visualStudioSupportCheckBox.Anchor")));
			this.visualStudioSupportCheckBox.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("visualStudioSupportCheckBox.Appearance")));
			this.visualStudioSupportCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("visualStudioSupportCheckBox.BackgroundImage")));
			this.visualStudioSupportCheckBox.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("visualStudioSupportCheckBox.CheckAlign")));
			this.visualStudioSupportCheckBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("visualStudioSupportCheckBox.Dock")));
			this.visualStudioSupportCheckBox.Enabled = ((bool)(resources.GetObject("visualStudioSupportCheckBox.Enabled")));
			this.visualStudioSupportCheckBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("visualStudioSupportCheckBox.FlatStyle")));
			this.visualStudioSupportCheckBox.Font = ((System.Drawing.Font)(resources.GetObject("visualStudioSupportCheckBox.Font")));
			this.helpProvider1.SetHelpKeyword(this.visualStudioSupportCheckBox, resources.GetString("visualStudioSupportCheckBox.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.visualStudioSupportCheckBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("visualStudioSupportCheckBox.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.visualStudioSupportCheckBox, resources.GetString("visualStudioSupportCheckBox.HelpString"));
			this.visualStudioSupportCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("visualStudioSupportCheckBox.Image")));
			this.visualStudioSupportCheckBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("visualStudioSupportCheckBox.ImageAlign")));
			this.visualStudioSupportCheckBox.ImageIndex = ((int)(resources.GetObject("visualStudioSupportCheckBox.ImageIndex")));
			this.visualStudioSupportCheckBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("visualStudioSupportCheckBox.ImeMode")));
			this.visualStudioSupportCheckBox.Location = ((System.Drawing.Point)(resources.GetObject("visualStudioSupportCheckBox.Location")));
			this.visualStudioSupportCheckBox.Name = "visualStudioSupportCheckBox";
			this.visualStudioSupportCheckBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("visualStudioSupportCheckBox.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.visualStudioSupportCheckBox, ((bool)(resources.GetObject("visualStudioSupportCheckBox.ShowHelp"))));
			this.visualStudioSupportCheckBox.Size = ((System.Drawing.Size)(resources.GetObject("visualStudioSupportCheckBox.Size")));
			this.visualStudioSupportCheckBox.TabIndex = ((int)(resources.GetObject("visualStudioSupportCheckBox.TabIndex")));
			this.visualStudioSupportCheckBox.Text = resources.GetString("visualStudioSupportCheckBox.Text");
			this.visualStudioSupportCheckBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("visualStudioSupportCheckBox.TextAlign")));
			this.visualStudioSupportCheckBox.Visible = ((bool)(resources.GetObject("visualStudioSupportCheckBox.Visible")));
			// 
			// label2
			// 
			this.label2.AccessibleDescription = resources.GetString("label2.AccessibleDescription");
			this.label2.AccessibleName = resources.GetString("label2.AccessibleName");
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
			this.label2.Font = ((System.Drawing.Font)(resources.GetObject("label2.Font")));
			this.helpProvider1.SetHelpKeyword(this.label2, resources.GetString("label2.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.label2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label2.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.label2, resources.GetString("label2.HelpString"));
			this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
			this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
			this.label2.Visible = ((bool)(resources.GetObject("label2.Visible")));
			// 
			// label3
			// 
			this.label3.AccessibleDescription = resources.GetString("label3.AccessibleDescription");
			this.label3.AccessibleName = resources.GetString("label3.AccessibleName");
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label3.Anchor")));
			this.label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
			this.label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label3.Dock")));
			this.label3.Enabled = ((bool)(resources.GetObject("label3.Enabled")));
			this.label3.Font = ((System.Drawing.Font)(resources.GetObject("label3.Font")));
			this.helpProvider1.SetHelpKeyword(this.label3, resources.GetString("label3.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.label3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label3.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.label3, resources.GetString("label3.HelpString"));
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.ImageAlign")));
			this.label3.ImageIndex = ((int)(resources.GetObject("label3.ImageIndex")));
			this.label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label3.ImeMode")));
			this.label3.Location = ((System.Drawing.Point)(resources.GetObject("label3.Location")));
			this.label3.Name = "label3";
			this.label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label3.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
			this.label3.Size = ((System.Drawing.Size)(resources.GetObject("label3.Size")));
			this.label3.TabIndex = ((int)(resources.GetObject("label3.TabIndex")));
			this.label3.Text = resources.GetString("label3.Text");
			this.label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.TextAlign")));
			this.label3.Visible = ((bool)(resources.GetObject("label3.Visible")));
			// 
			// recentFilesCountTextBox
			// 
			this.recentFilesCountTextBox.AccessibleDescription = resources.GetString("recentFilesCountTextBox.AccessibleDescription");
			this.recentFilesCountTextBox.AccessibleName = resources.GetString("recentFilesCountTextBox.AccessibleName");
			this.recentFilesCountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("recentFilesCountTextBox.Anchor")));
			this.recentFilesCountTextBox.AutoSize = ((bool)(resources.GetObject("recentFilesCountTextBox.AutoSize")));
			this.recentFilesCountTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("recentFilesCountTextBox.BackgroundImage")));
			this.recentFilesCountTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("recentFilesCountTextBox.Dock")));
			this.recentFilesCountTextBox.Enabled = ((bool)(resources.GetObject("recentFilesCountTextBox.Enabled")));
			this.recentFilesCountTextBox.Font = ((System.Drawing.Font)(resources.GetObject("recentFilesCountTextBox.Font")));
			this.helpProvider1.SetHelpKeyword(this.recentFilesCountTextBox, resources.GetString("recentFilesCountTextBox.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.recentFilesCountTextBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("recentFilesCountTextBox.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.recentFilesCountTextBox, resources.GetString("recentFilesCountTextBox.HelpString"));
			this.recentFilesCountTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("recentFilesCountTextBox.ImeMode")));
			this.recentFilesCountTextBox.Location = ((System.Drawing.Point)(resources.GetObject("recentFilesCountTextBox.Location")));
			this.recentFilesCountTextBox.MaxLength = ((int)(resources.GetObject("recentFilesCountTextBox.MaxLength")));
			this.recentFilesCountTextBox.Multiline = ((bool)(resources.GetObject("recentFilesCountTextBox.Multiline")));
			this.recentFilesCountTextBox.Name = "recentFilesCountTextBox";
			this.recentFilesCountTextBox.PasswordChar = ((char)(resources.GetObject("recentFilesCountTextBox.PasswordChar")));
			this.recentFilesCountTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("recentFilesCountTextBox.RightToLeft")));
			this.recentFilesCountTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("recentFilesCountTextBox.ScrollBars")));
			this.helpProvider1.SetShowHelp(this.recentFilesCountTextBox, ((bool)(resources.GetObject("recentFilesCountTextBox.ShowHelp"))));
			this.recentFilesCountTextBox.Size = ((System.Drawing.Size)(resources.GetObject("recentFilesCountTextBox.Size")));
			this.recentFilesCountTextBox.TabIndex = ((int)(resources.GetObject("recentFilesCountTextBox.TabIndex")));
			this.recentFilesCountTextBox.Text = resources.GetString("recentFilesCountTextBox.Text");
			this.recentFilesCountTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("recentFilesCountTextBox.TextAlign")));
			this.recentFilesCountTextBox.Visible = ((bool)(resources.GetObject("recentFilesCountTextBox.Visible")));
			this.recentFilesCountTextBox.WordWrap = ((bool)(resources.GetObject("recentFilesCountTextBox.WordWrap")));
			this.recentFilesCountTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.recentFilesCountTextBox_Validating);
			this.recentFilesCountTextBox.Validated += new System.EventHandler(this.recentFilesCountTextBox_Validated);
			// 
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = resources.GetString("groupBox1.AccessibleDescription");
			this.groupBox1.AccessibleName = resources.GetString("groupBox1.AccessibleName");
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox1.Anchor")));
			this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.recentFilesCountTextBox);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.loadLastProjectCheckBox);
			this.groupBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox1.Dock")));
			this.groupBox1.Enabled = ((bool)(resources.GetObject("groupBox1.Enabled")));
			this.groupBox1.Font = ((System.Drawing.Font)(resources.GetObject("groupBox1.Font")));
			this.helpProvider1.SetHelpKeyword(this.groupBox1, resources.GetString("groupBox1.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.groupBox1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox1.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.groupBox1, resources.GetString("groupBox1.HelpString"));
			this.groupBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox1.ImeMode")));
			this.groupBox1.Location = ((System.Drawing.Point)(resources.GetObject("groupBox1.Location")));
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox1.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.groupBox1, ((bool)(resources.GetObject("groupBox1.ShowHelp"))));
			this.groupBox1.Size = ((System.Drawing.Size)(resources.GetObject("groupBox1.Size")));
			this.groupBox1.TabIndex = ((int)(resources.GetObject("groupBox1.TabIndex")));
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = resources.GetString("groupBox1.Text");
			this.groupBox1.Visible = ((bool)(resources.GetObject("groupBox1.Visible")));
			// 
			// groupBox2
			// 
			this.groupBox2.AccessibleDescription = resources.GetString("groupBox2.AccessibleDescription");
			this.groupBox2.AccessibleName = resources.GetString("groupBox2.AccessibleName");
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox2.Anchor")));
			this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
			this.groupBox2.Controls.Add(this.rerunOnChangeCheckBox);
			this.groupBox2.Controls.Add(this.reloadOnRunCheckBox);
			this.groupBox2.Controls.Add(this.reloadOnChangeCheckBox);
			this.groupBox2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox2.Dock")));
			this.groupBox2.Enabled = ((bool)(resources.GetObject("groupBox2.Enabled")));
			this.groupBox2.Font = ((System.Drawing.Font)(resources.GetObject("groupBox2.Font")));
			this.helpProvider1.SetHelpKeyword(this.groupBox2, resources.GetString("groupBox2.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.groupBox2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox2.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.groupBox2, resources.GetString("groupBox2.HelpString"));
			this.groupBox2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox2.ImeMode")));
			this.groupBox2.Location = ((System.Drawing.Point)(resources.GetObject("groupBox2.Location")));
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox2.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.groupBox2, ((bool)(resources.GetObject("groupBox2.ShowHelp"))));
			this.groupBox2.Size = ((System.Drawing.Size)(resources.GetObject("groupBox2.Size")));
			this.groupBox2.TabIndex = ((int)(resources.GetObject("groupBox2.TabIndex")));
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = resources.GetString("groupBox2.Text");
			this.groupBox2.Visible = ((bool)(resources.GetObject("groupBox2.Visible")));
			// 
			// rerunOnChangeCheckBox
			// 
			this.rerunOnChangeCheckBox.AccessibleDescription = resources.GetString("rerunOnChangeCheckBox.AccessibleDescription");
			this.rerunOnChangeCheckBox.AccessibleName = resources.GetString("rerunOnChangeCheckBox.AccessibleName");
			this.rerunOnChangeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("rerunOnChangeCheckBox.Anchor")));
			this.rerunOnChangeCheckBox.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("rerunOnChangeCheckBox.Appearance")));
			this.rerunOnChangeCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rerunOnChangeCheckBox.BackgroundImage")));
			this.rerunOnChangeCheckBox.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rerunOnChangeCheckBox.CheckAlign")));
			this.rerunOnChangeCheckBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("rerunOnChangeCheckBox.Dock")));
			this.rerunOnChangeCheckBox.Enabled = ((bool)(resources.GetObject("rerunOnChangeCheckBox.Enabled")));
			this.rerunOnChangeCheckBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("rerunOnChangeCheckBox.FlatStyle")));
			this.rerunOnChangeCheckBox.Font = ((System.Drawing.Font)(resources.GetObject("rerunOnChangeCheckBox.Font")));
			this.helpProvider1.SetHelpKeyword(this.rerunOnChangeCheckBox, resources.GetString("rerunOnChangeCheckBox.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.rerunOnChangeCheckBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rerunOnChangeCheckBox.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.rerunOnChangeCheckBox, resources.GetString("rerunOnChangeCheckBox.HelpString"));
			this.rerunOnChangeCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("rerunOnChangeCheckBox.Image")));
			this.rerunOnChangeCheckBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rerunOnChangeCheckBox.ImageAlign")));
			this.rerunOnChangeCheckBox.ImageIndex = ((int)(resources.GetObject("rerunOnChangeCheckBox.ImageIndex")));
			this.rerunOnChangeCheckBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("rerunOnChangeCheckBox.ImeMode")));
			this.rerunOnChangeCheckBox.Location = ((System.Drawing.Point)(resources.GetObject("rerunOnChangeCheckBox.Location")));
			this.rerunOnChangeCheckBox.Name = "rerunOnChangeCheckBox";
			this.rerunOnChangeCheckBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("rerunOnChangeCheckBox.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.rerunOnChangeCheckBox, ((bool)(resources.GetObject("rerunOnChangeCheckBox.ShowHelp"))));
			this.rerunOnChangeCheckBox.Size = ((System.Drawing.Size)(resources.GetObject("rerunOnChangeCheckBox.Size")));
			this.rerunOnChangeCheckBox.TabIndex = ((int)(resources.GetObject("rerunOnChangeCheckBox.TabIndex")));
			this.rerunOnChangeCheckBox.Text = resources.GetString("rerunOnChangeCheckBox.Text");
			this.rerunOnChangeCheckBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rerunOnChangeCheckBox.TextAlign")));
			this.rerunOnChangeCheckBox.Visible = ((bool)(resources.GetObject("rerunOnChangeCheckBox.Visible")));
			// 
			// groupBox3
			// 
			this.groupBox3.AccessibleDescription = resources.GetString("groupBox3.AccessibleDescription");
			this.groupBox3.AccessibleName = resources.GetString("groupBox3.AccessibleName");
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox3.Anchor")));
			this.groupBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox3.BackgroundImage")));
			this.groupBox3.Controls.Add(this.visualStudioSupportCheckBox);
			this.groupBox3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox3.Dock")));
			this.groupBox3.Enabled = ((bool)(resources.GetObject("groupBox3.Enabled")));
			this.groupBox3.Font = ((System.Drawing.Font)(resources.GetObject("groupBox3.Font")));
			this.helpProvider1.SetHelpKeyword(this.groupBox3, resources.GetString("groupBox3.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.groupBox3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox3.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.groupBox3, resources.GetString("groupBox3.HelpString"));
			this.groupBox3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox3.ImeMode")));
			this.groupBox3.Location = ((System.Drawing.Point)(resources.GetObject("groupBox3.Location")));
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox3.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.groupBox3, ((bool)(resources.GetObject("groupBox3.ShowHelp"))));
			this.groupBox3.Size = ((System.Drawing.Size)(resources.GetObject("groupBox3.Size")));
			this.groupBox3.TabIndex = ((int)(resources.GetObject("groupBox3.TabIndex")));
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = resources.GetString("groupBox3.Text");
			this.groupBox3.Visible = ((bool)(resources.GetObject("groupBox3.Visible")));
			// 
			// groupBox4
			// 
			this.groupBox4.AccessibleDescription = resources.GetString("groupBox4.AccessibleDescription");
			this.groupBox4.AccessibleName = resources.GetString("groupBox4.AccessibleName");
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox4.Anchor")));
			this.groupBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox4.BackgroundImage")));
			this.groupBox4.Controls.Add(this.enableWordWrap);
			this.groupBox4.Controls.Add(this.failureToolTips);
			this.groupBox4.Controls.Add(this.labelTestOutputCheckBox);
			this.groupBox4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox4.Dock")));
			this.groupBox4.Enabled = ((bool)(resources.GetObject("groupBox4.Enabled")));
			this.groupBox4.Font = ((System.Drawing.Font)(resources.GetObject("groupBox4.Font")));
			this.helpProvider1.SetHelpKeyword(this.groupBox4, resources.GetString("groupBox4.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.groupBox4, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox4.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.groupBox4, resources.GetString("groupBox4.HelpString"));
			this.groupBox4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox4.ImeMode")));
			this.groupBox4.Location = ((System.Drawing.Point)(resources.GetObject("groupBox4.Location")));
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox4.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.groupBox4, ((bool)(resources.GetObject("groupBox4.ShowHelp"))));
			this.groupBox4.Size = ((System.Drawing.Size)(resources.GetObject("groupBox4.Size")));
			this.groupBox4.TabIndex = ((int)(resources.GetObject("groupBox4.TabIndex")));
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = resources.GetString("groupBox4.Text");
			this.groupBox4.Visible = ((bool)(resources.GetObject("groupBox4.Visible")));
			// 
			// failureToolTips
			// 
			this.failureToolTips.AccessibleDescription = resources.GetString("failureToolTips.AccessibleDescription");
			this.failureToolTips.AccessibleName = resources.GetString("failureToolTips.AccessibleName");
			this.failureToolTips.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("failureToolTips.Anchor")));
			this.failureToolTips.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("failureToolTips.Appearance")));
			this.failureToolTips.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("failureToolTips.BackgroundImage")));
			this.failureToolTips.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("failureToolTips.CheckAlign")));
			this.failureToolTips.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("failureToolTips.Dock")));
			this.failureToolTips.Enabled = ((bool)(resources.GetObject("failureToolTips.Enabled")));
			this.failureToolTips.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("failureToolTips.FlatStyle")));
			this.failureToolTips.Font = ((System.Drawing.Font)(resources.GetObject("failureToolTips.Font")));
			this.helpProvider1.SetHelpKeyword(this.failureToolTips, resources.GetString("failureToolTips.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.failureToolTips, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("failureToolTips.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.failureToolTips, resources.GetString("failureToolTips.HelpString"));
			this.failureToolTips.Image = ((System.Drawing.Image)(resources.GetObject("failureToolTips.Image")));
			this.failureToolTips.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("failureToolTips.ImageAlign")));
			this.failureToolTips.ImageIndex = ((int)(resources.GetObject("failureToolTips.ImageIndex")));
			this.failureToolTips.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("failureToolTips.ImeMode")));
			this.failureToolTips.Location = ((System.Drawing.Point)(resources.GetObject("failureToolTips.Location")));
			this.failureToolTips.Name = "failureToolTips";
			this.failureToolTips.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("failureToolTips.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.failureToolTips, ((bool)(resources.GetObject("failureToolTips.ShowHelp"))));
			this.failureToolTips.Size = ((System.Drawing.Size)(resources.GetObject("failureToolTips.Size")));
			this.failureToolTips.TabIndex = ((int)(resources.GetObject("failureToolTips.TabIndex")));
			this.failureToolTips.Text = resources.GetString("failureToolTips.Text");
			this.failureToolTips.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("failureToolTips.TextAlign")));
			this.failureToolTips.Visible = ((bool)(resources.GetObject("failureToolTips.Visible")));
			// 
			// labelTestOutputCheckBox
			// 
			this.labelTestOutputCheckBox.AccessibleDescription = resources.GetString("labelTestOutputCheckBox.AccessibleDescription");
			this.labelTestOutputCheckBox.AccessibleName = resources.GetString("labelTestOutputCheckBox.AccessibleName");
			this.labelTestOutputCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("labelTestOutputCheckBox.Anchor")));
			this.labelTestOutputCheckBox.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("labelTestOutputCheckBox.Appearance")));
			this.labelTestOutputCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("labelTestOutputCheckBox.BackgroundImage")));
			this.labelTestOutputCheckBox.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("labelTestOutputCheckBox.CheckAlign")));
			this.labelTestOutputCheckBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("labelTestOutputCheckBox.Dock")));
			this.labelTestOutputCheckBox.Enabled = ((bool)(resources.GetObject("labelTestOutputCheckBox.Enabled")));
			this.labelTestOutputCheckBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("labelTestOutputCheckBox.FlatStyle")));
			this.labelTestOutputCheckBox.Font = ((System.Drawing.Font)(resources.GetObject("labelTestOutputCheckBox.Font")));
			this.helpProvider1.SetHelpKeyword(this.labelTestOutputCheckBox, resources.GetString("labelTestOutputCheckBox.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.labelTestOutputCheckBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("labelTestOutputCheckBox.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.labelTestOutputCheckBox, resources.GetString("labelTestOutputCheckBox.HelpString"));
			this.labelTestOutputCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("labelTestOutputCheckBox.Image")));
			this.labelTestOutputCheckBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("labelTestOutputCheckBox.ImageAlign")));
			this.labelTestOutputCheckBox.ImageIndex = ((int)(resources.GetObject("labelTestOutputCheckBox.ImageIndex")));
			this.labelTestOutputCheckBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("labelTestOutputCheckBox.ImeMode")));
			this.labelTestOutputCheckBox.Location = ((System.Drawing.Point)(resources.GetObject("labelTestOutputCheckBox.Location")));
			this.labelTestOutputCheckBox.Name = "labelTestOutputCheckBox";
			this.labelTestOutputCheckBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("labelTestOutputCheckBox.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.labelTestOutputCheckBox, ((bool)(resources.GetObject("labelTestOutputCheckBox.ShowHelp"))));
			this.labelTestOutputCheckBox.Size = ((System.Drawing.Size)(resources.GetObject("labelTestOutputCheckBox.Size")));
			this.labelTestOutputCheckBox.TabIndex = ((int)(resources.GetObject("labelTestOutputCheckBox.TabIndex")));
			this.labelTestOutputCheckBox.Text = resources.GetString("labelTestOutputCheckBox.Text");
			this.labelTestOutputCheckBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("labelTestOutputCheckBox.TextAlign")));
			this.labelTestOutputCheckBox.Visible = ((bool)(resources.GetObject("labelTestOutputCheckBox.Visible")));
			// 
			// tabControl1
			// 
			this.tabControl1.AccessibleDescription = resources.GetString("tabControl1.AccessibleDescription");
			this.tabControl1.AccessibleName = resources.GetString("tabControl1.AccessibleName");
			this.tabControl1.Alignment = ((System.Windows.Forms.TabAlignment)(resources.GetObject("tabControl1.Alignment")));
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabControl1.Anchor")));
			this.tabControl1.Appearance = ((System.Windows.Forms.TabAppearance)(resources.GetObject("tabControl1.Appearance")));
			this.tabControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabControl1.BackgroundImage")));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabControl1.Dock")));
			this.tabControl1.Enabled = ((bool)(resources.GetObject("tabControl1.Enabled")));
			this.tabControl1.Font = ((System.Drawing.Font)(resources.GetObject("tabControl1.Font")));
			this.helpProvider1.SetHelpKeyword(this.tabControl1, resources.GetString("tabControl1.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.tabControl1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabControl1.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.tabControl1, resources.GetString("tabControl1.HelpString"));
			this.tabControl1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabControl1.ImeMode")));
			this.tabControl1.ItemSize = ((System.Drawing.Size)(resources.GetObject("tabControl1.ItemSize")));
			this.tabControl1.Location = ((System.Drawing.Point)(resources.GetObject("tabControl1.Location")));
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.Padding = ((System.Drawing.Point)(resources.GetObject("tabControl1.Padding")));
			this.tabControl1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabControl1.RightToLeft")));
			this.tabControl1.SelectedIndex = 0;
			this.helpProvider1.SetShowHelp(this.tabControl1, ((bool)(resources.GetObject("tabControl1.ShowHelp"))));
			this.tabControl1.ShowToolTips = ((bool)(resources.GetObject("tabControl1.ShowToolTips")));
			this.tabControl1.Size = ((System.Drawing.Size)(resources.GetObject("tabControl1.Size")));
			this.tabControl1.TabIndex = ((int)(resources.GetObject("tabControl1.TabIndex")));
			this.tabControl1.Text = resources.GetString("tabControl1.Text");
			this.tabControl1.Visible = ((bool)(resources.GetObject("tabControl1.Visible")));
			// 
			// tabPage1
			// 
			this.tabPage1.AccessibleDescription = resources.GetString("tabPage1.AccessibleDescription");
			this.tabPage1.AccessibleName = resources.GetString("tabPage1.AccessibleName");
			this.tabPage1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabPage1.Anchor")));
			this.tabPage1.AutoScroll = ((bool)(resources.GetObject("tabPage1.AutoScroll")));
			this.tabPage1.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("tabPage1.AutoScrollMargin")));
			this.tabPage1.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("tabPage1.AutoScrollMinSize")));
			this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
			this.tabPage1.Controls.Add(this.groupBox5);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabPage1.Dock")));
			this.tabPage1.Enabled = ((bool)(resources.GetObject("tabPage1.Enabled")));
			this.tabPage1.Font = ((System.Drawing.Font)(resources.GetObject("tabPage1.Font")));
			this.helpProvider1.SetHelpKeyword(this.tabPage1, resources.GetString("tabPage1.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.tabPage1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabPage1.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.tabPage1, resources.GetString("tabPage1.HelpString"));
			this.tabPage1.ImageIndex = ((int)(resources.GetObject("tabPage1.ImageIndex")));
			this.tabPage1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabPage1.ImeMode")));
			this.tabPage1.Location = ((System.Drawing.Point)(resources.GetObject("tabPage1.Location")));
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabPage1.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.tabPage1, ((bool)(resources.GetObject("tabPage1.ShowHelp"))));
			this.tabPage1.Size = ((System.Drawing.Size)(resources.GetObject("tabPage1.Size")));
			this.tabPage1.TabIndex = ((int)(resources.GetObject("tabPage1.TabIndex")));
			this.tabPage1.Text = resources.GetString("tabPage1.Text");
			this.tabPage1.ToolTipText = resources.GetString("tabPage1.ToolTipText");
			this.tabPage1.Visible = ((bool)(resources.GetObject("tabPage1.Visible")));
			// 
			// groupBox5
			// 
			this.groupBox5.AccessibleDescription = resources.GetString("groupBox5.AccessibleDescription");
			this.groupBox5.AccessibleName = resources.GetString("groupBox5.AccessibleName");
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox5.Anchor")));
			this.groupBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox5.BackgroundImage")));
			this.groupBox5.Controls.Add(this.label1);
			this.groupBox5.Controls.Add(this.initialDisplayComboBox);
			this.groupBox5.Controls.Add(this.clearResultsCheckBox);
			this.groupBox5.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox5.Dock")));
			this.groupBox5.Enabled = ((bool)(resources.GetObject("groupBox5.Enabled")));
			this.groupBox5.Font = ((System.Drawing.Font)(resources.GetObject("groupBox5.Font")));
			this.helpProvider1.SetHelpKeyword(this.groupBox5, resources.GetString("groupBox5.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.groupBox5, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox5.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.groupBox5, resources.GetString("groupBox5.HelpString"));
			this.groupBox5.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox5.ImeMode")));
			this.groupBox5.Location = ((System.Drawing.Point)(resources.GetObject("groupBox5.Location")));
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox5.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.groupBox5, ((bool)(resources.GetObject("groupBox5.ShowHelp"))));
			this.groupBox5.Size = ((System.Drawing.Size)(resources.GetObject("groupBox5.Size")));
			this.groupBox5.TabIndex = ((int)(resources.GetObject("groupBox5.TabIndex")));
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = resources.GetString("groupBox5.Text");
			this.groupBox5.Visible = ((bool)(resources.GetObject("groupBox5.Visible")));
			// 
			// tabPage2
			// 
			this.tabPage2.AccessibleDescription = resources.GetString("tabPage2.AccessibleDescription");
			this.tabPage2.AccessibleName = resources.GetString("tabPage2.AccessibleName");
			this.tabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabPage2.Anchor")));
			this.tabPage2.AutoScroll = ((bool)(resources.GetObject("tabPage2.AutoScroll")));
			this.tabPage2.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("tabPage2.AutoScrollMargin")));
			this.tabPage2.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("tabPage2.AutoScrollMinSize")));
			this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
			this.tabPage2.Controls.Add(this.groupBox7);
			this.tabPage2.Controls.Add(this.groupBox6);
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Controls.Add(this.groupBox3);
			this.tabPage2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabPage2.Dock")));
			this.tabPage2.Enabled = ((bool)(resources.GetObject("tabPage2.Enabled")));
			this.tabPage2.Font = ((System.Drawing.Font)(resources.GetObject("tabPage2.Font")));
			this.helpProvider1.SetHelpKeyword(this.tabPage2, resources.GetString("tabPage2.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.tabPage2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabPage2.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.tabPage2, resources.GetString("tabPage2.HelpString"));
			this.tabPage2.ImageIndex = ((int)(resources.GetObject("tabPage2.ImageIndex")));
			this.tabPage2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabPage2.ImeMode")));
			this.tabPage2.Location = ((System.Drawing.Point)(resources.GetObject("tabPage2.Location")));
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabPage2.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.tabPage2, ((bool)(resources.GetObject("tabPage2.ShowHelp"))));
			this.tabPage2.Size = ((System.Drawing.Size)(resources.GetObject("tabPage2.Size")));
			this.tabPage2.TabIndex = ((int)(resources.GetObject("tabPage2.TabIndex")));
			this.tabPage2.Text = resources.GetString("tabPage2.Text");
			this.tabPage2.ToolTipText = resources.GetString("tabPage2.ToolTipText");
			this.tabPage2.Visible = ((bool)(resources.GetObject("tabPage2.Visible")));
			// 
			// groupBox7
			// 
			this.groupBox7.AccessibleDescription = resources.GetString("groupBox7.AccessibleDescription");
			this.groupBox7.AccessibleName = resources.GetString("groupBox7.AccessibleName");
			this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox7.Anchor")));
			this.groupBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox7.BackgroundImage")));
			this.groupBox7.Controls.Add(this.flatTestList);
			this.groupBox7.Controls.Add(this.autoNamespaceSuites);
			this.groupBox7.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox7.Dock")));
			this.groupBox7.Enabled = ((bool)(resources.GetObject("groupBox7.Enabled")));
			this.groupBox7.Font = ((System.Drawing.Font)(resources.GetObject("groupBox7.Font")));
			this.helpProvider1.SetHelpKeyword(this.groupBox7, resources.GetString("groupBox7.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.groupBox7, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox7.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.groupBox7, resources.GetString("groupBox7.HelpString"));
			this.groupBox7.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox7.ImeMode")));
			this.groupBox7.Location = ((System.Drawing.Point)(resources.GetObject("groupBox7.Location")));
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox7.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.groupBox7, ((bool)(resources.GetObject("groupBox7.ShowHelp"))));
			this.groupBox7.Size = ((System.Drawing.Size)(resources.GetObject("groupBox7.Size")));
			this.groupBox7.TabIndex = ((int)(resources.GetObject("groupBox7.TabIndex")));
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = resources.GetString("groupBox7.Text");
			this.groupBox7.Visible = ((bool)(resources.GetObject("groupBox7.Visible")));
			// 
			// flatTestList
			// 
			this.flatTestList.AccessibleDescription = resources.GetString("flatTestList.AccessibleDescription");
			this.flatTestList.AccessibleName = resources.GetString("flatTestList.AccessibleName");
			this.flatTestList.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("flatTestList.Anchor")));
			this.flatTestList.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("flatTestList.Appearance")));
			this.flatTestList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flatTestList.BackgroundImage")));
			this.flatTestList.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("flatTestList.CheckAlign")));
			this.flatTestList.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("flatTestList.Dock")));
			this.flatTestList.Enabled = ((bool)(resources.GetObject("flatTestList.Enabled")));
			this.flatTestList.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("flatTestList.FlatStyle")));
			this.flatTestList.Font = ((System.Drawing.Font)(resources.GetObject("flatTestList.Font")));
			this.helpProvider1.SetHelpKeyword(this.flatTestList, resources.GetString("flatTestList.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.flatTestList, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("flatTestList.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.flatTestList, resources.GetString("flatTestList.HelpString"));
			this.flatTestList.Image = ((System.Drawing.Image)(resources.GetObject("flatTestList.Image")));
			this.flatTestList.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("flatTestList.ImageAlign")));
			this.flatTestList.ImageIndex = ((int)(resources.GetObject("flatTestList.ImageIndex")));
			this.flatTestList.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("flatTestList.ImeMode")));
			this.flatTestList.Location = ((System.Drawing.Point)(resources.GetObject("flatTestList.Location")));
			this.flatTestList.Name = "flatTestList";
			this.flatTestList.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("flatTestList.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.flatTestList, ((bool)(resources.GetObject("flatTestList.ShowHelp"))));
			this.flatTestList.Size = ((System.Drawing.Size)(resources.GetObject("flatTestList.Size")));
			this.flatTestList.TabIndex = ((int)(resources.GetObject("flatTestList.TabIndex")));
			this.flatTestList.Text = resources.GetString("flatTestList.Text");
			this.flatTestList.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("flatTestList.TextAlign")));
			this.flatTestList.Visible = ((bool)(resources.GetObject("flatTestList.Visible")));
			// 
			// autoNamespaceSuites
			// 
			this.autoNamespaceSuites.AccessibleDescription = resources.GetString("autoNamespaceSuites.AccessibleDescription");
			this.autoNamespaceSuites.AccessibleName = resources.GetString("autoNamespaceSuites.AccessibleName");
			this.autoNamespaceSuites.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("autoNamespaceSuites.Anchor")));
			this.autoNamespaceSuites.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("autoNamespaceSuites.Appearance")));
			this.autoNamespaceSuites.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("autoNamespaceSuites.BackgroundImage")));
			this.autoNamespaceSuites.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("autoNamespaceSuites.CheckAlign")));
			this.autoNamespaceSuites.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("autoNamespaceSuites.Dock")));
			this.autoNamespaceSuites.Enabled = ((bool)(resources.GetObject("autoNamespaceSuites.Enabled")));
			this.autoNamespaceSuites.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("autoNamespaceSuites.FlatStyle")));
			this.autoNamespaceSuites.Font = ((System.Drawing.Font)(resources.GetObject("autoNamespaceSuites.Font")));
			this.helpProvider1.SetHelpKeyword(this.autoNamespaceSuites, resources.GetString("autoNamespaceSuites.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.autoNamespaceSuites, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("autoNamespaceSuites.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.autoNamespaceSuites, resources.GetString("autoNamespaceSuites.HelpString"));
			this.autoNamespaceSuites.Image = ((System.Drawing.Image)(resources.GetObject("autoNamespaceSuites.Image")));
			this.autoNamespaceSuites.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("autoNamespaceSuites.ImageAlign")));
			this.autoNamespaceSuites.ImageIndex = ((int)(resources.GetObject("autoNamespaceSuites.ImageIndex")));
			this.autoNamespaceSuites.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("autoNamespaceSuites.ImeMode")));
			this.autoNamespaceSuites.Location = ((System.Drawing.Point)(resources.GetObject("autoNamespaceSuites.Location")));
			this.autoNamespaceSuites.Name = "autoNamespaceSuites";
			this.autoNamespaceSuites.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("autoNamespaceSuites.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.autoNamespaceSuites, ((bool)(resources.GetObject("autoNamespaceSuites.ShowHelp"))));
			this.autoNamespaceSuites.Size = ((System.Drawing.Size)(resources.GetObject("autoNamespaceSuites.Size")));
			this.autoNamespaceSuites.TabIndex = ((int)(resources.GetObject("autoNamespaceSuites.TabIndex")));
			this.autoNamespaceSuites.Text = resources.GetString("autoNamespaceSuites.Text");
			this.autoNamespaceSuites.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("autoNamespaceSuites.TextAlign")));
			this.autoNamespaceSuites.Visible = ((bool)(resources.GetObject("autoNamespaceSuites.Visible")));
			// 
			// groupBox6
			// 
			this.groupBox6.AccessibleDescription = resources.GetString("groupBox6.AccessibleDescription");
			this.groupBox6.AccessibleName = resources.GetString("groupBox6.AccessibleName");
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox6.Anchor")));
			this.groupBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox6.BackgroundImage")));
			this.groupBox6.Controls.Add(this.mergeAssembliesCheckBox);
			this.groupBox6.Controls.Add(this.singleDomainRadioButton);
			this.groupBox6.Controls.Add(this.multiDomainRadioButton);
			this.groupBox6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox6.Dock")));
			this.groupBox6.Enabled = ((bool)(resources.GetObject("groupBox6.Enabled")));
			this.groupBox6.Font = ((System.Drawing.Font)(resources.GetObject("groupBox6.Font")));
			this.helpProvider1.SetHelpKeyword(this.groupBox6, resources.GetString("groupBox6.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.groupBox6, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox6.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.groupBox6, resources.GetString("groupBox6.HelpString"));
			this.groupBox6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox6.ImeMode")));
			this.groupBox6.Location = ((System.Drawing.Point)(resources.GetObject("groupBox6.Location")));
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox6.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.groupBox6, ((bool)(resources.GetObject("groupBox6.ShowHelp"))));
			this.groupBox6.Size = ((System.Drawing.Size)(resources.GetObject("groupBox6.Size")));
			this.groupBox6.TabIndex = ((int)(resources.GetObject("groupBox6.TabIndex")));
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = resources.GetString("groupBox6.Text");
			this.groupBox6.Visible = ((bool)(resources.GetObject("groupBox6.Visible")));
			// 
			// mergeAssembliesCheckBox
			// 
			this.mergeAssembliesCheckBox.AccessibleDescription = resources.GetString("mergeAssembliesCheckBox.AccessibleDescription");
			this.mergeAssembliesCheckBox.AccessibleName = resources.GetString("mergeAssembliesCheckBox.AccessibleName");
			this.mergeAssembliesCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("mergeAssembliesCheckBox.Anchor")));
			this.mergeAssembliesCheckBox.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("mergeAssembliesCheckBox.Appearance")));
			this.mergeAssembliesCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mergeAssembliesCheckBox.BackgroundImage")));
			this.mergeAssembliesCheckBox.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("mergeAssembliesCheckBox.CheckAlign")));
			this.mergeAssembliesCheckBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("mergeAssembliesCheckBox.Dock")));
			this.mergeAssembliesCheckBox.Enabled = ((bool)(resources.GetObject("mergeAssembliesCheckBox.Enabled")));
			this.mergeAssembliesCheckBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("mergeAssembliesCheckBox.FlatStyle")));
			this.mergeAssembliesCheckBox.Font = ((System.Drawing.Font)(resources.GetObject("mergeAssembliesCheckBox.Font")));
			this.helpProvider1.SetHelpKeyword(this.mergeAssembliesCheckBox, resources.GetString("mergeAssembliesCheckBox.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.mergeAssembliesCheckBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("mergeAssembliesCheckBox.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.mergeAssembliesCheckBox, resources.GetString("mergeAssembliesCheckBox.HelpString"));
			this.mergeAssembliesCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("mergeAssembliesCheckBox.Image")));
			this.mergeAssembliesCheckBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("mergeAssembliesCheckBox.ImageAlign")));
			this.mergeAssembliesCheckBox.ImageIndex = ((int)(resources.GetObject("mergeAssembliesCheckBox.ImageIndex")));
			this.mergeAssembliesCheckBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("mergeAssembliesCheckBox.ImeMode")));
			this.mergeAssembliesCheckBox.Location = ((System.Drawing.Point)(resources.GetObject("mergeAssembliesCheckBox.Location")));
			this.mergeAssembliesCheckBox.Name = "mergeAssembliesCheckBox";
			this.mergeAssembliesCheckBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("mergeAssembliesCheckBox.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.mergeAssembliesCheckBox, ((bool)(resources.GetObject("mergeAssembliesCheckBox.ShowHelp"))));
			this.mergeAssembliesCheckBox.Size = ((System.Drawing.Size)(resources.GetObject("mergeAssembliesCheckBox.Size")));
			this.mergeAssembliesCheckBox.TabIndex = ((int)(resources.GetObject("mergeAssembliesCheckBox.TabIndex")));
			this.mergeAssembliesCheckBox.Text = resources.GetString("mergeAssembliesCheckBox.Text");
			this.mergeAssembliesCheckBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("mergeAssembliesCheckBox.TextAlign")));
			this.mergeAssembliesCheckBox.Visible = ((bool)(resources.GetObject("mergeAssembliesCheckBox.Visible")));
			// 
			// singleDomainRadioButton
			// 
			this.singleDomainRadioButton.AccessibleDescription = resources.GetString("singleDomainRadioButton.AccessibleDescription");
			this.singleDomainRadioButton.AccessibleName = resources.GetString("singleDomainRadioButton.AccessibleName");
			this.singleDomainRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("singleDomainRadioButton.Anchor")));
			this.singleDomainRadioButton.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("singleDomainRadioButton.Appearance")));
			this.singleDomainRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("singleDomainRadioButton.BackgroundImage")));
			this.singleDomainRadioButton.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("singleDomainRadioButton.CheckAlign")));
			this.singleDomainRadioButton.Checked = true;
			this.singleDomainRadioButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("singleDomainRadioButton.Dock")));
			this.singleDomainRadioButton.Enabled = ((bool)(resources.GetObject("singleDomainRadioButton.Enabled")));
			this.singleDomainRadioButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("singleDomainRadioButton.FlatStyle")));
			this.singleDomainRadioButton.Font = ((System.Drawing.Font)(resources.GetObject("singleDomainRadioButton.Font")));
			this.helpProvider1.SetHelpKeyword(this.singleDomainRadioButton, resources.GetString("singleDomainRadioButton.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.singleDomainRadioButton, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("singleDomainRadioButton.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.singleDomainRadioButton, resources.GetString("singleDomainRadioButton.HelpString"));
			this.singleDomainRadioButton.Image = ((System.Drawing.Image)(resources.GetObject("singleDomainRadioButton.Image")));
			this.singleDomainRadioButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("singleDomainRadioButton.ImageAlign")));
			this.singleDomainRadioButton.ImageIndex = ((int)(resources.GetObject("singleDomainRadioButton.ImageIndex")));
			this.singleDomainRadioButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("singleDomainRadioButton.ImeMode")));
			this.singleDomainRadioButton.Location = ((System.Drawing.Point)(resources.GetObject("singleDomainRadioButton.Location")));
			this.singleDomainRadioButton.Name = "singleDomainRadioButton";
			this.singleDomainRadioButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("singleDomainRadioButton.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.singleDomainRadioButton, ((bool)(resources.GetObject("singleDomainRadioButton.ShowHelp"))));
			this.singleDomainRadioButton.Size = ((System.Drawing.Size)(resources.GetObject("singleDomainRadioButton.Size")));
			this.singleDomainRadioButton.TabIndex = ((int)(resources.GetObject("singleDomainRadioButton.TabIndex")));
			this.singleDomainRadioButton.TabStop = true;
			this.singleDomainRadioButton.Text = resources.GetString("singleDomainRadioButton.Text");
			this.singleDomainRadioButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("singleDomainRadioButton.TextAlign")));
			this.singleDomainRadioButton.Visible = ((bool)(resources.GetObject("singleDomainRadioButton.Visible")));
			this.singleDomainRadioButton.CheckedChanged += new System.EventHandler(this.singleDomainRadioButton_CheckedChanged);
			// 
			// multiDomainRadioButton
			// 
			this.multiDomainRadioButton.AccessibleDescription = resources.GetString("multiDomainRadioButton.AccessibleDescription");
			this.multiDomainRadioButton.AccessibleName = resources.GetString("multiDomainRadioButton.AccessibleName");
			this.multiDomainRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("multiDomainRadioButton.Anchor")));
			this.multiDomainRadioButton.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("multiDomainRadioButton.Appearance")));
			this.multiDomainRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("multiDomainRadioButton.BackgroundImage")));
			this.multiDomainRadioButton.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("multiDomainRadioButton.CheckAlign")));
			this.multiDomainRadioButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("multiDomainRadioButton.Dock")));
			this.multiDomainRadioButton.Enabled = ((bool)(resources.GetObject("multiDomainRadioButton.Enabled")));
			this.multiDomainRadioButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("multiDomainRadioButton.FlatStyle")));
			this.multiDomainRadioButton.Font = ((System.Drawing.Font)(resources.GetObject("multiDomainRadioButton.Font")));
			this.helpProvider1.SetHelpKeyword(this.multiDomainRadioButton, resources.GetString("multiDomainRadioButton.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.multiDomainRadioButton, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("multiDomainRadioButton.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.multiDomainRadioButton, resources.GetString("multiDomainRadioButton.HelpString"));
			this.multiDomainRadioButton.Image = ((System.Drawing.Image)(resources.GetObject("multiDomainRadioButton.Image")));
			this.multiDomainRadioButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("multiDomainRadioButton.ImageAlign")));
			this.multiDomainRadioButton.ImageIndex = ((int)(resources.GetObject("multiDomainRadioButton.ImageIndex")));
			this.multiDomainRadioButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("multiDomainRadioButton.ImeMode")));
			this.multiDomainRadioButton.Location = ((System.Drawing.Point)(resources.GetObject("multiDomainRadioButton.Location")));
			this.multiDomainRadioButton.Name = "multiDomainRadioButton";
			this.multiDomainRadioButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("multiDomainRadioButton.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.multiDomainRadioButton, ((bool)(resources.GetObject("multiDomainRadioButton.ShowHelp"))));
			this.multiDomainRadioButton.Size = ((System.Drawing.Size)(resources.GetObject("multiDomainRadioButton.Size")));
			this.multiDomainRadioButton.TabIndex = ((int)(resources.GetObject("multiDomainRadioButton.TabIndex")));
			this.multiDomainRadioButton.Text = resources.GetString("multiDomainRadioButton.Text");
			this.multiDomainRadioButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("multiDomainRadioButton.TextAlign")));
			this.multiDomainRadioButton.Visible = ((bool)(resources.GetObject("multiDomainRadioButton.Visible")));
			// 
			// enableWordWrap
			// 
			this.enableWordWrap.AccessibleDescription = resources.GetString("enableWordWrap.AccessibleDescription");
			this.enableWordWrap.AccessibleName = resources.GetString("enableWordWrap.AccessibleName");
			this.enableWordWrap.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("enableWordWrap.Anchor")));
			this.enableWordWrap.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("enableWordWrap.Appearance")));
			this.enableWordWrap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enableWordWrap.BackgroundImage")));
			this.enableWordWrap.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("enableWordWrap.CheckAlign")));
			this.enableWordWrap.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("enableWordWrap.Dock")));
			this.enableWordWrap.Enabled = ((bool)(resources.GetObject("enableWordWrap.Enabled")));
			this.enableWordWrap.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("enableWordWrap.FlatStyle")));
			this.enableWordWrap.Font = ((System.Drawing.Font)(resources.GetObject("enableWordWrap.Font")));
			this.helpProvider1.SetHelpKeyword(this.enableWordWrap, resources.GetString("enableWordWrap.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this.enableWordWrap, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("enableWordWrap.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this.enableWordWrap, resources.GetString("enableWordWrap.HelpString"));
			this.enableWordWrap.Image = ((System.Drawing.Image)(resources.GetObject("enableWordWrap.Image")));
			this.enableWordWrap.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("enableWordWrap.ImageAlign")));
			this.enableWordWrap.ImageIndex = ((int)(resources.GetObject("enableWordWrap.ImageIndex")));
			this.enableWordWrap.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("enableWordWrap.ImeMode")));
			this.enableWordWrap.Location = ((System.Drawing.Point)(resources.GetObject("enableWordWrap.Location")));
			this.enableWordWrap.Name = "enableWordWrap";
			this.enableWordWrap.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("enableWordWrap.RightToLeft")));
			this.helpProvider1.SetShowHelp(this.enableWordWrap, ((bool)(resources.GetObject("enableWordWrap.ShowHelp"))));
			this.enableWordWrap.Size = ((System.Drawing.Size)(resources.GetObject("enableWordWrap.Size")));
			this.enableWordWrap.TabIndex = ((int)(resources.GetObject("enableWordWrap.TabIndex")));
			this.enableWordWrap.Text = resources.GetString("enableWordWrap.Text");
			this.enableWordWrap.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("enableWordWrap.TextAlign")));
			this.enableWordWrap.Visible = ((bool)(resources.GetObject("enableWordWrap.Visible")));
			// 
			// OptionsDialog
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.helpProvider1.SetHelpKeyword(this, resources.GetString("$this.HelpKeyword"));
			this.helpProvider1.SetHelpNavigator(this, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("$this.HelpNavigator"))));
			this.helpProvider1.SetHelpString(this, resources.GetString("$this.HelpString"));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimizeBox = false;
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "OptionsDialog";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Closing += new System.ComponentModel.CancelEventHandler(this.OptionsDialog_Closing);
			this.Load += new System.EventHandler(this.OptionsDialog_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void OptionsDialog_Load(object sender, System.EventArgs e)
		{
			recentFilesCountTextBox.Text = UserSettings.RecentProjects.MaxFiles.ToString();

			this.options = UserSettings.Options;
			loadLastProjectCheckBox.Checked = options.LoadLastProject;
			initialDisplayComboBox.SelectedIndex = options.InitialTreeDisplay;

			reloadOnChangeCheckBox.Enabled = Environment.OSVersion.Platform == System.PlatformID.Win32NT;
			reloadOnChangeCheckBox.Checked = options.ReloadOnChange;
			rerunOnChangeCheckBox.Checked = options.RerunOnChange;
			reloadOnRunCheckBox.Checked = options.ReloadOnRun;
			clearResultsCheckBox.Checked = options.ClearResults;

			bool multiDomain = options.MultiDomain;
			multiDomainRadioButton.Checked = multiDomain;
			singleDomainRadioButton.Checked = !multiDomain;
			mergeAssembliesCheckBox.Enabled = !multiDomain;
			mergeAssembliesCheckBox.Checked = options.MergeAssemblies;
			autoNamespaceSuites.Checked = options.AutoNamespaceSuites;
			flatTestList.Checked = !options.AutoNamespaceSuites;

			labelTestOutputCheckBox.Checked = options.TestLabels;
			failureToolTips.Checked = options.FailureToolTips;
			enableWordWrap.Checked = options.EnableWordWrapForFailures;

			visualStudioSupportCheckBox.Checked = options.VisualStudioSupport;
		}

		private void okButton_Click(object sender, System.EventArgs e)
		{
			if ( options.ReloadOnChange != reloadOnChangeCheckBox.Checked )
			{
				string msg = String.Format(
					"Watching for file changes will be {0} the next time you load an assembly.",
					reloadOnChangeCheckBox.Checked ? "enabled" : "disabled" );

				UserMessage.DisplayInfo( msg, "NUnit Options" );
			}

			options.LoadLastProject = loadLastProjectCheckBox.Checked;
			
			TestLoader loader = GetService( typeof( TestLoader ) ) as TestLoader;
			loader.ReloadOnChange = options.ReloadOnChange = reloadOnChangeCheckBox.Checked;
			loader.RerunOnChange = options.RerunOnChange = rerunOnChangeCheckBox.Checked;
			loader.ReloadOnRun = options.ReloadOnRun = reloadOnRunCheckBox.Checked;
			options.ClearResults = clearResultsCheckBox.Checked;

			loader.MultiDomain = options.MultiDomain = multiDomainRadioButton.Checked;
			loader.MergeAssemblies = options.MergeAssemblies = mergeAssembliesCheckBox.Checked;
			loader.AutoNamespaceSuites = options.AutoNamespaceSuites = autoNamespaceSuites.Checked;

			options.TestLabels = labelTestOutputCheckBox.Checked;
			options.FailureToolTips = failureToolTips.Checked;
			options.EnableWordWrapForFailures = enableWordWrap.Checked;
			
			options.VisualStudioSupport = visualStudioSupportCheckBox.Checked;

			options.InitialTreeDisplay = initialDisplayComboBox.SelectedIndex;

			DialogResult = DialogResult.OK;

			Close();
		}

		private void recentFilesCountTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if ( recentFilesCountTextBox.Text.Length == 0 )
			{
				recentFilesCountTextBox.Text = UserSettings.RecentProjects.MaxFiles.ToString();
				recentFilesCountTextBox.SelectAll();
				e.Cancel = true;
			}
			else
			{
				string errmsg = null;

				try
				{
					int count = int.Parse( recentFilesCountTextBox.Text );

					if ( count < RecentFileSettings.MinSize ||
						count > RecentFileSettings.MaxSize )
					{
						errmsg = string.Format( "Number of files must be from {0} to {1}", RecentFileSettings.MinSize, RecentFileSettings.MaxSize );
					}
				}
				catch
				{
					errmsg = "Number of files must be numeric";
				}

				if ( errmsg != null )
				{
					recentFilesCountTextBox.SelectAll();
					UserMessage.DisplayFailure( errmsg );
					e.Cancel = true;
				}
			}
		}

		private void recentFilesCountTextBox_Validated(object sender, System.EventArgs e)
		{
			int count = int.Parse( recentFilesCountTextBox.Text );
			UserSettings.RecentProjects.MaxFiles = count;
		}

		private void OptionsDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = false;
		}

		private void singleDomainRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			mergeAssembliesCheckBox.Enabled = singleDomainRadioButton.Checked;
		}

		private void reloadOnChangeCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			rerunOnChangeCheckBox.Enabled = reloadOnChangeCheckBox.Checked;
			rerunOnChangeCheckBox.Checked = false;
		}
	}
}
