using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator {
    class Calculate {
        public string GetResult(string str) {
            string op = "+-*/()";
            Hashtable priority = new Hashtable();
            priority.Add("+", "0");
            priority.Add("-", "0");
            priority.Add("*", "1");
            priority.Add("/", "1");
            priority.Add("(", "2");
            priority.Add(")", "2");

            List<string> expList = new List<string>(); // expList will store operand and operator with string type
            int start = 0;
            for (int i=0; i<str.Length; i++) { // change str into expList
                if(op.Contains(str[i])) {
                    if(i != 0 && str[i-1] == ')') {
                        expList.Add(str[i].ToString());
                        start = i + 1;
                        continue;
                    }
                    if(str[start] == '(') {
                        expList.Add("(");
                        start = i + 1;
                        continue;
                    }
                    
                    expList.Add(str.Substring(start, i-start));
                    expList.Add(str[i].ToString());
                    start = i + 1;
                    
                }
            }
            if(start < str.Length) expList.Add(str.Substring(start));

            //foreach (string s in expList) {
              //  MessageBox.Show(s);
            //}

            List<string> postfix = new List<string>();
            Stack<string> S = new Stack<string>();
            try {
                foreach (string s in expList) { // infix to postfix
                    if (!op.Contains(s)) {
                        postfix.Add(s);
                    } else if (s == ")") {
                        string y;
                        do {
                            y = S.Pop();
                            //MessageBox.Show(y);
                            if (y != "(") postfix.Add(y);
                        } while (y != "(");
                    } else {
                        if (S.Count == 0) { // for fear that S is empty
                            S.Push(s);
                            continue;
                        }
                        if (S.Peek() == "(") { // the priority of "(" in stack must be the least
                            S.Push(s);
                            continue;
                        }
                        if (Convert.ToInt32(priority[s]) > Convert.ToInt32(priority[S.Peek()])) {
                            S.Push(s);
                        } else {
                            string y;
                            do {
                                y = S.Pop();
                                postfix.Add(y);
                                if (S.Count == 0) break;
                            } while (Convert.ToInt32(priority[s]) <= Convert.ToInt32(priority[S.Peek()]));
                            S.Push(s);
                        }
                    }
                }
                while (S.Count != 0) { // clear S
                    string y = S.Pop();
                    postfix.Add(y);
                }
            }catch(Exception e) {
                MessageBox.Show("Error!! please check expression ");
                return "";
            }
            
 
            return calPostfix(postfix, op);
            
        }

        private string calPostfix(List<string> postfix, string op) { //calculate postfix
            Stack<string> S = new Stack<string>();
            foreach(string s in postfix) {
                if(!op.Contains(s)) {
                    S.Push(s);
                }else {
                    switch(s) {
                        case "+":
                            S.Push((float.Parse(S.Pop()) + float.Parse(S.Pop())).ToString());
                            break;
                        case "-":
                            float a = float.Parse(S.Pop());
                            float b = float.Parse(S.Pop());
                            S.Push((b - a).ToString());
                            break;
                        case "*":
                            S.Push((float.Parse(S.Pop()) * float.Parse(S.Pop())).ToString());
                            break;
                        case "/":
                            if(int.Parse(S.Peek()) == 0) {
                                MessageBox.Show("Error!! divide by zero");
                                return "";
                            } 
                            S.Push((1/(float.Parse(S.Pop()) / float.Parse(S.Pop()))).ToString());
                            break;
                    }
                }
            }

            return S.Pop();
        }
    }
}
