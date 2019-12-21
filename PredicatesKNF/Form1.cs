using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PredicatesKNF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void тест1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //operatorsPritity.Add('(', 1);
            //operatorsPritity.Add(')', 2);
            ////operatorsPritity.Add('↔',3);
            //operatorsPritity.Add('→', 4);
            ////operatorsPritity.Add('⊕',5);
            //operatorsPritity.Add('∨', 6);
            //operatorsPritity.Add('&', 7);
            //operatorsPritity.Add('∃', 9);
            //operatorsPritity.Add('∀', 8);
            //operatorsPritity.Add('¬', 10);
            inputText.Text = "¬(∀x(F(x,y)))";
        }

        private void тест1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            inputText.Text = "¬(∀x(∃y(F(x,y)→P(x,y))))";
        }

        private void тест1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            inputText.Text = "∀x((¬( ¬( P(x) ∨ Q(x) ) ))  → ( ¬( G(x) → ∃y(F (x,y)) )))";
        }

        private void тест1ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            inputText.Text = "¬(∀x((¬(¬( P(x)  ∨ ¬(¬(Q (x))))))  →  (¬( G(x) → ∃y(F (x,y))))))";
        }

        private void тест1ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            inputText.Text = "(∃x(F(x)) & P(x,y) & Q(z)) ∨ ¬(∀y(G(y)))";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                formulaTree tree = new formulaTree(inputText.Text);
                formulaText.Text = tree.toString();
                tree.KNF();
                knfText.Text = tree.toString();
            }
            catch {
                MessageBox.Show("Проверьте корректно ли введена формула.\nВНИМАНИЕ заключайте в скобки область действия кванторов и операции отрицания.");
            }
            
        }

        private void inputText_TextChanged(object sender, EventArgs e)
        {
            string temp = inputText.Text;

            int pos = inputText.SelectionStart;
            int last = pos - 1;
            if (last >= 0)
            {

                if (temp[last] == '~')
                {
                    temp = temp.Remove(last, 1);
                    temp = temp.Insert(last, "¬");
                }

                if (temp[last] == '|')
                {
                    temp = temp.Remove(last, 1);
                    temp = temp.Insert(last, "∨");
                }

                if (temp[last] == '^')
                {
                    temp = temp.Remove(last, 1);
                    temp = temp.Insert(last, "→");
                }

                if (temp[last] == '*')
                {
                    temp = temp.Remove(last, 1);
                    temp = temp.Insert(last, "∀");
                }

                if (temp[last] == '!')
                {
                    temp = temp.Remove(last, 1);
                    temp = temp.Insert(last, "∃");
                }

                inputText.Text = temp;
                inputText.SelectionStart = pos;
            }
        }
    }
}
