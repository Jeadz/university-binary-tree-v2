using System;
using System.Collections.Generic;
using System.Text;

namespace university_binary_tree_v2
{
    class UTree
    {
        public PositionNode Root;
        public int Count = 0;
        public float LongestSalary = 0;

        public void CreatePosition(PositionNode parent, Position positionToCreate, string parentPositionName)
        {
            PositionNode newNode = new PositionNode();
            newNode.Position = positionToCreate;

            if(Root == null)
            {
                Root = newNode;
                return;
            }

            if(parent == null)
            {
                return;
            }

            if(parent.Position.Name == parentPositionName)
            {
                if(parent.Left == null)
                {
                    parent.Left = newNode;
                    return;
                }
                parent.Right = newNode;
                return;
            }

            CreatePosition(parent.Left, positionToCreate, parentPositionName);
            CreatePosition(parent.Right, positionToCreate, parentPositionName);
        }

        public void PrintTree(PositionNode from)
        {
            if(from == null)
            {
                return;
            }

            Console.WriteLine($"{from.Position.Name} : ${from.Position.Salary}");
            
            PrintTree(from.Left);
            PrintTree(from.Right);
        }

        public float AddSalaries(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }

            return from.Position.Salary + AddSalaries(from.Left) + AddSalaries(from.Right);
        }

        // Get the longest salary (without including "the principal".

        public void TottalLongestSalary(PositionNode from)
        {
            if (from == null)
            {
                return;
            }
            if (from.Position != Root.Position && from.Position.Salary > LongestSalary)
            {
                LongestSalary = from.Position.Salary;
            }
            TottalLongestSalary(from.Left);
            TottalLongestSalary(from.Right);
        }

        //Calculate the salary average

        public float CountEmployees(PositionNode from)
        {
            if (from == null)
            {
                return Count;
            }
            Count++;
            CountEmployees(from.Left);
            return CountEmployees(from.Right);
        }

        public float Average()
        {
            return AddSalaries(Root) / CountEmployees(Root);
        }

        // How much is the salary given a certain position (e.g. "Vicerector financiero")
        public float SalaryPosition(PositionNode from, string name)
        {
            if (from == null)
            {
                return 0;
            }
            if (from.Position.Name == name)
            {
                return from.Position.Salary;
            }
            return SalaryPosition(from.Left, name) + SalaryPosition(from.Right, name);
        }

        //How much money is total taxes
        public double TotalTaxes(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }
            return (from.Position.Salary * from.Position.Tax) + TotalTaxes(from.Left) + TotalTaxes(from.Right);
        }
    }
}
