using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace MatrOper
{
    public partial class Form1 : Form
    {

        private double[,] matrix;
        private int matrixSize;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Установка свойств DataGridView
            matrixDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            matrixDataGridView.EditingControlShowing += MatrixDataGridView_EditingControlShowing;
            matrixDataGridView.CellValidating += matrixDataGridView_CellValidating;


        }

        private void LoadMatrixFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    matrixSize = lines.Length;

                    if (matrixSize > 100)
                    {
                        MessageBox.Show("Размер матрицы превышает максимальный размер (100x100).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    matrix = new double[matrixSize, matrixSize];

                    for (int i = 0; i < matrixSize; i++)
                    {
                        string[] values = lines[i].Split(' ');

                        if (values.Length != matrixSize)
                        {
                            MessageBox.Show("Некорректный формат матрицы в файле. Матрица должна быть квадратной.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        for (int j = 0; j < matrixSize; j++)
                        {
                            if (!double.TryParse(values[j], out double element) || element < -100 || element > 100)
                            {
                                MessageBox.Show("Значение в матрице находится вне допустимого диапазона (-100;100).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            matrix[i, j] = element;
                        }
                    }

                    ShowMatrixInDataGridView(matrixDataGridView, matrix);

                    MessageBox.Show("Матрица успешно загружена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке матрицы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл с матрицей не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void calculateDeterminantButton_Click(object sender, EventArgs e)
        {
            if (matrix != null)
            {
                double determinant = CalculateDeterminant(matrix);
                MessageBox.Show("Определитель матрицы: " + determinant.ToString("F5"), "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Матрица не загружена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calculateInverseMatrixButton_Click(object sender, EventArgs e)
        {
            if (matrix != null)
            {
                double[,] inverseMatrix = CalculateInverseMatrix(matrix);

                if (inverseMatrix != null)
                {
                    ShowMatrixInDataGridView(resultDataGridView, inverseMatrix);
                    SaveMatrixToFile(inverseMatrix, "inverse_matrix.txt");

                    MessageBox.Show("Обратная матрица успешно вычислена.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Матрица необратима.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Матрица не загружена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double CalculateDeterminant(double[,] matrix)
        {
            int size = matrix.GetLength(0);
            double determinant = 0;

            if (size == 1)
            {
                determinant = matrix[0, 0];
            }
            else if (size == 2)
            {
                determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                for (int j = 0; j < size; j++)
                {
                    double[,] submatrix = new double[size - 1, size - 1];

                    for (int k = 1; k < size; k++)
                    {
                        for (int l = 0, m = 0; l < size; l++)
                        {
                            if (l != j)
                            {
                                submatrix[k - 1, m] = matrix[k, l];
                                m++;
                            }
                        }
                    }

                    determinant += Math.Pow(-1, j) * matrix[0, j] * CalculateDeterminant(submatrix);
                }
            }

            return determinant;
        }

        private double[,] CalculateInverseMatrix(double[,] matrix)
        {
            int size = matrix.GetLength(0);
            double determinant = CalculateDeterminant(matrix);

            if (determinant == 0)
            {
                return null; // Матрица необратима
            }

            double[,] inverseMatrix = new double[size, size];
            double[,] adjointMatrix = CalculateAdjointMatrix(matrix);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    inverseMatrix[i, j] = adjointMatrix[i, j] / determinant;
                }
            }

            return inverseMatrix;
        }

        private double[,] CalculateAdjointMatrix(double[,] matrix)
        {
            int size = matrix.GetLength(0);
            double[,] adjointMatrix = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    double[,] submatrix = new double[size - 1, size - 1];

                    for (int k = 0, m = 0; k < size; k++)
                    {
                        if (k != i)
                        {
                            for (int l = 0, n = 0; l < size; l++)
                            {
                                if (l != j)
                                {
                                    submatrix[m, n] = matrix[k, l];
                                    n++;
                                }
                            }

                            m++;
                        }
                    }

                    adjointMatrix[i, j] = Math.Pow(-1, i + j) * CalculateDeterminant(submatrix);
                }
            }

            return adjointMatrix;
        }

        private void ShowMatrixInDataGridView(DataGridView dataGridView, double[,] matrix)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            int size = matrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                dataGridView.Columns.Add($"column{i + 1}", $"Column {i + 1}");

                DataGridViewColumn column = dataGridView.Columns[i];
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridView.Rows.Add(size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (dataGridView == resultDataGridView)
                    {
                        dataGridView.Rows[j].Cells[i].Value = matrix[i, j].ToString("F5");
                    }
                    else if (dataGridView == matrixDataGridView)
                    {
                        dataGridView.Rows[j].Cells[i].Value = matrix[i, j].ToString("F0");
                    }
                }
            }
        }


        private void SaveMatrixToFile(double[,] matrix, string filePath)
        {
            int size = matrix.GetLength(0);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        writer.Write(matrix[i, j].ToString("F5"));

                        if (j < size - 1)
                        {
                            writer.Write(" ");
                        }
                    }

                    writer.WriteLine();
                }
            }
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    LoadMatrixFromFile(selectedFilePath);
                }
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (matrix != null)
            {
                double[,] inverseMatrix = CalculateInverseMatrix(matrix);

                if (inverseMatrix != null)
                {
                    PrintMatrix(inverseMatrix, "Обратная матрица");
                }
                else
                {
                    MessageBox.Show("Матрица необратима.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Матрица не загружена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PrintMatrix(double[,] matrix, string matrixName)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                int size = matrix.GetLength(0);
                Font font = new Font("Arial", 10);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

                e.Graphics.DrawString(matrixName, font, Brushes.Black, x, y);
                y += font.GetHeight();

                for (int i = 0; i < size; i++)
                {
                    string row = string.Empty;
                    for (int j = 0; j < size; j++)
                    {
                        row += string.Format("{0,10:F5}", matrix[i, j]);
                    }

                    e.Graphics.DrawString(row, font, Brushes.Black, x, y);
                    y += font.GetHeight();
                }
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }



        private void saveInverseMatrixButton_Click(object sender, EventArgs e)
        {
            if (matrix != null)
            {
                double[,] inverseMatrix = CalculateInverseMatrix(matrix);

                if (inverseMatrix != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                    saveFileDialog.Title = "Выберите место для сохранения обратной матрицы";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        SaveMatrixToFile(inverseMatrix, filePath);
                        MessageBox.Show("Обратная матрица успешно сохранена в файл.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Матрица необратима.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Матрица не загружена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerateRandomMatrix(int size, double minValue, double maxValue)
        {
            if (minValue == 0 && maxValue == 0)
            {
                matrix = new double[size, size];
            }
            else
            {
                Random random = new Random();
                matrix = new double[size, size];

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        matrix[i, j] = Math.Round(random.NextDouble() * (maxValue - minValue) + minValue, 1);
                    }
                }
            }

            ShowMatrixInDataGridView(matrixDataGridView, matrix);
            MessageBox.Show("Матрица успешно сгенерирована.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void GenerateMatrix_Click(object sender, EventArgs e)
        {
            int size = (int)numberInput.Value;
            double minValue = (double)minValueInput.Value;
            double maxValue = (double)maxValueInput.Value;

            if (size > 0)
            {
                GenerateRandomMatrix(size, minValue, maxValue);
            }
            else
            {
                MessageBox.Show("Размерность должна быть больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MatrixDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl textBoxEditingControl = e.Control as DataGridViewTextBoxEditingControl;

            if (textBoxEditingControl != null)
            {
                textBoxEditingControl.KeyPress -= MatrixDataGridView_KeyPress;
                textBoxEditingControl.KeyPress += MatrixDataGridView_KeyPress;
            }
        }

        private void matrixDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl editingControl)
            {
                editingControl.KeyPress += MatrixDataGridView_KeyPress;
            }
        }

        private void MatrixDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void matrixDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewCell cell = matrixDataGridView[e.ColumnIndex, e.RowIndex];
            string value = e.FormattedValue.ToString().Trim();

            if (!string.IsNullOrEmpty(value))
            {
                if (!double.TryParse(value, out double number))
                {
                    e.Cancel = true;
                    MessageBox.Show("Введено некорректное значение. Пожалуйста, введите число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (number < -100 || number > 100)
                {
                    e.Cancel = true;
                    MessageBox.Show("Значение должно быть в диапазоне от -100 до 100.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cell.Value = number.ToString("F0");
                    int rowIndex = e.RowIndex;
                    int columnIndex = e.ColumnIndex;
                    matrix[rowIndex, columnIndex] = number;
                }
            }
        }
    }
}
