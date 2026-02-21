#define USERCHECK
// See https://aka.ms/new-console-template for more information
using CoderByte.SimulatedTest;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

#if FATORIAL

static int FirstFactorial(int num)
{

    // code goes here  
    if (num == 1)
    {
        return num;
    }
    else
    {
        return num * FirstFactorial(num - 1);
    }
}
        
Console.WriteLine("Insira um número inteiro");

try
{
    int num = int.Parse(Console.ReadLine());
    Console.WriteLine(FirstFactorial(num));
}
catch (Exception ex)
{
    Console.WriteLine("Não é um número inteiro");
}

#endif

#if LONGESTSTRIG
Console.WriteLine(LonguestWord.LongestWord("fun&!! time for love@"));

#endif

#if TREE
TreeNode root = new TreeNode(1);
TreeNode node2 = new TreeNode(root, 2);
TreeNode node3 = new TreeNode(node2 , 3);
TreeNode node4 = new TreeNode(node2, 4);
TreeNode node5 = new TreeNode(node3, 5);
TreeNode node6 = new TreeNode(node3, 6);
TreeNode node7 = new TreeNode(node4, 7);

TreeNode.ReadTreeFromAboveToBelow(root);
TreeNode.ReadTreeFromBelowToAbove(node7);

static string TreeConstructor2(params string[] strArr)
{
    if (strArr.Length == 0)
        return "false";

    Dictionary<int,int> tree = new Dictionary<int, int>();
    foreach (string s in strArr)
    {
        string[] str = Regex.Replace(s, @"[^\d,]", string.Empty).Split(',');

        int keyValue = int.Parse(str[0]);
        int parentValue = int.Parse(str[1]);

        //se o nó já existe ou se o pai já tem 2 filhos, retorna false
        if (tree.ContainsKey(keyValue) || tree.Values.Count<int>(x => x == parentValue) >= 2)
        {
            return "false";
        }
        else
        {
            //adiciona o nó e seu pai na árvore
            tree.Add(keyValue, parentValue);
        }  
    }
    return "true";
}



//invalido
Console.WriteLine(TreeConstructor2("1,0","2,1","3,2","4,2","5,4","6,4","7,4"));
//valido
Console.WriteLine(TreeConstructor2("1,0", "2,1", "3,2", "4,2", "5,4", "6,4"));
#endif

#if USERCHECK

Console.WriteLine(Codeland.CodelandUsernameValidation("aa_"));
Console.WriteLine(Codeland.CodelandUsernameValidation("u__hello"));


#endif

Console.WriteLine(QuestionMarks.QuestionsMarks("arrb6???4xxbl5???eee5"));

Console.WriteLine(BacketMatcher.IsMatch("(hello (world))"));

string pattern = "ade";
Console.WriteLine(MinWindow.MinWindowSubstring("aaabacaddae", pattern));

Console.WriteLine("### end ###");
Console.ReadLine();