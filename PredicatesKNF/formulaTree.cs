using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicatesKNF
{
    abstract class formula
    {
        public string name { get; set; }
        public abstract string toString();
    }

    class operand : formula
    {
        public override string toString()
        {
            return " " + this.name + " ";
        }
    }

    class predicate : operand
    {
        public string[] variables { get; set; }
        public override string toString()
        {
            return " " + this.name + "[" + string.Join(",", this.variables) + "] ";
        }
    }

    abstract class operatorLogic : formula
    {
        public formula[] formulas;
    }


    class unary : operatorLogic
    {

        public unary(formula f1, string name)
        {
            this.formulas = new formula[1];
            this.formulas[0] = f1;
            this.name = name;
        }

        public int demension { get { return 1; } }

        public override string toString()
        {
            return this.name + "(" + formulas[0].toString() + ")";
        }
    }

    class neg : unary
    {
        public neg(formula f1) : base(f1, "¬") { }

        public formula express()
        {
            //Двойное отрицание
            if (this.formulas[0] is neg)
            {
                return ((neg)this.formulas[0]).formulas[0];
            }

            //Де Морган

            if (this.formulas[0] is disjunkt)
            {
                return new konjunkt(new neg(((disjunkt)this.formulas[0]).formulas[0]), new neg(((disjunkt)this.formulas[0]).formulas[1]));
            }

            if (this.formulas[0] is konjunkt)
            {
                return new disjunkt(new neg(((konjunkt)this.formulas[0]).formulas[0]), new neg(((konjunkt)this.formulas[0]).formulas[1]));
            }

            //Законы отрицания кванторов

            if (this.formulas[0] is forall)
            {
                return new exists(new neg(((forall)this.formulas[0]).formulas[0]), ((forall)this.formulas[0]).formulas[1]);
            }

            if (this.formulas[0] is exists)
            {
                return new forall(new neg(((exists)this.formulas[0]).formulas[0]), ((exists)this.formulas[0]).formulas[1]);
            }

            return this;
        }
    }


    class binary : operatorLogic
    {
        public binary(formula f1, formula f2, string name)
        {
            this.formulas = new formula[2];
            this.formulas[0] = f1;
            this.formulas[1] = f2;
            this.name = name;
        }

        public int demension { get { return 2; } }

        public override string toString()
        {
            return "[" + formulas[1].toString() + "]" + this.name + "[" + formulas[0].toString() + "]";
        }
    }

    class implication : binary
    {
        public implication(formula f1, formula f2) : base(f1, f2, "→") { }


        public formula express()
        {
            //Представление импликации через коньюнкцию
            return new konjunkt(this.formulas[0], new neg(this.formulas[1]));
        }
    }

    class disjunkt : binary
    {
        public disjunkt(formula f1, formula f2) : base(f1, f2, "&") { }
        public override string toString()
        {
            return "[" + formulas[1].toString() + "] " + this.name + " [" + formulas[0].toString() + "]";
        }
    }

    class konjunkt : binary
    {
        public konjunkt(formula f1, formula f2) : base(f1, f2, "∨") { }

        public formula express()
        {
            //Дитрибутивность 

            if (this.formulas[0] is disjunkt)
            {
                return new disjunkt(new konjunkt(this.formulas[1], ((disjunkt)this.formulas[0]).formulas[0]), new konjunkt(this.formulas[1], ((disjunkt)this.formulas[0]).formulas[1]));
            }

            if (this.formulas[1] is disjunkt)
            {
                return new disjunkt(new konjunkt(this.formulas[0], ((disjunkt)this.formulas[1]).formulas[0]), new konjunkt(this.formulas[0], ((disjunkt)this.formulas[1]).formulas[1]));
            }

            return this;
        }

        public override string toString()
        {
            return  formulas[1].toString() + this.name  + formulas[0].toString() ;
        }
    }

    class quantor : operatorLogic
    {
        public quantor(formula fTemp, formula oTemp, string name)
        {
            this.formulas = new formula[2];
            this.formulas[0] = oTemp;
            this.formulas[1] = fTemp;
            this.name = name;
        }


        public int demension { get { return 2; } }

        public override string toString()
        {
            //Назвние квантора + переменная на которую действует + формула
            return this.name + formulas[1].toString() + "{" + formulas[0].toString() + "}";
        }

    }

    class forall : quantor
    {
        public forall(formula fTemp, formula oTemp) : base(oTemp, fTemp, "∀") { }
    }

    class exists : quantor
    {
        public exists(formula fTemp, formula oTemp) : base(oTemp, fTemp, "∃") { }
    }

    class formulaTree
    {

        string infixNotation;
        Stack<formula> ans;
        SortedDictionary<char, int> operatorsPritity;
        Stack<char> operatorStack;
        formula root;


        public formulaTree(string infixNotation)
        {
            this.infixNotation = infixNotation;

            ans = new Stack<formula>();
            operatorStack = new Stack<char>();

            operatorsPritity = new SortedDictionary<char, int>();
            operatorsPritity.Add('(', 1);
            operatorsPritity.Add(')', 2);
            //operatorsPritity.Add('↔',3);
            operatorsPritity.Add('→', 4);
            //operatorsPritity.Add('⊕',5);
            operatorsPritity.Add('∨', 6);
            operatorsPritity.Add('&', 7);
            operatorsPritity.Add('∃', 9);
            operatorsPritity.Add('∀', 8);
            operatorsPritity.Add('¬', 10);


            parse(infixNotation);
        }


        //КНФ
        public void KNF()
        {
            this.root = dfs(this.root);
        }

        //Преобразование в строку
        public string toString()
        {
            return this.root.toString();
        }

        //Парсинг
        void parse(string infixNotation)
        {
            for (int i = 0; i < infixNotation.Length; i++)
            {
                //Если символ разделитель
                if (isDelimiter(infixNotation[i]))
                    continue;

                //Если символ атом, т.е переменная
                if (isAtom(infixNotation[i]))
                {
                    //Считываем название переменной
                    string operand = "";

                    //Пока не встретим разделитель или оператор
                    while (!isDelimiter(infixNotation[i]) && !operatorsPritity.ContainsKey(infixNotation[i]))
                    {
                        operand += infixNotation[i];
                        i++;

                        if (i == infixNotation.Length) break;
                    }

                    //Вычитаем, иначе мы пропустим один символ для обработки
                    i--;

                    //Создаем объект опернд
                    operand oTemp = new operand();
                    oTemp.name = operand;                       //Имя операнда

                    //Закиним в стек
                    ans.Push(oTemp);

                    //postfixNotation += operand + " ";

                    //Иначе, если символ это предикат
                }
                else if (isPredicate(infixNotation[i]))
                {

                    //Считываем предикат
                    string predicate = "";

                    //Пока не начнется описание его аргументов
                    while (infixNotation[i] != '(')
                    {
                        predicate += infixNotation[i];
                        i++;
                    }
                    i++;

                    //Считаем его аргументы
                    string predicateVar = "";

                    //Пока не закончится их описание 
                    while (infixNotation[i] != ')')
                    {
                        predicateVar += infixNotation[i];
                        i++;
                    }

                    //TODO
                    //Прервартить строку в массив операндов

                    //Создаем объект предикат
                    predicate pTemp = new predicate();
                    pTemp.name = predicate;                     //Имя предиката
                    pTemp.variables = predicateVar.Split(',');

                    //Закинем в стек
                    ans.Push(pTemp);

                    //postfixNotation += predicate + "[" + predicateVar + "]" + " ";

                    //Иначе если символ оператор, квантор, скобки
                }
                else if (operatorsPritity.ContainsKey(infixNotation[i]))
                {
                    //Если откр. скобка
                    if (infixNotation[i] == '(')
                        //Закинем во временный стек операторов
                        operatorStack.Push(infixNotation[i]);
                    //Если закр скобка
                    else if (infixNotation[i] == ')')
                    {
                        //Достанем все операторы
                        char s = operatorStack.Pop();

                        //Пока не дойдем до откр. скобки
                        while (s != '(')
                        {
                            //postfixNotation += s.ToString() + " ";

                            //TODO
                            //Создать массив формул в зависимости от вида оператора
                            addToStack(ans, s);

                            s = operatorStack.Pop();
                        }
                    }
                    else
                    {
                        //Если временный стек не пусть
                        if (operatorStack.Count > 0)
                        {
                            //И приоритет тек. оператора <= приоритета оператора с вершины стека
                            //причем тек. опертор не равен оператору с вершины стека
                            if ((operatorsPritity[infixNotation[i]] <= operatorsPritity[operatorStack.Peek()]) &&
                               (infixNotation[i] != operatorStack.Peek()))
                            {
                                //То берем оператор у которого приоритет выше чем у тек. оператора 
                                char s = operatorStack.Pop();
                                addToStack(ans, s);
                            }


                        }

                        //В любом случае добавляем во временный стек, для дальнейшей обработки
                        operatorStack.Push(infixNotation[i]);
                    }
                }
            }

            while (operatorStack.Count > 0)
            {

                char s = operatorStack.Pop();
                addToStack(ans, s);
            }

            root = ans.Pop();
        }

        //Обход дерева
        static formula dfs(formula root)
        {

            //Если это отрицание
            if (root is neg)
            {
                //Идем вглубь
                root = new neg(dfs(((neg)root).formulas[0]));

                //Затем если его операнд формула
                if (!(((neg)root).formulas[0] is operand))
                {
                    //Преобразуем формулу по Де Моргану, убираем двойные отрицания и т.д
                    root = dfs(((neg)root).express());
                }

            }

            //Если это импликация
            if (root is implication)
            {
                //Идем вглубь
                root = new implication(dfs(((operatorLogic)root).formulas[0]), dfs(((operatorLogic)root).formulas[1]));
                //Представим импликацию, через коньюнкцию
                root = dfs(((implication)root).express());
            }

            //Если это коньюнкция
            if (root is konjunkt)
            {
                //Идем вглубь
                root = new konjunkt(dfs(((operatorLogic)root).formulas[0]), dfs(((operatorLogic)root).formulas[1]));

                //Для получения КНФ. Преобразуем формулу по закону дистрибутивности
                root = ((konjunkt)root).express();
            }

            //Если это дизьюнция
            if (root is disjunkt)
            {
                //Идем вглубь
                root = new disjunkt(dfs(((operatorLogic)root).formulas[0]), dfs(((operatorLogic)root).formulas[1]));
            }

            //Всеобщность
            if (root is forall)
            {
                //Идем вглубь
                root = new forall(dfs(((forall)root).formulas[0]), ((forall)root).formulas[1]);
            }

            //Существование
            if (root is exists)
            {
                //Идем вглубь
                root = new exists(dfs(((exists)root).formulas[0]), ((exists)root).formulas[1]);
            }

            return root;
        }

        //Создание дерева
        static void addToStack(Stack<formula> ans, char s)
        {
            formula temp = new operand();
            switch (s)
            {
                case '∀':
                    temp = new forall(ans.Pop(), ans.Pop());
                    break;
                case '∃':
                    temp = new exists(ans.Pop(), ans.Pop());
                    break;
                case '&':
                    temp = new disjunkt(ans.Pop(), ans.Pop());
                    break;
                case '∨':
                    temp = new konjunkt(ans.Pop(), ans.Pop());
                    break;
                case '→':
                    temp = new implication(ans.Pop(), ans.Pop());
                    break;
                case '¬':
                    temp = new neg(ans.Pop());
                    break;
            }

            //Закидоваем в стек
            ans.Push(temp);
        }

        //Это делитель
        static private bool isDelimiter(char c)
        {
            if (c == ' ')
            {
                return true;
            }

            return false;
        }

        //Это символ в нижнем регистре
        static private bool isAtom(char c)
        {
            if (("abcdxyz".IndexOf(c) != -1))
                return true;
            return false;
        }

        //Это символ в верхний регистр
        static private bool isPredicate(char c)
        {
            if (("ABCDEFPGWQ".IndexOf(c) != -1))
                return true;
            return false;
        }

    }

}
