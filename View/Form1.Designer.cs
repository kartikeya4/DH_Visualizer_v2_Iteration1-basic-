namespace DH_Visualizer_v2
{
    partial class Form1
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
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.DH_Parameter_Grid = new System.Windows.Forms.DataGridView();
            this.Theta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alpha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joint_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DH_Parameter_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1074, 570);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // DH_Parameter_Grid
            // 
            this.DH_Parameter_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DH_Parameter_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Theta,
            this.D,
            this.A,
            this.Alpha,
            this.joint_type});
            this.DH_Parameter_Grid.Location = new System.Drawing.Point(109, 576);
            this.DH_Parameter_Grid.Name = "DH_Parameter_Grid";
            this.DH_Parameter_Grid.RowHeadersWidth = 170;
            this.DH_Parameter_Grid.RowTemplate.Height = 24;
            this.DH_Parameter_Grid.Size = new System.Drawing.Size(812, 150);
            this.DH_Parameter_Grid.TabIndex = 1;
            this.DH_Parameter_Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Theta
            // 
            this.Theta.HeaderText = "Theta ";
            this.Theta.MinimumWidth = 6;
            this.Theta.Name = "Theta";
            this.Theta.Width = 125;
            // 
            // D
            // 
            this.D.HeaderText = "Link Offest";
            this.D.MinimumWidth = 6;
            this.D.Name = "D";
            this.D.Width = 125;
            // 
            // A
            // 
            this.A.HeaderText = "Link Length";
            this.A.MinimumWidth = 6;
            this.A.Name = "A";
            this.A.Width = 125;
            // 
            // Alpha
            // 
            this.Alpha.HeaderText = "Alpha";
            this.Alpha.MinimumWidth = 6;
            this.Alpha.Name = "Alpha";
            this.Alpha.Width = 125;
            // 
            // joint_type
            // 
            this.joint_type.HeaderText = "Joint Type(R/P)";
            this.joint_type.MinimumWidth = 6;
            this.joint_type.Name = "joint_type";
            this.joint_type.Width = 125;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(927, 576);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(147, 55);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 803);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.DH_Parameter_Grid);
            this.Controls.Add(this.elementHost1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DH_Parameter_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.DataGridView DH_Parameter_Grid;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Theta;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
        private System.Windows.Forms.DataGridViewTextBoxColumn A;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alpha;
        private System.Windows.Forms.DataGridViewTextBoxColumn joint_type;
    }
}

