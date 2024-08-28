namespace Bombones.Windows.Formularios
{
    partial class frmProveedoresAE
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedoresAE));
            btnCancelar = new Button();
            btnOk = new Button();
            txtProveedor = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtTelefono = new TextBox();
            label3 = new Label();
            txtMail = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(379, 176);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(64, 176);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 16;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(142, 36);
            txtProveedor.MaxLength = 50;
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(342, 23);
            txtProveedor.TabIndex = 14;
            txtProveedor.TextChanged += txtProveedor_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 39);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 13;
            label1.Text = "Proveedor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 77);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 13;
            label2.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(142, 74);
            txtTelefono.MaxLength = 50;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(342, 23);
            txtTelefono.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 118);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 13;
            label3.Text = "Mail:";
            // 
            // txtMail
            // 
            txtMail.Location = new Point(142, 115);
            txtMail.MaxLength = 50;
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(342, 23);
            txtMail.TabIndex = 14;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmProveedoresAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 251);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(txtMail);
            Controls.Add(label3);
            Controls.Add(txtTelefono);
            Controls.Add(label2);
            Controls.Add(txtProveedor);
            Controls.Add(label1);
            MaximumSize = new Size(570, 290);
            MinimumSize = new Size(570, 290);
            Name = "frmProveedoresAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProveedoresAE";
            Load += frmProveedoresAE_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnOk;
        private TextBox txtProveedor;
        private Label label1;
        private Label label2;
        private TextBox txtTelefono;
        private Label label3;
        private TextBox txtMail;
        private ErrorProvider errorProvider1;
    }
}