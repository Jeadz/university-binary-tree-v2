using System;

namespace university_binary_tree_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Position rectorPosition = new Position();
            rectorPosition.Name = "Rector";
            rectorPosition.Salary = 1000;
            rectorPosition.Tax = 0.35F;

            Position vicFinPosition = new Position();
            vicFinPosition.Name = "Vic.Fin";
            vicFinPosition.Salary = 750;
            vicFinPosition.Tax = 0.25F;

            Position contadorPosition = new Position();
            contadorPosition.Name = "Contador";
            contadorPosition.Salary = 500;
            contadorPosition.Tax = 0.15F;

            Position JefeFinPosition = new Position();
            JefeFinPosition.Name = "Jefe  Financ";
            JefeFinPosition.Salary = 610;
            JefeFinPosition.Tax = 0.10F;

            Position secFin1Position = new Position();
            secFin1Position.Name = "Secrec1";
            secFin1Position.Salary = 350;
            secFin1Position.Tax = 0.05F;

            Position secFin2Position = new Position();
            secFin2Position.Name = "Secrec2";
            secFin2Position.Salary = 310;
            secFin2Position.Tax = 0.05F;

            Position vicAcadPosition = new Position();
            vicAcadPosition.Name = "Vic.Acad";
            vicAcadPosition.Salary = 780;
            vicAcadPosition.Tax = 0.25F;

            Position jefereg = new Position();
            jefereg.Name = "Jefe Reg ";
            jefereg.Salary = 640;
            jefereg.Tax = 0.20f;

            Position sectreg2 = new Position();
            sectreg2.Name = "Sectreg2";
            sectreg2.Salary = 360;
            sectreg2.Tax = 0.05f;

            Position sectreg1 = new Position();
            sectreg1.Name = "Sectreg1";
            sectreg1.Salary = 400;
            sectreg1.Tax = 0.05F;

            Position asist2 = new Position();
            asist2.Name = "Asistente 2";
            asist2.Salary = 170;
            asist2.Tax = 0.02F;

            Position mensajero = new Position();
            mensajero.Name = "Mensajero";
            mensajero.Salary = 90;
            mensajero.Tax = 0.02F;

            Position asist1 = new Position();
            asist1.Name = "Asist1";
            asist1.Salary = 250;
            asist1.Tax = 0.01F;

            UTree universityTree = new UTree();

            universityTree.CreatePosition(null, rectorPosition, null);
            universityTree.CreatePosition(universityTree.Root, vicFinPosition, rectorPosition.Name);

            universityTree.CreatePosition(universityTree.Root, contadorPosition, vicFinPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secFin1Position, contadorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secFin2Position, contadorPosition.Name);

            universityTree.CreatePosition(universityTree.Root, JefeFinPosition, vicFinPosition.Name);

            universityTree.CreatePosition(universityTree.Root, vicAcadPosition, rectorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, jefereg, vicAcadPosition.Name);
            universityTree.CreatePosition(universityTree.Root, sectreg2, jefereg.Name);

            universityTree.CreatePosition(universityTree.Root, sectreg1, jefereg.Name);
            universityTree.CreatePosition(universityTree.Root, asist2, sectreg1.Name);
            universityTree.CreatePosition(universityTree.Root, mensajero, asist2.Name);

            universityTree.CreatePosition(universityTree.Root, asist1, sectreg1.Name);
            universityTree.PrintTree(universityTree.Root);
            float totalSalary = universityTree.AddSalaries(universityTree.Root);
            Console.WriteLine($"Total salaries: {totalSalary}");

            universityTree.TottalLongestSalary(universityTree.Root);
            Console.WriteLine($"The best salary is: {universityTree.LongestSalary}");

            float SalaryAverage = universityTree.Average();
            Console.WriteLine($" the salary average is: {SalaryAverage}");



            Console.WriteLine("whose salary do you want to know?");
            String find = Console.ReadLine();
            float salaryForPosition = universityTree.SalaryPosition(universityTree.Root, find);
            if (salaryForPosition == 0)
            {
                Console.WriteLine("the name is not valid");
            }
            else
            {
                Console.WriteLine($"this person's salary is: {salaryForPosition}");
            }

            double totalTaxes = universityTree.TotalTaxes(universityTree.Root);
            Console.WriteLine($"Total Taxes: {totalTaxes}");

        }
    }
}
