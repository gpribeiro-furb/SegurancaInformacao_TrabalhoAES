namespace CriptografiaAES
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
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            checkBox1 = new CheckBox();
            button3 = new Button();
            label4 = new Label();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(25, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(574, 27);
            textBox1.TabIndex = 0;
            textBox1.Text = "C:/Testes/teste.txt";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 23);
            label1.Name = "label1";
            label1.Size = new Size(264, 20);
            label1.TabIndex = 1;
            label1.Text = "Caminho do arquivo para criptografar:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(623, 46);
            button1.Name = "button1";
            button1.Size = new Size(130, 29);
            button1.TabIndex = 2;
            button1.Text = "Selecionar...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(25, 271);
            button2.Name = "button2";
            button2.Size = new Size(130, 29);
            button2.TabIndex = 3;
            button2.Text = "Criptografar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 91);
            label2.Name = "label2";
            label2.Size = new Size(532, 20);
            label2.TabIndex = 5;
            label2.Text = "Chave de segurança: (Exemplo: 20,1,94,33,199,0,48,9,31,94,112,40,59,30,100,248)";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(25, 114);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(728, 27);
            textBox2.TabIndex = 4;
            textBox2.Text = "65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 202);
            label3.Name = "label3";
            label3.Size = new Size(197, 20);
            label3.TabIndex = 7;
            label3.Text = "Caminho do arquivo destino";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(25, 225);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(574, 27);
            textBox3.TabIndex = 6;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(25, 165);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(304, 24);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Pedir caminho do destino ao criptografar";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(623, 225);
            button3.Name = "button3";
            button3.Size = new Size(130, 29);
            button3.TabIndex = 9;
            button3.Text = "Selecionar...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 319);
            label4.Name = "label4";
            label4.Size = new Size(194, 20);
            label4.TabIndex = 10;
            label4.Text = "Resultado em Hexadecimal:";
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox4.Location = new Point(25, 351);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(728, 134);
            textBox4.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 497);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(checkBox1);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Criptografia AES";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private CheckBox checkBox1;
        private Button button3;
        private Label label4;
        private TextBox textBox4;
    }
}