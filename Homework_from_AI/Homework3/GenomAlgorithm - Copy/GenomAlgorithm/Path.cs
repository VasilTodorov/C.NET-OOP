using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomAlgorithm
{
    public class Path
    {
		//private readonly int SIZE;
		private PointInPath[]? chain;
		
		#region Constructors
		public Path(PointInPath[] chain)
		{
			Chain = chain;
		}

		public Path() : this(new PointInPath[0])
		{

		}
		public Path(Path path) : this(path.Chain)
		{

		} 
		#endregion
		#region Properties
		public PointInPath this[int index]
		{
			get
				=> index >= 0 && index < chain!.Length ? new PointInPath(chain[index]) : new PointInPath();
		}
		public PointInPath[] Chain
		{
			get
			{
				PointInPath[] copyChain = new PointInPath[chain!.Length];
				for (int i = 0; i < chain.Length; i++)
				{
					copyChain[i] = new PointInPath(chain[i]);
				}
				return copyChain;
			}
			set
			{

				if (value != null)
				{
					chain = new PointInPath[value.Length];

                    for (int i = 0; i < value.Length; i++)
					{
						chain![i] = new PointInPath(value[i]);
					}
				}
				else
				{
					chain = new PointInPath[0];

				}
			}
		}
        #endregion

		public Path GetChildTwoPointCrossOver(Path parent)
		{
			if(chain!.Length == 0) return new Path();

			Stack<Point> stack = new Stack<Point>();
			var childChain = Chain;
			Random r = new Random();
			int id;
			int index;

			//r.Next(0);
			int i = r.Next(chain!.Length/2);
			int j = r.Next(chain!.Length/2, chain.Length+1);
			if(i == chain!.Length / 2) i = 0;
			if(j == chain!.Length+1) j = chain.Length;
            //Console.WriteLine($"i= {i}, j= {j}");
            for (id = i; id < j; id++) 
			{
				stack.Push(this[id]);
            }
			index = j;
            for (; id < chain.Length; id++)
            {
				if (!stack.Contains(parent[id]))
				{
                    childChain[index] = parent[id];
					index++;
				}
				
            }
            for (id = 0; id < j; id++)
            {
				if (index == chain.Length) index = 0;
                if (!stack.Contains(parent[id]))
                {
                    childChain[index] = parent[id];
                    index++;
                }

            }

			return new Path(childChain);
        }

		public void MutationOfPath()
		{
			if(chain!.Length == 0) return;
            Random r = new Random();
			int i = r.Next(chain.Length);
            int j = r.Next(chain.Length);
            //Console.WriteLine($"Mutation: i={i}, j={j}");
            PointInPath temp = new PointInPath(chain[i]);
			chain[i] = new PointInPath(chain[j]);
			chain[j] = temp;
        }
		public double CalculatePath()
		{
			double distance = 0;
			Point currentPoint;

            if (chain!.Length > 0)
                currentPoint = new Point(chain[0]);	//currentPoint
			else
				return distance;
			for(int i = 1; i < chain.Length; i++) 
			{
				distance += currentPoint.DistanceTo(chain[i]);
                currentPoint = new Point(chain[i]);
            }

			return distance;
		}
        public override string ToString()
        {
			string str = "[";
			for(int i = 0; i < chain!.Length-1; i++) 
			{
				str+= chain[i].ToString()  + ", ";
			}
			str += chain[chain.Length - 1].ToString()  + "]" + $"({CalculatePath():F4})";
            return str;
        }
    }
}
