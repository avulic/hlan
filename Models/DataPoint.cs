using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HLAN.Models
{
	[DataContract]
	public class DataPoint
    {
		public DataPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		[DataMember(Name = "x")]
		public double X { get; set; }

		[DataMember(Name = "y")]
		public double Y { get; set; }
	}
}
