using System.Windows;
using Formula;

namespace FormulaTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Test1_Click(object sender, RoutedEventArgs e)
        {
            Test_1();
        }

        private void Test_1()
        {
            List<Formula.Expression>? expressions = null;
            string? text = null;
            Command? command = null;

            //text = "=IF(\"AB)\"; \"C;D\"; \"AAA{}AA\") + 10  + [AAAA] + AND(2 + 5; \"{sss}\"; {\"A\"; 10; 11})";

            //command = Create.Command(text);
            //expressions = command.GetExpressions();

            //List<Tuple<bool, char>> tuples = new List<Tuple<bool, char>>();
            //for(int i =0; i < text.Length; i++)
            //{
            //    tuples.Add(new Tuple<bool, char>(Query.Quoted(text, i), text[i]));
            //}

            //text = "=IF([someName])";
            //command = Create.Command(text);
            //expressions = command.GetExpressions();

            //text = "=IF(IF(2<3; True; False); 10; 5)";
            //command = Create.Command(text);
            //expressions = command.GetExpressions();

            //text = "=IF(IF(2<3; True; False); [Some Parameter] * 10; 5)";
            //text = "=IF([Some Parameter] * 10; 5)";
            //text = "=[ZONE AREA] * LOOKUP([FLOOR COVERING]; {\"Thin natural stone\", \"Thick natural stone\"}; {1.05, 1.10}; 0)";

            //text = "={\"Thin natural stone\", \"Thick natural stone\"}";

            //command = Create.Command(text);
            //expressions = command.GetExpressions();

            //if (expressions != null && expressions.Count > 0)
            //{
            //    foreach (Formula.Expression expression in expressions)
            //    {
            //        List<Formula.Expression> expressions_Temp = expression?.GetExpressions();
            //    }
            //}

            FormulaCalculator formulaManager = new FormulaCalculator();

            //text = "=[ZONE AREA] * 2 * {1.05, 1.10}";
            text = "=IF(2<3; [ZONE AREA] * 10; 20)";
            command = Create.Command(text);
            if(command.TryGetValue(new TestObject(), out object result))
            {

            }

            Query.Value("[Some Parameter] * 10", out string @out, out ExpressionType expressionType);
        }
    }
}