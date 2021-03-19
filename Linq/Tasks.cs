using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Objects;

namespace Linq {
	public static class Tasks {
		//The implementation of your tasks should look like this:
		public static string TaskExample(IEnumerable<string> stringList) {
			return stringList.Aggregate((x, y) => x + y);
		}

		#region Low

		public static IEnumerable<string> Task1(char c, IEnumerable<string> stringList) {
			return stringList.Where(x => x.StartsWith(c) && x.EndsWith(c) && x.Length > 2);
		}

		public static IEnumerable<int> Task2(IEnumerable<string> stringList) {
			return stringList.Select(x => x.Length).OrderBy(x => x);
		}

		public static IEnumerable<string> Task3(IEnumerable<string> stringList) {
			return stringList.Select(x => x.First().ToString() + x.Last());
		}

		public static IEnumerable<string> Task4(int k, IEnumerable<string> stringList) {
			return stringList.
			Select(x => x).
			Where(x => x.Length == k && char.IsDigit(x.Last())).
			OrderBy(x => x);
		}

		public static IEnumerable<string> Task5(IEnumerable<int> integerList) {
			return integerList.
			Select(x => x.ToString()).
			Where(x => int.Parse(x) % 2 != 0).
			OrderBy(x => int.Parse(x));
		}

		#endregion

		#region Middle

		public static IEnumerable<string> Task6(IEnumerable<int> numbers, IEnumerable<string> stringList) {

			return numbers.Aggregate(new List<string>(), (result, item) => {
				result.Add(stringList.FirstOrDefault(x => x.Length == item && char.IsDigit(x[0])) ?? "Not found");
				return result;
			}).AsQueryable();
		}

		public static IEnumerable<int> Task7(int k, IEnumerable<int> integerList) {
			return integerList.Where(x => x % 2 == 0).Except(integerList.Skip(k)).Reverse();
		}

		public static IEnumerable<int> Task8(int k, int d, IEnumerable<int> integerList) {
			return integerList.TakeWhile(x => x <= d).
			Union(integerList.Skip(k).Select(x => x)).OrderByDescending(x => x);
		}

		public static IEnumerable<string> Task9(IEnumerable<string> stringList) {
			return stringList.GroupBy(x => x[0])
			.Select(x => {	
				return stringList.Where(y => y[0] == x.Key).Select(x => x.Length).Sum() + "-" + x.Key;
			}).OrderByDescending(str => int.Parse(str.Split('-')[0])).ThenBy(str => str.Split('-')[1]);
		}

		public static IEnumerable<string> Task10(IEnumerable<string> stringList) {
			return stringList.OrderBy(x => x).GroupBy(x => x.Length).
			Select(x => {
				var s = "";
				foreach (var item in x) {
					s += char.ToUpper(item[^1]);
				}
				return s;
			}).OrderByDescending(x => x.Length);
		}

		#endregion

		#region Advance

		public static IEnumerable<YearSchoolStat> Task11(IEnumerable<Entrant> nameList) {
			return nameList.Select(x => {
				var temp = new YearSchoolStat();
				temp.NumberOfSchools = x.SchoolNumber;
				temp.Year = x.Year;
				return temp;
			}).AsEnumerable().GroupBy(x => x.Year).Select(x => {
				var temp = new YearSchoolStat();
				var list = x.ToList();
				int c = 1;
				foreach (var item in list) {
					if (list[0].NumberOfSchools != item.NumberOfSchools)
						c++;
				}
				temp.NumberOfSchools = c;
				temp.Year = x.Key;
				return temp;
			}).OrderBy(x => x.NumberOfSchools).ThenBy(x => x.Year);
		}

		public static IEnumerable<NumberPair> Task12(IEnumerable<int> integerList1, IEnumerable<int> integerList2) {
			return integerList1.SelectMany(x => integerList2, (x, y) => {
				var value = new NumberPair();
				if (y.ToString()[^1] == x.ToString()[^1]) {
					value.Item1 = x;
					value.Item2 = y;
				}
				return value;
			}).Select(x => x).Where(x => x.Item1 != 0 && x.Item2 != 0)
			.OrderBy(x => x.Item1).ThenBy(x => x.Item2);
		}

		public static IEnumerable<YearSchoolStat> Task13(IEnumerable<Entrant> nameList, IEnumerable<int> yearList) {
			return yearList.SelectMany(x => nameList, (x, y) => {
				var temp = new YearSchoolStat();
				temp.Year = x;
				if (x == y.Year) {
					temp.NumberOfSchools = 1;
					return temp;
				}
				return temp;
			}).GroupBy(x => x.Year).Select(x => {
				var temp = new YearSchoolStat();
				temp.Year = x.Key;
				var count = x.Select(x => x).Count(x => x.NumberOfSchools != 0) - 1;
				if (count < 0)
					count = 0;
				temp.NumberOfSchools = count;
				return temp;
			}).OrderBy(x => x.NumberOfSchools).ThenBy(x => x.Year);
		}

		public static IEnumerable<MaxDiscountOwner> Task14(IEnumerable<Supplier> supplierList,
				IEnumerable<SupplierDiscount> supplierDiscountList) {
			return supplierDiscountList.GroupBy(x => x.ShopName).Select(x => {
				var temp = new MaxDiscountOwner();
				var disc = x.Select(y => y).Max(y => y.Discount);
				var owner_id = x.FirstOrDefault(y => y.Discount == disc).SupplierId;
				var owner = supplierList.FirstOrDefault(y => y.Id == owner_id);
				temp.Discount = disc;
				temp.Owner = owner;
				temp.ShopName = x.Key;
				return temp;
			}).OrderBy(x=> x.ShopName);
		}

		public static IEnumerable<CountryStat> Task15(IEnumerable<Good> goodList,
			IEnumerable<StorePrice> storePriceList) {
			return goodList.GroupJoin(
			storePriceList,
			c => c.Id,
			p => p.GoodId,
			(gl, sp) =>
				new CountryStat() {
					Country = gl.Country,
					StoresNumber = goodList.GroupJoin(
						storePriceList,
						k => k.Id,
						t => t.GoodId,
						(gl, tm) =>
						new {
							Country = gl.Country,
							Count = storePriceList.Where(f => f.GoodId == gl.Id).Select(n => n.Shop).Distinct().ToList()
						}
					).GroupBy(x=> x.Country).Select(x=> new { Country = x.Key, Count = x.SelectMany(i=> i.Count).Distinct()?.Count() ?? 0})
					.First(lm=> lm.Country == gl.Country).Count,
					MinPrice = sp.Where(i=> i.GoodId == gl.Id).Select(k=> k.Price).DefaultIfEmpty(0.0M).Min(p=> p)
				}
			).GroupBy(c=> c.Country).Select(i=> i.OrderBy(h=> h.MinPrice).First()).OrderBy(o=> o.Country);
		}

		#endregion

	}
}
