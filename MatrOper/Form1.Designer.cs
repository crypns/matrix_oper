using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace MatrOper
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
            this.calculateDeterminantButton = new System.Windows.Forms.Button();
            this.calculateInverseMatrixButton = new System.Windows.Forms.Button();
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.saveInverseMatrixButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.GenerateMatrix = new System.Windows.Forms.Button();
            this.numberInput = new System.Windows.Forms.NumericUpDown();
            this.minValueInput = new System.Windows.Forms.NumericUpDown();
            this.maxValueInput = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.matrixDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minValueInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxValueInput)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matrixDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // calculateDeterminantButton
            // 
            this.calculateDeterminantButton.Location = new System.Drawing.Point(11, 44);
            this.calculateDeterminantButton.Name = "calculateDeterminantButton";
            this.calculateDeterminantButton.Size = new System.Drawing.Size(132, 20);
            this.calculateDeterminantButton.TabIndex = 1;
            this.calculateDeterminantButton.Text = "Определитель матрицы";
            this.calculateDeterminantButton.UseVisualStyleBackColor = true;
            this.calculateDeterminantButton.Click += new System.EventHandler(this.calculateDeterminantButton_Click);
            // 
            // calculateInverseMatrixButton
            // 
            this.calculateInverseMatrixButton.Location = new System.Drawing.Point(11, 19);
            this.calculateInverseMatrixButton.Name = "calculateInverseMatrixButton";
            this.calculateInverseMatrixButton.Size = new System.Drawing.Size(132, 20);
            this.calculateInverseMatrixButton.TabIndex = 2;
            this.calculateInverseMatrixButton.Text = "Обратная матрица";
            this.calculateInverseMatrixButton.UseVisualStyleBackColor = true;
            this.calculateInverseMatrixButton.Click += new System.EventHandler(this.calculateInverseMatrixButton_Click);
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.AllowUserToAddRows = false;
            this.resultDataGridView.AllowUserToDeleteRows = false;
            this.resultDataGridView.AllowUserToResizeColumns = false;
            this.resultDataGridView.AllowUserToResizeRows = false;
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.ColumnHeadersVisible = false;
            this.resultDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultDataGridView.Location = new System.Drawing.Point(3, 16);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.RowHeadersVisible = false;
            this.resultDataGridView.RowTemplate.Height = 25;
            this.resultDataGridView.Size = new System.Drawing.Size(465, 467);
            this.resultDataGridView.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(6, 19);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(137, 20);
            this.selectFileButton.TabIndex = 5;
            this.selectFileButton.Text = "Загрузка из файла";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(11, 19);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(132, 20);
            this.printButton.TabIndex = 8;
            this.printButton.Text = "Печать";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // saveInverseMatrixButton
            // 
            this.saveInverseMatrixButton.Location = new System.Drawing.Point(11, 44);
            this.saveInverseMatrixButton.Name = "saveInverseMatrixButton";
            this.saveInverseMatrixButton.Size = new System.Drawing.Size(132, 20);
            this.saveInverseMatrixButton.TabIndex = 9;
            this.saveInverseMatrixButton.Text = "Сохранить в файл";
            this.saveInverseMatrixButton.UseVisualStyleBackColor = true;
            this.saveInverseMatrixButton.Click += new System.EventHandler(this.saveInverseMatrixButton_Click);
            // 
            // GenerateMatrix
            // 
            this.GenerateMatrix.Location = new System.Drawing.Point(5, 133);
            this.GenerateMatrix.Name = "GenerateMatrix";
            this.GenerateMatrix.Size = new System.Drawing.Size(127, 20);
            this.GenerateMatrix.TabIndex = 10;
            this.GenerateMatrix.Text = "Сгенерировать";
            this.GenerateMatrix.UseVisualStyleBackColor = true;
            this.GenerateMatrix.Click += new System.EventHandler(this.GenerateMatrix_Click);
            // 
            // numberInput
            // 
            this.numberInput.Location = new System.Drawing.Point(5, 32);
            this.numberInput.Name = "numberInput";
            this.numberInput.Size = new System.Drawing.Size(127, 20);
            this.numberInput.TabIndex = 11;
            // 
            // minValueInput
            // 
            this.minValueInput.Location = new System.Drawing.Point(5, 108);
            this.minValueInput.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.minValueInput.Name = "minValueInput";
            this.minValueInput.Size = new System.Drawing.Size(127, 20);
            this.minValueInput.TabIndex = 12;
            // 
            // maxValueInput
            // 
            this.maxValueInput.Location = new System.Drawing.Point(5, 70);
            this.maxValueInput.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.maxValueInput.Name = "maxValueInput";
            this.maxValueInput.Size = new System.Drawing.Size(127, 20);
            this.maxValueInput.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.resultDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(629, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 486);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обратная  матрица:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.matrixDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(158, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 486);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Исходная матрица:";
            // 
            // matrixDataGridView
            // 
            this.matrixDataGridView.AllowUserToAddRows = false;
            this.matrixDataGridView.AllowUserToDeleteRows = false;
            this.matrixDataGridView.AllowUserToResizeColumns = false;
            this.matrixDataGridView.AllowUserToResizeRows = false;
            this.matrixDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrixDataGridView.ColumnHeadersVisible = false;
            this.matrixDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrixDataGridView.Location = new System.Drawing.Point(3, 16);
            this.matrixDataGridView.Name = "matrixDataGridView";
            this.matrixDataGridView.RowHeadersVisible = false;
            this.matrixDataGridView.RowTemplate.Height = 25;
            this.matrixDataGridView.Size = new System.Drawing.Size(465, 467);
            this.matrixDataGridView.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(159, 486);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Управление";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.printButton);
            this.groupBox7.Controls.Add(this.saveInverseMatrixButton);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 301);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(153, 75);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Вывод";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.calculateInverseMatrixButton);
            this.groupBox6.Controls.Add(this.calculateDeterminantButton);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 227);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(153, 74);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Вычисление";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.selectFileButton);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(153, 211);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ввод";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.GenerateMatrix);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.minValueInput);
            this.groupBox4.Controls.Add(this.numberInput);
            this.groupBox4.Controls.Add(this.maxValueInput);
            this.groupBox4.Location = new System.Drawing.Point(6, 45);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(137, 161);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Рандомная генерация";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Размерность:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Минимальное значение:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Максимальное значение:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 486);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "ВЫЧИСЛЕНИЕ ОПРЕДЕЛИТЕЛЯ МАТРИЦЫ N * N И ОБРАТНОЙ МАТРИЦЫ";
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minValueInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxValueInput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.matrixDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button calculateDeterminantButton;
        private Button calculateInverseMatrixButton;
        private DataGridView matrixDataGridView;
        private DataGridView resultDataGridView;
        private OpenFileDialog openFileDialog1;
        private Button selectFileButton;
        private Button printButton;
        private Button saveInverseMatrixButton;
        private SaveFileDialog saveFileDialog1;
        private Button GenerateMatrix;
        private NumericUpDown numberInput;
        private NumericUpDown minValueInput;
        private NumericUpDown maxValueInput;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox7;
        private GroupBox groupBox6;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
    }
}