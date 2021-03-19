using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Objects;
using NUnit.Framework;
using Linq.Tests.Comparers;

namespace Linq.Tests
{
    [TestFixture]
    public class Tests
    {
        private readonly YearSchoolComparer _yearSchoolComparer = new YearSchoolComparer();
        private readonly NumberPairComparer _numberPairComparer = new NumberPairComparer();
        private readonly MaxDiscountOwnerComparer _discountOwnerComparer = new MaxDiscountOwnerComparer();
        private readonly CountryStatComparer _countryStatComparer = new CountryStatComparer();

        #region Low

        [Test]
        public void Task1Test()
        {
            foreach (var (c, stringList, expected) in Task1Data())
            {
                var actualResult = Tasks.Task1(c, stringList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected.OrderBy(x => x), actualResult.OrderBy(x => x));
            }
        }

        [Test]
        public void Task2Test()
        {
            foreach (var (stringList, expected) in Task2Data())
            {
                var actualResult = Tasks.Task2(stringList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult);
            }
        }

        [Test]
        public void Task3Test()
        {
            foreach (var (stringList, expected) in Task3Data())
            {
                var actualResult = Tasks.Task3(stringList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected.OrderBy(x => x), actualResult.OrderBy(x => x));
            }
        }

        [Test]
        public void Task4Test()
        {
            foreach (var (k, stringList, expected) in Task4Data())
            {
                var actualResult = Tasks.Task4(k, stringList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult);
            }
        }

        [Test]
        public void Task5Test()
        {
            foreach (var (integerList, expected) in Task5Data())
            {
                var actualResult = Tasks.Task5(integerList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult);
            }
        }

        private IEnumerable<(char c, IEnumerable<string> stringList, IEnumerable<string> expected)> Task1Data()
        {
            yield return (
                c: 'a',
                stringList: new[] { "a fkgfjkgfgmk a", "a", "adddddd", "ddddddda" },
                expected: new[] { "a fkgfjkgfgmk a" });
            yield return (
                c: 'g',
                stringList: new[] { "gf", "g", "gdddddd", "dddddddg" },
                expected: new List<string>());
            yield return (
                c: 'B',
                stringList: new[] { "BETA", "BETA B", "Be or not to be", "some sentence with B" },
                expected: new[] { "BETA B" });
            yield return (
                c: '+',
                stringList: new[] { "c++", "+-+", "+6987/", "+478+" },
                expected: new[] { "+-+", "+478+" });
        }

        private IEnumerable<(IEnumerable<string> stringList, IEnumerable<int> expected)> Task2Data()
        {
            yield return (
                stringList: new[] { "ddddddaaa", "dsjhdfoiwhveuvn", "hvbrurhvuirevhreuivguvvhu" },
                expected: new[] { 9, 15, 25 });
            yield return (
                stringList: new[] { "dddddd", "ddddd", "ddd", "dd", "d" },
                expected: new[] { 1, 2, 3, 5, 6 });
            yield return (
                stringList: new[]
                {
                    "turn", "cap", "the string dudududu", "some sentence with B",
                    "fertility", "the sharp", "some string", ""
                },
                expected: new[]
                {
                    0, 3, 4, 9, 9, 11, 19, 20
                });
        }

        private IEnumerable<(IEnumerable<string> stringList, IEnumerable<string> expected)> Task3Data()
        {
            yield return (
                stringList: new[] { "ehgrtthrehrehrehre", "fjjgoerugrjgrehg", "jgnjirgbrnigeheruwqqeughweirjewew" },
                expected: new[] { "ee", "fg", "jw" });
            yield return (
                stringList: new[] { "756998/*+fgh", "urhrhgu48GH", "SssssS", "the something;", "hello" },
                expected: new[] { "7h", "uH", "SS", "t;", "ho" });
            yield return (
                stringList: new[]
                {
                    "&ghjjpgirbigjrg5985849*///grgerge", "#fkgjklgflgk@", "irejgkerogruoj^", "some sentence with B",
                    "fertility", "the sharp", "some string", "a"
                },
                expected: new[]
                {
                    "&e", "#@", "i^", "sB",
                    "fy", "tp", "sg", "aa"
                });
        }

        private IEnumerable<(int k, IEnumerable<string> stringList, IEnumerable<string> expected)> Task4Data()
        {
            yield return (
                k: 1,
                stringList: new[] { "1", "f3", "8" },
                expected: new[] { "1", "8" });
            yield return (
                k: 4,
                stringList: new[] { "345e", "ABC1", "1437", "FGE3", "fire1" },
                expected: new[] { "1437", "ABC1", "FGE3" });
            yield return (
                k: 0,
                stringList: new[]
                {
                    "1", "5", "bc", "ABC1",
                    "fertility", "the sharp", "some string", "a"
                },
                expected: new List<string>());
            yield return (
                k: 12,
                stringList: new[]
                {
                    "the big cup2", "#fkgjklgflgk2", "The objection", "###########1",
                    "fertility", "the big cup1", "some string", "a"
                },
                expected: new[]
                {
                    "###########1", "the big cup1", "the big cup2"
                });
        }

        private IEnumerable<(IEnumerable<int> integerList, IEnumerable<string> expected)> Task5Data()
        {
            yield return (
                integerList: new[] { 140, 45, 14, 0, 15, 147 },
                expected: new[] { "15", "45", "147" });
            yield return (
                integerList: new[] { 190, 56, 47, 5681, 45, 89652, 7893 },
                expected: new[] { "45", "47", "5681", "7893" });
            yield return (
                integerList: new[] { 93, 45, 789, 456, 45, 78, 235, 896, 4563 },
                expected: new[] { "45", "45", "93", "235", "789", "4563" });
            yield return (
                integerList: new[] { 92, 42, 782, 456, 44, 78, 236, 896, 4562 },
                expected: new List<string>());
        }

        #endregion

        #region Middle
        // UNCOMMENT TO CHECK MIDDLE PART
        
        [Test]
        public void Task6Test()
        {
            foreach (var (numbers, stringList, expected) in Task6Data())
            {
                var actualResult = Tasks.Task6(numbers, stringList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected.OrderBy(x => x), actualResult.OrderBy(x => x));
            }
        }

        [Test]
        public void Task7Test()
        {
            foreach (var (k, integerList, expected) in Task7Data())
            {
                var actualResult = Tasks.Task7(k, integerList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult);
            }
        }

        [Test]
        public void Task8Test()
        {
            foreach (var (k, d, integerList, expected) in Task8Data())
            {
                var actualResult = Tasks.Task8(k, d, integerList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult);
            }
        }

        [Test]
        public void Task9Test()
        {
            foreach (var (stringList, expected) in Task9Data())
            {
                var actualResult = Tasks.Task9(stringList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult);
            }
        }

        [Test]
        public void Task10Test()
        {
            foreach (var (stringList, expected) in Task10Data())
            {
                var actualResult = Tasks.Task10(stringList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult);
            }
        }
        private IEnumerable<(IEnumerable<int> numbers, IEnumerable<string> stringList, IEnumerable<string> expected)> Task6Data()
        {
            yield return (
                numbers: new []{ 4, 1, 6 },
                stringList: new []{ "qwer", "5qwer", "3qwe", "7qwert", "q" },
                expected: new []{ "3qwe", "Not found", "7qwert" });
            yield return (
                numbers: new[] { 4, 1, 6, 3, 12 },
                stringList: new[] { "2qwe", "4qwe", "5", "3qwe", "7qwert", "1 the 12long" },
                expected: new[] { "2qwe", "5", "7qwert", "Not found", "1 the 12long" });
            yield return (
                numbers: new[] { 7, 1, Int32.MaxValue },
                stringList: new[] { "qwer", "5qwer", "3qwe", "0qwerty" },
                expected: new[] { "0qwerty", "Not found", "Not found" });
            yield return (
                numbers: new[] { 44, 21, 78 },
                stringList: new[] { "qwer", "5qwer", "3qwe", "7qwert" },
                expected: new[] { "Not found", "Not found", "Not found" });
        }

        private IEnumerable<(int k, IEnumerable<int> integerList, IEnumerable<int> expected)> Task7Data()
        {
            yield return (
                k: 2,
                integerList: new[] { 1, 3, 78, 96, 76, 45, 5, -89, 56, 41 },
                expected: new List<int>());
            yield return (
                k: 20,
                integerList: new[] { 1, 3, 76, 96, 78, 45, 3, -89, 56, 41 },
                expected: new[] { 56, 78, 96, 76 } );
            yield return (
                k: 5,
                integerList: new[] { 1, 12, 14, 7, 92, 5, 423, 11, 47, 71, 43 },
                expected: new [] {92, 14, 12});
            yield return (
                k: 7,
                integerList: new[] { 1, 73, 45, 87, 45, 19, 13, 44, 76, -78 },
                expected: new List<int>());
        }
        
        private IEnumerable<(int k, int d, IEnumerable<int> integerList, IEnumerable<int> expected)> Task8Data()
        {
            yield return (
                k: 3,
                d: 25,
                integerList: new[] { 12, 17, 18, 19, 25, 14, 45, 71, 63, 78, 11 },
                expected: new[] { 78, 71, 63, 45, 25, 19, 18, 17, 14, 12, 11 });
            yield return (
                k: 30,
                d: 1,
                integerList: new[] { 12, 17, 18, 19, 25, 14, 45, 71, 63, 78, 11 },
                expected: new List<int>());
            yield return (
                k: 8,
                d: 1,
                integerList: new[] { 12, 17, 18, 19, 25, 14, 45, 71, 63, 78, 11 },
                expected: new [] { 78, 63, 11 });
            yield return (
                k: 15,
                d: 25,
                integerList: new[] { 12, 17, 18, 19, 25, 14, 45, 71, 63, 78, 11 },
                expected: new[] { 25, 19, 18, 17, 14, 12 });
        }
        
        private IEnumerable<(IEnumerable<string> stringList, IEnumerable<string> expected)> Task9Data()
        {
            yield return (
                stringList: new[] { "YELLOW", "GREEN", "YIELD" },
                expected: new[] { "11-Y", "5-G" });
            yield return (
                stringList: new[] { "FIREE", "FIGHTER", "AGGREGATE", "ACE" },
                expected: new[] { "12-A", "12-F" });
            yield return (
                stringList: new[]
                {
                    "EPAM", "GOOGLE", "MICROSOFT", "APPLE", "TESLA", "STARLINK", "TWITTER"
                },
                expected: new []
                {
                    "12-T", "9-M", "8-S", "6-G", "5-A", "4-E"
                });
        }

        private IEnumerable<(IEnumerable<string> stringList, IEnumerable<string> expected)> Task10Data()
        {
            yield return (
                stringList: new[] { "bc", "sd", "ac", "sdf", "ewr" },
                expected: new[] { "CCD", "RF" });
            yield return (
                stringList: new[] { "du", "the", "ace", "run", "cut" },
                expected: new[] { "ETNE", "U" });
            yield return (
                stringList: new[] { "ab", "attribute", "cheese", "swim", "cut" },
                expected: new[] { "B", "E", "E", "T", "M" });
            yield return (
                stringList: new[] { "star", "galaxy", "quasar", "planet", "asteroid", "satellite", "comet" },
                expected: new[] { "YTR", "D", "T", "E", "R" });
        }
        

        #endregion

        #region Advance
        // UNCOMMENT TO CHECK ADVANCED PART
        
        [Test]
        public void Task11Test()
        {
            foreach (var (nameList, expected) in Task11Data())
            {
                var actualResult = Tasks.Task11(nameList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult, _yearSchoolComparer);
            }
        }

        [Test]
        public void Task12Test()
        {
            foreach (var (integerList1, integerList2, expected) in Task12Data())
            {
                var actualResult = Tasks.Task12(integerList1, integerList2);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult, _numberPairComparer);
            }
        }

        [Test]
        public void Task13Test()
        {
            foreach (var (nameList, yearList, expected) in Task13Data())
            {
                var actualResult = Tasks.Task13(nameList, yearList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult, _yearSchoolComparer);
            }
        }

        [Test]
        public void Task14Test()
        {
            foreach (var (supplierList, supplierDiscountList, expected) in Task14Data())
            {
                var actualResult = Tasks.Task14(supplierList, supplierDiscountList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult, _discountOwnerComparer);
            }
        }

        [Test]
        public void Task15Test()
        {
            foreach (var (goodList, storePriceList, expected) in Task15Data())
            {
                var actualResult = Tasks.Task15(goodList, storePriceList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult, _countryStatComparer);
            }
        }

        private IEnumerable<(IEnumerable<Entrant> nameList, IEnumerable<YearSchoolStat> expected)> Task11Data()
        {
            yield return (
                nameList: new[]
                {
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 13, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 14, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 15, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 13, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017}
                },
                expected: new[]
                {
                    new YearSchoolStat {NumberOfSchools = 1, Year = 2017},
                    new YearSchoolStat {NumberOfSchools = 2, Year = 2018},
                    new YearSchoolStat {NumberOfSchools = 4, Year = 2019}
                });
            yield return (
                nameList: new[]
                {
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 13, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 14, Year = 2016},
                    new Entrant {LastName = "Name", SchoolNumber = 15, Year = 2016},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 13, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017}
                },
                expected: new[]
                {
                    new YearSchoolStat {NumberOfSchools = 1, Year = 2017},
                    new YearSchoolStat {NumberOfSchools = 2, Year = 2016},
                    new YearSchoolStat {NumberOfSchools = 2, Year = 2018},
                    new YearSchoolStat {NumberOfSchools = 2, Year = 2019}
                });
            yield return (
                nameList: new[]
                {
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017}
                },
                expected: new[]
                {
                    new YearSchoolStat {NumberOfSchools = 1, Year = 2017},
                    new YearSchoolStat {NumberOfSchools = 1, Year = 2018},
                    new YearSchoolStat {NumberOfSchools = 1, Year = 2019}
                });
        }

        private IEnumerable<(IEnumerable<int> integerList1, IEnumerable<int> integerList2, IEnumerable<NumberPair> expected)> Task12Data()
        {
            yield return (
                integerList1: new[] { 1, 12, 4, 5, 78 },
                integerList2: new[] { 1, 42, 75, 65, 8, 97 },
                expected: new []
                {
                    new NumberPair{Item1 = 1, Item2 = 1},
                    new NumberPair{Item1 = 5, Item2 = 65},
                    new NumberPair{Item1 = 5, Item2 = 75},
                    new NumberPair{Item1 = 12, Item2 = 42},
                    new NumberPair{Item1 = 78, Item2 = 8}
                });
            yield return (
                integerList1: new[] { 1, 12, 4, 5, 78 },
                integerList2: new[] { 7, 43, 76, 69, 3, 97 },
                expected: new List<NumberPair>());
            yield return (
                integerList1: new[] { 1, 12, 4, 5, 78 },
                integerList2: new[] { 71, 42, 1, 32, 74, 97 },
                expected: new[]
                {
                    new NumberPair{Item1 = 1, Item2 = 1},
                    new NumberPair{Item1 = 1, Item2 = 71},
                    new NumberPair{Item1 = 4, Item2 = 74},
                    new NumberPair{Item1 = 12, Item2 = 32},
                    new NumberPair{Item1 = 12, Item2 = 42}
                });
        }
        
        private IEnumerable<(IEnumerable<Entrant> nameList, IEnumerable<int> yearList, IEnumerable<YearSchoolStat> expected)> Task13Data()
        {
            yield return (
                nameList: new[]
                {
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 13, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 14, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 15, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 13, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017}
                },
                yearList: new[] {2019, 2018},
                expected: new[]
                {
                    new YearSchoolStat {NumberOfSchools = 2, Year = 2018},
                    new YearSchoolStat {NumberOfSchools = 4, Year = 2019}
                });
            yield return (
                nameList: new[]
                {
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 13, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 14, Year = 2016},
                    new Entrant {LastName = "Name", SchoolNumber = 15, Year = 2016},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 13, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017}
                },
                yearList: new[] { 2020, 2017, 2018 },
                expected: new[]
                {
                    new YearSchoolStat {NumberOfSchools = 0, Year = 2020}, 
                    new YearSchoolStat {NumberOfSchools = 1, Year = 2017},
                    new YearSchoolStat {NumberOfSchools = 2, Year = 2018}
                });
            yield return (
                nameList: new[]
                {
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017}
                },
                yearList: new[] {2020, 2013},
                expected: new[]
                {
                    new YearSchoolStat {NumberOfSchools = 0, Year = 2013},
                    new YearSchoolStat {NumberOfSchools = 0, Year = 2020}
                });
        }
        
        private IEnumerable<(IEnumerable<Supplier> supplierList, IEnumerable<SupplierDiscount> supplierDiscountList,
        IEnumerable<MaxDiscountOwner> expected)> Task14Data()
        {
            yield return (
                    supplierList: new []
                    {
                        new Supplier{Adress = "adress 1", Id = 1, YearOfBirth = 2000},
                        new Supplier{Adress = "adress 2", Id = 2, YearOfBirth = 1961},
                        new Supplier{Adress = "adress 3", Id = 3, YearOfBirth = 1984},
                        new Supplier{Adress = "adress 4", Id = 4, YearOfBirth = 1997},
                        new Supplier{Adress = "adress 5", Id = 5, YearOfBirth = 1990}
                    },
                    supplierDiscountList: new []
                    {
                        new SupplierDiscount{Discount = 5.0, ShopName = "shop1", SupplierId = 1},
                        new SupplierDiscount{Discount = 1.0, ShopName = "shop2", SupplierId = 1},
                        new SupplierDiscount{Discount = 2.0, ShopName = "shop3", SupplierId = 1},
                        new SupplierDiscount{Discount = 4.0, ShopName = "shop4", SupplierId = 1},
                        new SupplierDiscount{Discount = 6.0, ShopName = "shop6", SupplierId = 1},
                        new SupplierDiscount{Discount = 34.0, ShopName = "shop2", SupplierId = 2},
                        new SupplierDiscount{Discount = 10.0, ShopName = "shop5", SupplierId = 2},
                        new SupplierDiscount{Discount = 7.0, ShopName = "shop5", SupplierId = 3},
                        new SupplierDiscount{Discount = 9.0, ShopName = "shop3", SupplierId = 3},
                        new SupplierDiscount{Discount = 32.0, ShopName = "shop5", SupplierId = 3},
                        new SupplierDiscount{Discount = 7.2, ShopName = "shop4", SupplierId = 4},
                        new SupplierDiscount{Discount = 34.0, ShopName = "shop2", SupplierId = 4},
                        new SupplierDiscount{Discount = 6.0, ShopName = "shop3", SupplierId = 4},
                        new SupplierDiscount{Discount = 7.0, ShopName = "shop5", SupplierId = 4},
                        new SupplierDiscount{Discount = 1.5, ShopName = "shop6", SupplierId = 5}
                    },
                    expected: new []
                    {
                        new MaxDiscountOwner
                        {
                            Discount = 5.0, ShopName = "shop1",
                            Owner = new Supplier{Adress = "adress 1", Id = 1, YearOfBirth = 2000}
                        },
                        new MaxDiscountOwner
                        {
                            Discount = 34.0, ShopName = "shop2",
                            Owner = new Supplier{Adress = "adress 2", Id = 2, YearOfBirth = 1961}
                        },
                        new MaxDiscountOwner
                        {
                            Discount = 9.0, ShopName = "shop3",
                            Owner = new Supplier{Adress = "adress 3", Id = 3, YearOfBirth = 1984}
                        },
                        new MaxDiscountOwner
                        {
                            Discount = 7.2, ShopName = "shop4",
                            Owner = new Supplier{Adress = "adress 4", Id = 4, YearOfBirth = 1997}
                        },
                        new MaxDiscountOwner
                        {
                            Discount = 32.0, ShopName = "shop5",
                            Owner = new Supplier{Adress = "adress 3", Id = 3, YearOfBirth = 1984}
                        },
                        new MaxDiscountOwner
                        {
                            Discount = 6.0, ShopName = "shop6",
                            Owner = new Supplier{Adress = "adress 1", Id = 1, YearOfBirth = 2000}
                        }
                    });
        }

        private IEnumerable<(IEnumerable<Good> goodList, IEnumerable<StorePrice> storePriceList,
            IEnumerable<CountryStat> expected)> Task15Data()
        {
            yield return (
                    goodList: new[]
                    {
                        new Good{Id = 1, Country = "Ukraine", Category = "Food"},
                        new Good{Id = 2, Country = "Ukraine", Category = "Food"},
                        new Good{Id = 3, Country = "Ukraine", Category = "Food"},
                        new Good{Id = 4, Country = "Ukraine", Category = "Food"},
                        new Good{Id = 5, Country = "Germany", Category = "Food"},
                        new Good{Id = 6, Country = "Germany", Category = "Food"},
                        new Good{Id = 7, Country = "Germany", Category = "Food"},
                        new Good{Id = 8, Country = "Germany", Category = "Food"},
                        new Good{Id = 9, Country = "Greece", Category = "Food"},
                        new Good{Id = 10, Country = "Greece", Category = "Food"},
                        new Good{Id = 11, Country = "Greece", Category = "Food"},
                        new Good{Id = 12, Country = "Italy", Category = "Food"},
                        new Good{Id = 13, Country = "Italy", Category = "Food"},
                        new Good{Id = 14, Country = "Italy", Category = "Food"},
                        new Good{Id = 15, Country = "Slovenia", Category = "Food"}
                    },
                    storePriceList: new []
                    {
                        new StorePrice{GoodId = 1, Price = 1.25M, Shop = "shop1"},
                        new StorePrice{GoodId = 3, Price = 2.25M, Shop = "shop1"},
                        new StorePrice{GoodId = 5, Price = 4.25M, Shop = "shop1"},
                        new StorePrice{GoodId = 7, Price = 9.25M, Shop = "shop1"},
                        new StorePrice{GoodId = 9, Price = 11.25M, Shop = "shop1"},
                        new StorePrice{GoodId = 11, Price = 12.25M, Shop = "shop1"},
                        new StorePrice{GoodId = 13, Price = 13.25M, Shop = "shop1"},
                        new StorePrice{GoodId = 14, Price = 14.25M, Shop = "shop1"},
                        new StorePrice{GoodId = 5, Price = 11.25M, Shop = "shop2"},
                        new StorePrice{GoodId = 4, Price = 16.25M, Shop = "shop2"},
                        new StorePrice{GoodId = 3, Price = 18.25M, Shop = "shop2"},
                        new StorePrice{GoodId = 2, Price = 11.25M, Shop = "shop2"},
                        new StorePrice{GoodId = 1, Price = 1.50M, Shop = "shop2"},
                        new StorePrice{GoodId = 3, Price = 4.25M, Shop = "shop3"},
                        new StorePrice{GoodId = 7, Price = 3.25M, Shop = "shop3"},
                        new StorePrice{GoodId = 10, Price = 13.25M, Shop = "shop3"},
                        new StorePrice{GoodId = 14, Price = 14.25M, Shop = "shop3"},
                        new StorePrice{GoodId = 3, Price = 11.25M, Shop = "shop4"},
                        new StorePrice{GoodId = 2, Price = 14.25M, Shop = "shop4"},
                        new StorePrice{GoodId = 12, Price = 2.25M, Shop = "shop4"},
                        new StorePrice{GoodId = 6, Price = 5.25M, Shop = "shop4"},
                        new StorePrice{GoodId = 8, Price = 6.25M, Shop = "shop4"},
                        new StorePrice{GoodId = 10, Price = 11.25M, Shop = "shop4"},
                        new StorePrice{GoodId = 4, Price = 15.25M, Shop = "shop5"},
                        new StorePrice{GoodId = 7, Price = 18.25M, Shop = "shop5"},
                        new StorePrice{GoodId = 8, Price = 13.25M, Shop = "shop5"},
                        new StorePrice{GoodId = 12, Price = 14.25M, Shop = "shop5"},
                        new StorePrice{GoodId = 1, Price = 3.25M, Shop = "shop6"},
                        new StorePrice{GoodId = 3, Price = 2.25M, Shop = "shop6"},
                        new StorePrice{GoodId = 1, Price = 1.20M, Shop = "shop7"}
                    },
                    expected: new []
                    {
                        new CountryStat{Country = "Germany", MinPrice = 3.25M, StoresNumber = 5},
                        new CountryStat{Country = "Greece", MinPrice = 11.25M, StoresNumber = 3},
                        new CountryStat{Country = "Italy", MinPrice = 2.25M, StoresNumber = 4},
                        new CountryStat{Country = "Slovenia", MinPrice = 0.0M, StoresNumber = 0},
                        new CountryStat{Country = "Ukraine", MinPrice = 1.20M, StoresNumber = 7},
                    });
        }
         

        #endregion

        #region Utility

        private void AssertIsLinq<T>(IEnumerable<T> result)
        {
            Assert.AreEqual("System.Linq", result.GetType().Namespace, "Result is not linq");
        }

        private void AssertIsAsExpected<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Assert.AreEqual(expected, actual);
        }

        private void AssertIsAsExpected<T>(IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer)
        {
            Assert.True(expected.SequenceEqual(actual, comparer), "Result is not as expected");
        }

        #endregion
    }
}