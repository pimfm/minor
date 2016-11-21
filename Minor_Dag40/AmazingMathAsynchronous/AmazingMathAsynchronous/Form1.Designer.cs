namespace AmazingMathAsynchronous
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
            this.intInput1 = new System.Windows.Forms.NumericUpDown();
            this.intInput3 = new System.Windows.Forms.NumericUpDown();
            this.intInput2 = new System.Windows.Forms.NumericUpDown();
            this.btnSumOfSquares = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.intInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intInput3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intInput2)).BeginInit();
            this.SuspendLayout();
            // 
            // intInput1
            // 
            this.intInput1.Location = new System.Drawing.Point(69, 26);
            this.intInput1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intInput1.Name = "intInput1";
            this.intInput1.Size = new System.Drawing.Size(120, 20);
            this.intInput1.TabIndex = 0;
            this.intInput1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intInput1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // intInput3
            // 
            this.intInput3.Location = new System.Drawing.Point(69, 78);
            this.intInput3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intInput3.Name = "intInput3";
            this.intInput3.Size = new System.Drawing.Size(120, 20);
            this.intInput3.TabIndex = 1;
            this.intInput3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // intInput2
            // 
            this.intInput2.Location = new System.Drawing.Point(69, 52);
            this.intInput2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intInput2.Name = "intInput2";
            this.intInput2.Size = new System.Drawing.Size(120, 20);
            this.intInput2.TabIndex = 2;
            this.intInput2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSumOfSquares
            // 
            this.btnSumOfSquares.Location = new System.Drawing.Point(69, 116);
            this.btnSumOfSquares.Name = "btnSumOfSquares";
            this.btnSumOfSquares.Size = new System.Drawing.Size(120, 23);
            this.btnSumOfSquares.TabIndex = 3;
            this.btnSumOfSquares.Text = "Sum of squares";
            this.btnSumOfSquares.UseVisualStyleBackColor = true;
            this.btnSumOfSquares.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(69, 160);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(120, 20);
            this.txtOutput.TabIndex = 4;
            this.txtOutput.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnSumOfSquares);
            this.Controls.Add(this.intInput2);
            this.Controls.Add(this.intInput3);
            this.Controls.Add(this.intInput1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.intInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intInput3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intInput2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown intInput1;
        private System.Windows.Forms.NumericUpDown intInput3;
        private System.Windows.Forms.NumericUpDown intInput2;
        private System.Windows.Forms.Button btnSumOfSquares;
        private System.Windows.Forms.TextBox txtOutput;
    }
}

