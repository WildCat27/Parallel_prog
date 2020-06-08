using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
using System.IO;

namespace Генератор_задач
{
    public partial class Form1 : Form
    {
        public List<string> paths = new List<string>();
        public Form1()
        {
            InitializeComponent();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\path_list.txt"))
            {
                using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\path_list.txt"))
                    while (!reader.EndOfStream) paths.Add(reader.ReadLine());
                foreach (string str in paths) filepath.Items.Add(str);
            }
        }

        void put(DocX tasks, DocX answers, string task, string answer)
        {
            Paragraph p = tasks.InsertParagraph(task);
            p.SpacingAfter(10);
            p = answers.InsertParagraph(task);
            p.SpacingAfter(5);
            p = answers.InsertParagraph("Ответ: " + answer + ".");
            p.SpacingAfter(10);
        }

        void generate(DocX tasks, DocX answers)
        {
            var rand = new Random();
            

            long combinations(int k, int n)
            {
                long result = 1;
                if (k > n - k)
                {
                    for (int i = n; i > k; i--) result *= i;
                    for (int i = 1; i <= n - k; i++) result /= i;
                }
                else
                {
                    for (int i = n; i > n - k; i--) result *= i;
                    for (int i = 1; i <= k; i++) result /= i;
                }
                return result;
            }

            #region first task
            {
                int total = rand.Next(15, 30) * 10;
                int defective = rand.Next(2, 5) * 10;
                int taken = rand.Next(2, 10);

                string task =
                    $"1. На завод привезли партию из {total} подшипников, в которую случайно попало {defective} бракованных. " +
                    $"Определить вероятность того, что из {taken}-х взятых наугад подшипников оба окажутся годными.";

                double solution = Math.Round(Convert.ToDouble(combinations(taken, total - defective)) / combinations(taken, total), 5);

                put(tasks, answers, task, solution.ToString());
            }
            #endregion

            #region second task
            {
                int total_white = rand.Next(3, 6) * 5;
                int total_black = rand.Next(1, 4) * 5;
                int taken = rand.Next(5, 10);
                int taken_white = rand.Next(2, 4);

                string task =
                    $"2. В урне {total_white} белых и {total_black} черных шаров. Наудачу отобраны {taken} шаров. Найти вероятность того, что среди них окажется ровно {taken_white} белых шара.";

                double solution = Math.Round((double)combinations(taken_white, total_white) * combinations(taken - taken_white, total_black) / combinations(taken, total_black + total_white), 5);

                put(tasks, answers, task, solution.ToString());
            }
            #endregion

            #region third task
            {
                int taken = rand.Next(5, 10);

                string task =
                    $"3. В колоде 32 карты. Наугад вынимают {taken} карт. Найти вероятность того, что среди них окажется хотя бы одна дама.";

                double solution = Math.Round((double)combinations(taken, 28) / combinations(taken, 32), 5);

                put(tasks, answers, task, solution.ToString());
            }
            #endregion

            #region fourth task
            {
                int taken = rand.Next(2, 4);

                string task =
                    $"4. Из колоды в 52 карты вынимают одновременно {taken} карты. Событие А - среди вынутых карт хотя бы одна бубновая, В - хотя бы одна червонная. Найти Р(А+В).";

                double solution = Math.Round(1 - combinations(taken, 26) / (double)combinations(taken, 52), 5);

                put(tasks, answers, task, solution.ToString());
            }
            #endregion

            #region fifth task
            {
                double p1 = rand.Next(1, 10) * 0.01;
                double p2 = rand.Next(1, 10) * 0.01;
                double p3 = rand.Next(1, 10) * 0.01;
                double p4 = rand.Next(1, 10) * 0.01;

                string task =
                    $"5. Узел автомашины состоит из 4 деталей. Вероятности выхода из строя этих деталей соответственно равны: р1 = {p1}; р2 = {p2}; р3 = {p3}; p4 = {p4}. " +
                    $"Узел выходит из строя, если выходит из строя хотя бы одна деталь. Найти вероятность того, что узел не выйдет из строя, если детали выходят из строя независимо друг от друга.";

                double solution = Math.Round((1 - p1) * (1 - p2) * (1 - p3) * (1 - p4), 5);

                put(tasks, answers, task, solution.ToString());
            }
            #endregion

            #region sixth task
            {
                double p1 = rand.Next(4, 7) * 0.1;
                double p2 = rand.Next(3, 5) * 0.1;
                double p3 = rand.Next(5, 8) * 0.01;

                string task =
                    $"6. Для разрушения моста достаточно попадания одной авиационной бомбы. " +
                    $"Найти вероятность того, что мост будет разрушен, если на него сбросить 3 бомбы, вероятности попадания которых соответственно равны: р1 = {p1}, р2 = {p2}, р3 = {p3}";

                double solution = Math.Round(1 - (1 - p1) * (1 - p2) * (1 - p3), 5);

                put(tasks, answers, task, solution.ToString());
            }
            #endregion

            #region seventh task
            {
                int total = rand.Next(2, 5);

                string task =
                    $"7. Опыт заключается в последовательном бросании {total} монет. Событие А - выпадение хотя бы одного орла, событие B - выпадения хотя бы одной решки. Определить Р(А/В).";

                double solution = 0;
                for (int i = 1; i < total; i++) solution += combinations(i, total);
                solution = Math.Round(Math.Pow(1.0 / 2, total) * solution / (Math.Pow(1.0 / 2, total) * solution + Math.Pow(1.0 / 2, total)), 5);

                put(tasks, answers, task, solution.ToString());
            }
            #endregion

            #region eigth task
            {
                int box1 = rand.Next(2, 3) * 5;
                int box2 = rand.Next(3, 5) * 5;
                int white1 = rand.Next(6, 9);
                int white2 = rand.Next(3, 7);

                string task =
                    $"8. В первой урне содержится {box1} шаров, из них {white1} белых, во второй {box2} шаров, из них {white2} белых. " +
                    $"Из каждой урны наудачу извлекли по одному шару, а затем из этих двух шаров наудачу взят один шар. Найти вероятность того, что взят белый шар.";

                double solution = Math.Round(0.5 * (Convert.ToDouble(white1) / box1 + Convert.ToDouble(white1) / box2), 5);

                put(tasks, answers, task, solution.ToString());
            }
            #endregion

            #region ninth task
            {
                double p1 = rand.Next(4, 7) * 0.1;
                double p2 = rand.Next(3, 5) * 0.1;
                double p3 = rand.Next(5, 8) * 0.1;

                string task =
                    $"9. Батарея из трех орудий произвела залп, причем два снаряда попали в цель. " +
                    $"Найти вероятность того, что первое орудие дало попадание, если вероятности попадания в цель первым, вторым и третьим соответственно равны p1 = {p1}, p2 = {p2}, p3 = {p3}.";

                double solution = Math.Round(p1 * (p2 * (1 - p3) + (1 - p2) * p3) / (p1 * (p2 * (1 - p3) + (1 - p2) * p3) + (1 - p1) * p2 * p3), 5);

                put(tasks, answers, task, solution.ToString());
            }
            #endregion

            #region tenth task
            {
                int total = rand.Next(5, 7);
                int fallen = rand.Next(2, 4);

                string task =
                    $"10. Игральная кость бросается {total} раз. Найти вероятность того, что три очка выпадут {fallen} раза.";

                double solution = Math.Round(combinations(fallen, total) * Math.Pow(1.0 / 6, fallen) * Math.Pow(5.0 / 6, total - fallen), 5);

                put(tasks, answers, task, solution.ToString());
                tasks.InsertSectionPageBreak();
                answers.InsertSectionPageBreak();
            }
            #endregion
            
            #region eleventh and twelth tasks
            {
                double p1 = rand.Next(2, 4) * 0.05, x1 = - rand.Next(9, 10) * 0.1;
                double p2 = rand.Next(3, 6) * 0.05, x2 = - rand.Next(7, 8) * 0.1;
                double p3 = rand.Next(2, 5) * 0.05, x3 = - rand.Next(5, 6) * 0.1;
                double p4 = rand.Next(1, 3) * 0.05, x4 = - rand.Next(3, 4) * 0.1;
                double p5 = 1 - p1 - p2 - p3 - p4, x5 = - rand.Next(1, 2) * 0.1;

                Paragraph p = tasks.InsertParagraph("11. Случайная величина имеет следующее распределение вероятностей:");
                p.SpacingAfter(5);
                answers.InsertParagraph(p);

                var table = tasks.AddTable(2, 6);
                table.Rows[0].Cells[0].Paragraphs[0].Append("x");
                table.Rows[1].Cells[0].Paragraphs[0].Append("p(x)");
                table.Rows[0].Cells[1].Paragraphs[0].Append(x1.ToString());
                table.Rows[1].Cells[1].Paragraphs[0].Append(p1.ToString());
                table.Rows[0].Cells[2].Paragraphs[0].Append(x2.ToString());
                table.Rows[1].Cells[2].Paragraphs[0].Append(p2.ToString());
                table.Rows[0].Cells[3].Paragraphs[0].Append(x3.ToString());
                table.Rows[1].Cells[3].Paragraphs[0].Append(p3.ToString());
                table.Rows[0].Cells[4].Paragraphs[0].Append(x4.ToString());
                table.Rows[1].Cells[4].Paragraphs[0].Append(p4.ToString());
                table.Rows[0].Cells[5].Paragraphs[0].Append(x5.ToString());
                table.Rows[1].Cells[5].Paragraphs[0].Append(p5.ToString());
                table.SetWidths(new float[] { 40F, 40F, 40F, 40F, 40F, 40F });

                string solution_11 = $"\n\tF(x) = 0 при x <= {x1};\n" +
                    $"\tF(x) = {p1} при {x1} < x <= {x2};\n" +
                    $"\tF(x) = {p1 + p2} при {x2} < x <= {x3};\n" +
                    $"\tF(x) = {p1 + p2 + p3} при {x3} < x <= {x4};\n" +
                    $"\tF(x) = {p1 + p2 + p3 + p4} при {x4} < x <= {x5};\n" +
                    $"\tF(x) = 1 при x > {x5}.";

                string task_12 =
                    $"12. Найти математическое ожидание, дисперсию и квадратичное отклонение случайной величины x примера 11.";
                double mat = Math.Round(x1 * p1 + x2 * p2 + x3 * p3 + x4 * p4 + x5 * p5, 5);
                double dis = Math.Round(x1 * x1 * p1 + x2 * x2 * p2 + x3 * x3 * p3 + x4 * x4 * p4 + x5 * x5 * p5 - mat * mat, 5);

                string solution_12 = $"M(x)={mat}, D(x)={dis}, σ(x)={Math.Sqrt(dis)}";

                tasks.InsertTable(table);
                answers.InsertTable(table);
                
                p = tasks.InsertParagraph("Построить многоугольник распределения и найти функцию распределения F(x).");
                p.SpacingBefore(5);
                p.SpacingAfter(10);
                p = answers.InsertParagraph("Построить многоугольник распределения и найти функцию распределения F(x).");
                p.SpacingBefore(5);
                p.SpacingAfter(5);
                p = answers.InsertParagraph("Ответ: " + solution_11);
                p.SpacingAfter(10);

                put(tasks, answers, task_12, solution_12);

            }
            #endregion

            #region thirteenth and forteenth tasks
            {
                int bound = 0;
                int pow = 0;
                string pow_string1 = "";
                string pow_string2 = "";
                int var1 = rand.Next(1, 3);
                int var2 = rand.Next(1, 2);

                switch(var1)
                {
                    case 1: { pow = 1; pow_string1 = ""; pow_string2 = "\u00B2"; break; }
                    case 2: { pow = 2; pow_string1 = "\u00B2"; pow_string2 = "\u00B3"; break; }
                    case 3: { pow = 3; pow_string1 = "\u00B3"; pow_string2 = "\u2074"; break; }
                }
                switch(var2)
                {
                    case 1: { bound = 1; break; }
                    case 2: { bound = 2; break; }
                }

                string task_13 =
                    $"13. x - непрерывная случайная величина с плотностью распределения ϕ(x), заданной функцией: " +
                    $"ϕ(x) = -Ax{pow_string1}, если x принадлежит промежутку (0; {bound}], и ϕ(x) = 0 в противном случае.";

                pow++;
                double A = pow / Math.Pow(bound, pow);

                string solution_13 = $"\n\tF(x) = 0 при x <= 0;\n" +
                    $"\tF(x) = {A/pow}x{pow_string2} при 0 < x <= {bound};\n" +
                    $"\tF(x) = {bound * A / pow} при x > {bound}";

                string task_14 =
                    $"14. x - непрерывная величина из примера 13. Найти математическое ожидание, дисперсию и квадратичное отклонение.";

                double mat = Math.Round(A / (pow + 1) * Math.Pow(bound, pow + 1), 5);
                double dis = Math.Round(A / (pow + 2) * Math.Pow(bound, pow + 2) - mat * mat, 5);
                string solution_14 =
                    $"M(x) = {mat}, " +
                    $"D(x) = {dis}, " +
                    $"σ(x) = {Math.Round(Math.Sqrt(dis), 5)}";

                put(tasks, answers, task_13, solution_13);
                put(tasks, answers, task_14, solution_14);

            }
            #endregion

            #region fifteenth task
            {
                int number = rand.Next(2, 5) * 10;

                string task =
                    $"15. Вероятность рождения мальчика равна 0,51. Найти вероятность того, что среди 100 новорожденных окажется {number} мальчиков.";

                string solution = $"0.2ϕ({0.2 * (number - 51)})";

                put(tasks, answers, task, solution.ToString());
            }
            #endregion

            #region sixteenth task
            {
                double sigma = rand.Next(1, 2) * 0.1;
                double e = rand.Next(1, 4) * 0.1;

                string task =
                    $"16. x - нормально распределенная случайная величина с параметрами а = 1, σ = {sigma}.\nНайти Р(|x - 1|< {e}).";

                string solution = $"2Φ({Math.Round(e / sigma, 5)})";
                put(tasks, answers, task, solution.ToString());
            }
            #endregion

            #region seventeenth task
            {
                int total = rand.Next(5, 8) * 25;
                int number = rand.Next(2, 4) * 25;

                string task =
                    $"17. Цех выпускает в среднем 80% продукции высшего качества. Какова вероятность того, что в партии из {total} изделий будет больше {number} изделий высшего качества.";

                string solution = $"Φ({Math.Round((total - total * 0.8) / (0.4 * Math.Sqrt(total)), 5)}) - Φ({Math.Round((number - total * 0.8) / (0.4 * Math.Sqrt(total)), 5)})";

                put(tasks, answers, task, solution.ToString());
            }
            #endregion

            #region eighteenth task
            {
                double a1 = rand.Next(0, 2) * 0.1;
                double a2 = rand.Next(1, 3) * 0.1;
                double a3 = rand.Next(1, 2) * 0.1;
                double a4 = rand.Next(0, 1) * 0.1;
                double a5 = rand.Next(1, 2) * 0.1;
                double a6 = 1 - a1 - a2 - a3 - a4 - a5;

                Paragraph p = tasks.InsertParagraph("18. Дана таблица распределения вероятностей двумерной случайной величины (ξ,η):");
                p.SpacingAfter(5);
                answers.InsertParagraph(p);

                var table = tasks.AddTable(3, 4);
                table.Rows[0].Cells[0].Paragraphs[0].Append("ξ\\η");
                table.Rows[1].Cells[0].Paragraphs[0].Append("0");
                table.Rows[2].Cells[0].Paragraphs[0].Append("1");
                table.Rows[0].Cells[1].Paragraphs[0].Append("-1");
                table.Rows[1].Cells[1].Paragraphs[0].Append(a1.ToString());
                table.Rows[2].Cells[1].Paragraphs[0].Append(a4.ToString());
                table.Rows[0].Cells[2].Paragraphs[0].Append("0");
                table.Rows[1].Cells[2].Paragraphs[0].Append(a2.ToString());
                table.Rows[2].Cells[2].Paragraphs[0].Append(a5.ToString());
                table.Rows[0].Cells[3].Paragraphs[0].Append("1");
                table.Rows[1].Cells[3].Paragraphs[0].Append(a3.ToString());
                table.Rows[2].Cells[3].Paragraphs[0].Append(a6.ToString());
                table.SetWidths(new float[] { 40F, 40F, 40F, 40F});

                double Me = a4 + a5 + a6;
                double De = Me - Me * Me;
                double Mn = -1 * (a1 + a4) + (a3 + a6);
                double Dn = a1 + a4 + a3 + a6;
                double Men = -a4 + a6;
                double Den = a4 + a6 - Men * Men;

                string solution = $"M(ξ) = {Me}, M(η) = {Mn}, D(ξ) = {De}, D(η) = {Dn}, M(ξη) = {Men}, D(ξη) = {Den}";

                tasks.InsertTable(table);
                answers.InsertTable(table);
                p = tasks.InsertParagraph("Найти M(ξ), M(η), D(ξ), D(η), M(ξη), D(ξη).");
                p.SpacingBefore(5);
                p.SpacingAfter(10);
                p = answers.InsertParagraph("Найти M(ξ), M(η), D(ξ), D(η), M(ξη), D(ξη).");
                p.SpacingBefore(5);
                p.SpacingAfter(5);

                p = answers.InsertParagraph("Ответ: " + solution + ".");
                p.SpacingAfter(10);
            }
            #endregion
            
    
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (numberVars.Text == "" || filename.Text == "" || filepath.Text == "")
            {
                MessageBox.Show("Введите данные");
                return;
            }
            int number = Convert.ToInt32(numberVars.Text);
            if (number > 100)
            {
                MessageBox.Show("Максимальное количество вариантов 100");
                return;
            }
            if (!Directory.Exists(filepath.Text))
            {
                MessageBox.Show("Директория " + filepath.Text + " не существует");
                return;
            }
            if (File.Exists(filepath.Text + "\\" + filename.Text + ".docx"))
            {
                DialogResult result = MessageBox.Show("Файл с таким названием уже существует.\nПерезаписать?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
            }

            if (!filepath.Items.Contains(filepath.Text))
            {
                filepath.Items.Add(filepath.Text);
                paths.Add(filepath.Text);
            }
            

            // создаём документ
            DocX task_document = DocX.Create(filepath.Text + "\\" + filename.Text + ".docx");
            DocX answer_document = DocX.Create(filepath.Text + "\\" + filename.Text + "_ответы.docx");
            
            for (int var_number = 1; var_number <= number; var_number++)
            {
                Paragraph p = task_document.InsertParagraph(var_number.ToString() + " вариант");
                p.FontSize(16);
                p.SpacingAfter(20);
                answer_document.InsertParagraph(p);
                generate(task_document, answer_document);
                if (var_number != number)
                {
                    task_document.InsertSectionPageBreak();
                    answer_document.InsertSectionPageBreak();
                }
            }

            // сохраняем документ
            task_document.Save();
            answer_document.Save();

            MessageBox.Show("   Генерация успешно выполнена ★");

        }

        private void filename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8) return;
            else
                e.Handled = true;
        }


        private void numberVars_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void filepathButton_Click(object sender, EventArgs e)
        {
            string filepath_string = "";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                filepath_string = folderBrowserDialog.SelectedPath;
            filepath.Text = filepath_string;
        }

        private void filepath_TextChanged(object sender, EventArgs e)
        {
            if (filepath.SelectedItem != null) return;
            filepath.Items.Clear();
            foreach (string str in paths)
            {
                if (str.ToUpper().Contains(filepath.Text.ToUpper()))
                    filepath.Items.Add(str);
            }
            filepath.DroppedDown = true;
            Cursor.Current = Cursors.Default;
            filepath.SelectionStart = filepath.Text.Length;
        }
        private void form_closing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\path_list.txt", false))
                foreach (string str in paths) writer.WriteLine(str);
                
        }

        private void item1_Click(object sender, EventArgs e)
        {
            paths.Clear();
        }

        private void item2_Click(object sender, EventArgs e)
        {
            string message = "Введите в соотвествующие поля необходимые данные и нажмите <Сгенерировать>.\n" +
                "В выбранную вами папку будут сохранены два файла: имя_файла.docx, содержащий условия задач, и имя_файла_ответы.docx, содержащий условия задач с ответами.";
            MessageBox.Show(message, "Справка", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void item3_Click(object sender, EventArgs e)
        {
            string message = "Условия задач взяты из 30 варианта типового расчета.\n" +
                "Автор: Шишкина Д. О. 26 группа\n" +
                "2020 год";
            MessageBox.Show(message, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
