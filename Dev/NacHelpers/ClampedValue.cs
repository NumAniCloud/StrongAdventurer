using System;

namespace NacHelpers
{
	public class ClampedValue<T> where T : struct, IComparable
	{
		private T value_, min_, max_;

		public T Value
		{
			get { return value_; }
			set
			{
				value_ = value;
				Update();
			}
		}
		public T Min
		{
			get { return min_; }
			set
			{
				if(value.CompareTo(Max) == 1)
				{
					throw new Exception("�ő�l���傫�Ȓl���ŏ��l�Ɏw�肳��܂����B");
				}
				min_ = value;
				Update();
			}
		}
		public T Max
		{
			get { return max_; }
			set
			{
				if(value.CompareTo(Min) == -1)
				{
					throw new Exception("�ŏ��l��菬���Ȓl���ő�l�Ɏw�肳��܂����B");
				}
				max_ = value;
				Update();
			}
		}

		public ClampedValue(T value, T min, T max)
		{
			min_ = min;
			max_ = max;
			value_ = value;
			Update();
		}

		private void Update()
		{
			if(Value.CompareTo(Min) == -1)
			{
				Value = Min;
			}
			else if(Value.CompareTo(Max) == 1)
			{
				Value = Max;
			}
		}
	}
}