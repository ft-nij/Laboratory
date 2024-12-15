
namespace GraphicEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_SetCoord = new System.Windows.Forms.DataGridView();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ur = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonTransform2d = new System.Windows.Forms.Button();
            this.StopDrawing = new System.Windows.Forms.Button();
            this.buttonMirror2d = new System.Windows.Forms.Button();
            this.button_MirrorX2d = new System.Windows.Forms.Button();
            this.button_MirrorY2d = new System.Windows.Forms.Button();
            this.button_Rotation2d = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label_Rotation2d = new System.Windows.Forms.Label();
            this.button_Scale2D = new System.Windows.Forms.Button();
            this.button_ScaleIt2D = new System.Windows.Forms.Button();
            this.textBox_ScaleK2D = new System.Windows.Forms.TextBox();
            this.button_AddCube = new System.Windows.Forms.Button();
            this.button_trimetrProekc = new System.Windows.Forms.Button();
            this.button_SetCoord = new System.Windows.Forms.Button();
            this.button_Rotate3D = new System.Windows.Forms.Button();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTransform = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTransformZ = new System.Windows.Forms.TextBox();
            this.textBoxTransformY = new System.Windows.Forms.TextBox();
            this.textBoxTransformX = new System.Windows.Forms.TextBox();
            this.button_Transform3D = new System.Windows.Forms.Button();
            this.button_doTransform3D = new System.Windows.Forms.Button();
            this.button_Mirror3D = new System.Windows.Forms.Button();
            this.button_Mirror3dX = new System.Windows.Forms.Button();
            this.button_Mirror3dY = new System.Windows.Forms.Button();
            this.button_Mirror3dZ = new System.Windows.Forms.Button();
            this.button_Scale3D = new System.Windows.Forms.Button();
            this.button_Selection = new System.Windows.Forms.Button();
            this.textBoxZc = new System.Windows.Forms.TextBox();
            this.textBoxGamma = new System.Windows.Forms.TextBox();
            this.textBoxAlpha = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Upload = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SetCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(172, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 479);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // dataGridView_SetCoord
            // 
            this.dataGridView_SetCoord.AllowUserToAddRows = false;
            this.dataGridView_SetCoord.AllowUserToDeleteRows = false;
            this.dataGridView_SetCoord.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_SetCoord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SetCoord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.x,
            this.y,
            this.z});
            this.dataGridView_SetCoord.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView_SetCoord.Location = new System.Drawing.Point(15, 283);
            this.dataGridView_SetCoord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_SetCoord.Name = "dataGridView_SetCoord";
            this.dataGridView_SetCoord.RowHeadersVisible = false;
            this.dataGridView_SetCoord.RowHeadersWidth = 10;
            this.dataGridView_SetCoord.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_SetCoord.RowTemplate.Height = 29;
            this.dataGridView_SetCoord.Size = new System.Drawing.Size(151, 215);
            this.dataGridView_SetCoord.TabIndex = 0;
            this.dataGridView_SetCoord.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_SetCoord_CellValueChanged);
            // 
            // x
            // 
            this.x.HeaderText = "x";
            this.x.MinimumWidth = 6;
            this.x.Name = "x";
            this.x.Width = 43;
            // 
            // y
            // 
            this.y.HeaderText = "y";
            this.y.MinimumWidth = 6;
            this.y.Name = "y";
            this.y.Width = 43;
            // 
            // z
            // 
            this.z.HeaderText = "z";
            this.z.MinimumWidth = 6;
            this.z.Name = "z";
            this.z.Width = 43;
            // 
            // ur
            // 
            this.ur.AutoSize = true;
            this.ur.Location = new System.Drawing.Point(46, 361);
            this.ur.Name = "ur";
            this.ur.Size = new System.Drawing.Size(0, 15);
            this.ur.TabIndex = 2;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAdd.Location = new System.Drawing.Point(1233, 74);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(37, 25);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "L";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.SystemColors.Control;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonEdit.Location = new System.Drawing.Point(1233, 100);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(37, 25);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "TD";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.Location = new System.Drawing.Point(16, 6);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(37, 25);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonTransform2d
            // 
            this.buttonTransform2d.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTransform2d.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonTransform2d.Location = new System.Drawing.Point(1233, 126);
            this.buttonTransform2d.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTransform2d.Name = "buttonTransform2d";
            this.buttonTransform2d.Size = new System.Drawing.Size(37, 25);
            this.buttonTransform2d.TabIndex = 8;
            this.buttonTransform2d.Text = "TL";
            this.buttonTransform2d.UseVisualStyleBackColor = true;
            this.buttonTransform2d.Click += new System.EventHandler(this.buttonTransform_Click);
            // 
            // StopDrawing
            // 
            this.StopDrawing.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StopDrawing.Location = new System.Drawing.Point(440, 504);
            this.StopDrawing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopDrawing.Name = "StopDrawing";
            this.StopDrawing.Size = new System.Drawing.Size(504, 24);
            this.StopDrawing.TabIndex = 9;
            this.StopDrawing.Text = "Готово";
            this.StopDrawing.UseVisualStyleBackColor = true;
            this.StopDrawing.Click += new System.EventHandler(this.StopDrawing_Click);
            // 
            // buttonMirror2d
            // 
            this.buttonMirror2d.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMirror2d.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonMirror2d.Location = new System.Drawing.Point(1233, 156);
            this.buttonMirror2d.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonMirror2d.Name = "buttonMirror2d";
            this.buttonMirror2d.Size = new System.Drawing.Size(37, 25);
            this.buttonMirror2d.TabIndex = 10;
            this.buttonMirror2d.Text = "M";
            this.buttonMirror2d.UseVisualStyleBackColor = true;
            this.buttonMirror2d.Click += new System.EventHandler(this.buttonMirror2d_Click);
            // 
            // button_MirrorX2d
            // 
            this.button_MirrorX2d.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_MirrorX2d.Location = new System.Drawing.Point(17, 39);
            this.button_MirrorX2d.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_MirrorX2d.Name = "button_MirrorX2d";
            this.button_MirrorX2d.Size = new System.Drawing.Size(118, 22);
            this.button_MirrorX2d.TabIndex = 11;
            this.button_MirrorX2d.Text = "По оси X";
            this.button_MirrorX2d.UseVisualStyleBackColor = true;
            this.button_MirrorX2d.Click += new System.EventHandler(this.button_MirrorX2d_Click);
            // 
            // button_MirrorY2d
            // 
            this.button_MirrorY2d.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_MirrorY2d.Location = new System.Drawing.Point(17, 68);
            this.button_MirrorY2d.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_MirrorY2d.Name = "button_MirrorY2d";
            this.button_MirrorY2d.Size = new System.Drawing.Size(118, 22);
            this.button_MirrorY2d.TabIndex = 12;
            this.button_MirrorY2d.Text = "По оси Y";
            this.button_MirrorY2d.UseVisualStyleBackColor = true;
            this.button_MirrorY2d.Click += new System.EventHandler(this.button_MirrorY2d_Click);
            // 
            // button_Rotation2d
            // 
            this.button_Rotation2d.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Rotation2d.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Rotation2d.Location = new System.Drawing.Point(1233, 185);
            this.button_Rotation2d.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Rotation2d.Name = "button_Rotation2d";
            this.button_Rotation2d.Size = new System.Drawing.Size(37, 25);
            this.button_Rotation2d.TabIndex = 13;
            this.button_Rotation2d.Text = "R";
            this.button_Rotation2d.UseVisualStyleBackColor = true;
            this.button_Rotation2d.Click += new System.EventHandler(this.button_Rotation2d_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(17, 92);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Maximum = 179;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(119, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 179;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label_Rotation2d
            // 
            this.label_Rotation2d.AutoSize = true;
            this.label_Rotation2d.Location = new System.Drawing.Point(54, 75);
            this.label_Rotation2d.Name = "label_Rotation2d";
            this.label_Rotation2d.Size = new System.Drawing.Size(0, 15);
            this.label_Rotation2d.TabIndex = 14;
            // 
            // button_Scale2D
            // 
            this.button_Scale2D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Scale2D.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Scale2D.Location = new System.Drawing.Point(1233, 214);
            this.button_Scale2D.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Scale2D.Name = "button_Scale2D";
            this.button_Scale2D.Size = new System.Drawing.Size(37, 25);
            this.button_Scale2D.TabIndex = 15;
            this.button_Scale2D.Text = "S";
            this.button_Scale2D.UseVisualStyleBackColor = true;
            this.button_Scale2D.Click += new System.EventHandler(this.button_Scale2D_Click);
            // 
            // button_ScaleIt2D
            // 
            this.button_ScaleIt2D.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_ScaleIt2D.Location = new System.Drawing.Point(17, 153);
            this.button_ScaleIt2D.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_ScaleIt2D.Name = "button_ScaleIt2D";
            this.button_ScaleIt2D.Size = new System.Drawing.Size(125, 22);
            this.button_ScaleIt2D.TabIndex = 16;
            this.button_ScaleIt2D.Text = "Масштабировать";
            this.button_ScaleIt2D.UseVisualStyleBackColor = true;
            this.button_ScaleIt2D.Click += new System.EventHandler(this.button_ScaleIt2D_Click);
            // 
            // textBox_ScaleK2D
            // 
            this.textBox_ScaleK2D.Location = new System.Drawing.Point(21, 128);
            this.textBox_ScaleK2D.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ScaleK2D.Name = "textBox_ScaleK2D";
            this.textBox_ScaleK2D.Size = new System.Drawing.Size(115, 23);
            this.textBox_ScaleK2D.TabIndex = 17;
            // 
            // button_AddCube
            // 
            this.button_AddCube.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AddCube.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_AddCube.Location = new System.Drawing.Point(1232, 268);
            this.button_AddCube.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_AddCube.Name = "button_AddCube";
            this.button_AddCube.Size = new System.Drawing.Size(37, 25);
            this.button_AddCube.TabIndex = 18;
            this.button_AddCube.Text = "С";
            this.button_AddCube.UseVisualStyleBackColor = true;
            this.button_AddCube.Click += new System.EventHandler(this.button_TrimetrPorekciya_Click);
            // 
            // button_trimetrProekc
            // 
            this.button_trimetrProekc.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_trimetrProekc.Location = new System.Drawing.Point(1232, 414);
            this.button_trimetrProekc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_trimetrProekc.Name = "button_trimetrProekc";
            this.button_trimetrProekc.Size = new System.Drawing.Size(37, 25);
            this.button_trimetrProekc.TabIndex = 19;
            this.button_trimetrProekc.Text = "Tr";
            this.button_trimetrProekc.UseVisualStyleBackColor = true;
            this.button_trimetrProekc.Click += new System.EventHandler(this.button_trimetrProekc_Click);
            // 
            // button_SetCoord
            // 
            this.button_SetCoord.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_SetCoord.Location = new System.Drawing.Point(16, 502);
            this.button_SetCoord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_SetCoord.Name = "button_SetCoord";
            this.button_SetCoord.Size = new System.Drawing.Size(131, 25);
            this.button_SetCoord.TabIndex = 20;
            this.button_SetCoord.Text = "Сохранить";
            this.button_SetCoord.UseVisualStyleBackColor = true;
            this.button_SetCoord.Click += new System.EventHandler(this.button_SetCoord_Click);
            // 
            // button_Rotate3D
            // 
            this.button_Rotate3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Rotate3D.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Rotate3D.Location = new System.Drawing.Point(1232, 297);
            this.button_Rotate3D.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Rotate3D.Name = "button_Rotate3D";
            this.button_Rotate3D.Size = new System.Drawing.Size(37, 25);
            this.button_Rotate3D.TabIndex = 21;
            this.button_Rotate3D.Text = "R";
            this.button_Rotate3D.UseVisualStyleBackColor = true;
            this.button_Rotate3D.Click += new System.EventHandler(this.button_Rotate3D_Click);
            // 
            // textBoxX
            // 
            this.textBoxX.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxX.Location = new System.Drawing.Point(78, 180);
            this.textBoxX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(38, 23);
            this.textBoxX.TabIndex = 22;
            // 
            // textBoxY
            // 
            this.textBoxY.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxY.Location = new System.Drawing.Point(78, 205);
            this.textBoxY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(38, 23);
            this.textBoxY.TabIndex = 23;
            // 
            // textBoxZ
            // 
            this.textBoxZ.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxZ.Location = new System.Drawing.Point(78, 230);
            this.textBoxZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(38, 23);
            this.textBoxZ.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(29, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(29, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Z";
            // 
            // labelTransform
            // 
            this.labelTransform.AutoSize = true;
            this.labelTransform.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTransform.Location = new System.Drawing.Point(21, 96);
            this.labelTransform.Name = "labelTransform";
            this.labelTransform.Size = new System.Drawing.Size(91, 15);
            this.labelTransform.TabIndex = 28;
            this.labelTransform.Text = "Сдвинуть по ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(102, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 15);
            this.label4.TabIndex = 34;
            this.label4.Text = "Z";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(60, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(17, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "X";
            // 
            // textBoxTransformZ
            // 
            this.textBoxTransformZ.Location = new System.Drawing.Point(102, 128);
            this.textBoxTransformZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTransformZ.Name = "textBoxTransformZ";
            this.textBoxTransformZ.Size = new System.Drawing.Size(43, 23);
            this.textBoxTransformZ.TabIndex = 31;
            // 
            // textBoxTransformY
            // 
            this.textBoxTransformY.Location = new System.Drawing.Point(60, 128);
            this.textBoxTransformY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTransformY.Name = "textBoxTransformY";
            this.textBoxTransformY.Size = new System.Drawing.Size(43, 23);
            this.textBoxTransformY.TabIndex = 30;
            // 
            // textBoxTransformX
            // 
            this.textBoxTransformX.Location = new System.Drawing.Point(17, 128);
            this.textBoxTransformX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTransformX.Name = "textBoxTransformX";
            this.textBoxTransformX.Size = new System.Drawing.Size(43, 23);
            this.textBoxTransformX.TabIndex = 29;
            // 
            // button_Transform3D
            // 
            this.button_Transform3D.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_Transform3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Transform3D.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Transform3D.Location = new System.Drawing.Point(1232, 326);
            this.button_Transform3D.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Transform3D.Name = "button_Transform3D";
            this.button_Transform3D.Size = new System.Drawing.Size(37, 25);
            this.button_Transform3D.TabIndex = 35;
            this.button_Transform3D.Text = "T";
            this.button_Transform3D.UseVisualStyleBackColor = false;
            this.button_Transform3D.Click += new System.EventHandler(this.button_Transform3D_Click);
            // 
            // button_doTransform3D
            // 
            this.button_doTransform3D.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_doTransform3D.Location = new System.Drawing.Point(14, 154);
            this.button_doTransform3D.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_doTransform3D.Name = "button_doTransform3D";
            this.button_doTransform3D.Size = new System.Drawing.Size(128, 22);
            this.button_doTransform3D.TabIndex = 36;
            this.button_doTransform3D.Text = "Выполнить";
            this.button_doTransform3D.UseVisualStyleBackColor = true;
            this.button_doTransform3D.Click += new System.EventHandler(this.button_doTransform3D_Click);
            // 
            // button_Mirror3D
            // 
            this.button_Mirror3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Mirror3D.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Mirror3D.Location = new System.Drawing.Point(1232, 356);
            this.button_Mirror3D.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Mirror3D.Name = "button_Mirror3D";
            this.button_Mirror3D.Size = new System.Drawing.Size(37, 25);
            this.button_Mirror3D.TabIndex = 37;
            this.button_Mirror3D.Text = "M";
            this.button_Mirror3D.UseVisualStyleBackColor = true;
            this.button_Mirror3D.Click += new System.EventHandler(this.button_Mirror3D_Click);
            // 
            // button_Mirror3dX
            // 
            this.button_Mirror3dX.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Mirror3dX.Location = new System.Drawing.Point(16, 40);
            this.button_Mirror3dX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Mirror3dX.Name = "button_Mirror3dX";
            this.button_Mirror3dX.Size = new System.Drawing.Size(118, 22);
            this.button_Mirror3dX.TabIndex = 38;
            this.button_Mirror3dX.Text = "По оси X";
            this.button_Mirror3dX.UseVisualStyleBackColor = true;
            this.button_Mirror3dX.Click += new System.EventHandler(this.button_Mirror3dX_Click);
            // 
            // button_Mirror3dY
            // 
            this.button_Mirror3dY.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Mirror3dY.Location = new System.Drawing.Point(17, 66);
            this.button_Mirror3dY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Mirror3dY.Name = "button_Mirror3dY";
            this.button_Mirror3dY.Size = new System.Drawing.Size(118, 22);
            this.button_Mirror3dY.TabIndex = 39;
            this.button_Mirror3dY.Text = "По оси Y";
            this.button_Mirror3dY.UseVisualStyleBackColor = true;
            this.button_Mirror3dY.Click += new System.EventHandler(this.button_Mirror3dY_Click);
            // 
            // button_Mirror3dZ
            // 
            this.button_Mirror3dZ.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Mirror3dZ.Location = new System.Drawing.Point(16, 95);
            this.button_Mirror3dZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Mirror3dZ.Name = "button_Mirror3dZ";
            this.button_Mirror3dZ.Size = new System.Drawing.Size(118, 22);
            this.button_Mirror3dZ.TabIndex = 40;
            this.button_Mirror3dZ.Text = "По оси Z";
            this.button_Mirror3dZ.UseVisualStyleBackColor = true;
            this.button_Mirror3dZ.Click += new System.EventHandler(this.button_Mirror3dZ_Click);
            // 
            // button_Scale3D
            // 
            this.button_Scale3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Scale3D.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Scale3D.Location = new System.Drawing.Point(1232, 385);
            this.button_Scale3D.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Scale3D.Name = "button_Scale3D";
            this.button_Scale3D.Size = new System.Drawing.Size(37, 25);
            this.button_Scale3D.TabIndex = 41;
            this.button_Scale3D.Text = "S";
            this.button_Scale3D.UseVisualStyleBackColor = true;
            this.button_Scale3D.Click += new System.EventHandler(this.button_Scale3D_Click);
            // 
            // button_Selection
            // 
            this.button_Selection.BackColor = System.Drawing.SystemColors.Control;
            this.button_Selection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Selection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Selection.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_Selection.Image = ((System.Drawing.Image)(resources.GetObject("button_Selection.Image")));
            this.button_Selection.Location = new System.Drawing.Point(1232, 23);
            this.button_Selection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Selection.Name = "button_Selection";
            this.button_Selection.Size = new System.Drawing.Size(37, 25);
            this.button_Selection.TabIndex = 42;
            this.button_Selection.UseVisualStyleBackColor = false;
            this.button_Selection.Click += new System.EventHandler(this.button_Selection_Click);
            // 
            // textBoxZc
            // 
            this.textBoxZc.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxZc.Location = new System.Drawing.Point(107, 230);
            this.textBoxZc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxZc.Name = "textBoxZc";
            this.textBoxZc.Size = new System.Drawing.Size(38, 23);
            this.textBoxZc.TabIndex = 47;
            // 
            // textBoxGamma
            // 
            this.textBoxGamma.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxGamma.Location = new System.Drawing.Point(107, 205);
            this.textBoxGamma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxGamma.Name = "textBoxGamma";
            this.textBoxGamma.Size = new System.Drawing.Size(38, 23);
            this.textBoxGamma.TabIndex = 46;
            // 
            // textBoxAlpha
            // 
            this.textBoxAlpha.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxAlpha.Location = new System.Drawing.Point(107, 180);
            this.textBoxAlpha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAlpha.Name = "textBoxAlpha";
            this.textBoxAlpha.Size = new System.Drawing.Size(38, 23);
            this.textBoxAlpha.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(58, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 15);
            this.label9.TabIndex = 50;
            this.label9.Text = "Zc";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(58, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 15);
            this.label10.TabIndex = 49;
            this.label10.Text = "∠g";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(58, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 15);
            this.label11.TabIndex = 48;
            this.label11.Text = "∠a";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(15, 254);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 25);
            this.button1.TabIndex = 51;
            this.button1.Text = "Выполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Save
            // 
            this.button_Save.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Save.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_Save.Image = ((System.Drawing.Image)(resources.GetObject("button_Save.Image")));
            this.button_Save.Location = new System.Drawing.Point(58, 6);
            this.button_Save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(37, 25);
            this.button_Save.TabIndex = 52;
            this.button_Save.UseVisualStyleBackColor = false;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Upload
            // 
            this.button_Upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Upload.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_Upload.Image = ((System.Drawing.Image)(resources.GetObject("button_Upload.Image")));
            this.button_Upload.Location = new System.Drawing.Point(101, 6);
            this.button_Upload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Upload.Name = "button_Upload";
            this.button_Upload.Size = new System.Drawing.Size(37, 25);
            this.button_Upload.TabIndex = 53;
            this.button_Upload.UseVisualStyleBackColor = true;
            this.button_Upload.Click += new System.EventHandler(this.button_Upload_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(1242, 251);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 15);
            this.label12.TabIndex = 54;
            this.label12.Text = "3D";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(1242, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 15);
            this.label13.TabIndex = 55;
            this.label13.Text = "2D";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(209, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 44;
            this.label8.Text = "Selection";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(144, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 43;
            this.label7.Text = "Режим:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1281, 538);
            this.Controls.Add(this.button_Mirror3dY);
            this.Controls.Add(this.button_Mirror3dX);
            this.Controls.Add(this.button_doTransform3D);
            this.Controls.Add(this.button_Mirror3dZ);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button_Upload);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxZc);
            this.Controls.Add(this.textBoxGamma);
            this.Controls.Add(this.textBoxAlpha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_Selection);
            this.Controls.Add(this.button_Scale3D);
            this.Controls.Add(this.button_Mirror3D);
            this.Controls.Add(this.button_Transform3D);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxTransformZ);
            this.Controls.Add(this.textBoxTransformY);
            this.Controls.Add(this.textBoxTransformX);
            this.Controls.Add(this.labelTransform);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxZ);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.button_Rotate3D);
            this.Controls.Add(this.button_SetCoord);
            this.Controls.Add(this.dataGridView_SetCoord);
            this.Controls.Add(this.button_trimetrProekc);
            this.Controls.Add(this.button_AddCube);
            this.Controls.Add(this.textBox_ScaleK2D);
            this.Controls.Add(this.button_ScaleIt2D);
            this.Controls.Add(this.button_Scale2D);
            this.Controls.Add(this.label_Rotation2d);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button_Rotation2d);
            this.Controls.Add(this.button_MirrorY2d);
            this.Controls.Add(this.button_MirrorX2d);
            this.Controls.Add(this.buttonMirror2d);
            this.Controls.Add(this.buttonTransform2d);
            this.Controls.Add(this.StopDrawing);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.ur);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SetCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ur;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonTransform2d;
        private System.Windows.Forms.Button StopDrawing;
        private System.Windows.Forms.Button buttonMirror2d;
        private System.Windows.Forms.Button button_MirrorX2d;
        private System.Windows.Forms.Button button_MirrorY2d;
        private System.Windows.Forms.Button button_Rotation2d;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label_Rotation2d;
        private System.Windows.Forms.Button button_Scale2D;
        private System.Windows.Forms.Button button_ScaleIt2D;
        private System.Windows.Forms.TextBox textBox_ScaleK2D;
        private System.Windows.Forms.Button button_AddCube;
        private System.Windows.Forms.Button button_trimetrProekc;
        private System.Windows.Forms.DataGridView dataGridView_SetCoord;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataGridViewTextBoxColumn z;
        private System.Windows.Forms.Button button_SetCoord;
        private System.Windows.Forms.Button button_Rotate3D;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTransform;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTransformZ;
        private System.Windows.Forms.TextBox textBoxTransformY;
        private System.Windows.Forms.TextBox textBoxTransformX;
        private System.Windows.Forms.Button button_Transform3D;
        private System.Windows.Forms.Button button_doTransform3D;
        private System.Windows.Forms.Button button_Mirror3D;
        private System.Windows.Forms.Button button_Mirror3dX;
        private System.Windows.Forms.Button button_Mirror3dY;
        private System.Windows.Forms.Button button_Mirror3dZ;
        private System.Windows.Forms.Button button_Scale3D;
        private System.Windows.Forms.Button button_Selection;
        private System.Windows.Forms.TextBox textBoxZc;
        private System.Windows.Forms.TextBox textBoxGamma;
        private System.Windows.Forms.TextBox textBoxAlpha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Upload;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

