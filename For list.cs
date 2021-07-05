using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace IHateSharp
{	
	
	class Abit
	{
		public string Name;
		public string SecName;
		public string SurName;
		public string Balls;
		public void Info()
		{
			string v=String.Format("{0} {1} {2}: {3} баллов",Name,SecName,SurName,Balls);
			if (v!="  :  баллов"){Console.WriteLine(v);}
				
		}
		public string Sovpad()
		{
			return Name+SecName+SurName+Balls;
		}
		
	}
    class Program
    {
        static void Main(string[] args)
        {
			int count=0;
			string Iskl="по результатам ВИ, проводимых организацией самостоятельно";
			string path = @"C:\Users\Discream\Documents\CSharp\List.txt";
			using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					if (!(line.Contains(Iskl) || line.Contains(" форма ")))
					{
						count++;
					}
				}
			}
			Console.WriteLine(count);
			Abit[] Abits = new Abit[count];
			count=0;
			using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					if (!(line.Contains(Iskl) || line.Contains(" форма ")))
					{
						string[] words = line.Split(',',':');
						string NWord=words[3].Replace(" ","").Replace(".00","");
						string word=String.Format("{0} {1}",words[0],NWord);
						string[] Nemesis=words[0].Split(' ');
						string TimeName = Convert.ToString(count);
						Abit SomeAbit=new Abit();
						SomeAbit.SecName=Nemesis[0];
						SomeAbit.Name=Nemesis[1];
						SomeAbit.SurName=Nemesis[2];
						SomeAbit.Balls=NWord;
						Abits[count]=SomeAbit;
						count++;
					}
				}
			}
			for (int i=0;i<Abits.Length;i++)
			{
				for (int j=i+1;j<Abits.Length;j++)
				{
					if (Abits[i].Sovpad()==Abits[j].Sovpad())
					{
						Abits[j]=new Abit();
					}
				}
			}
			Abit temp=new Abit();
            for (int i = 0; i < Abits.Length-1; i++)
            {
                for (int j = i + 1; j < Abits.Length; j++)
                {
                    if (Convert.ToInt32(Abits[i].Balls) < Convert.ToInt32(Abits[j].Balls))
                    {
                        temp = Abits[i];
                        Abits[i] = Abits[j];
                        Abits[j] = temp;
                    }
                }
            }
			for (int i=0;i<Abits.Length;i++)
			{
				Abits[i].Info();
			}
        }
	}
}

