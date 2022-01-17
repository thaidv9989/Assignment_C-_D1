using System;
using System.Collections.Generic;



namespace D1
{
    class Program
    {
        static List<Member> members = new List<Member>{
            new Member{
                FirstName = "Thai",
                LastName = "Do Van",
                Gender = "Male",
                DOB = new DateTime(2001, 2, 15),
                PhoneNumber = "",
                BirthPlace = "Thai Binh",
                IsGraduated = false
            },
            new Member{
                FirstName = "Hoc",
                LastName = "Nguyen Thai",
                Gender = "Male",
                DOB = new DateTime(2000, 2, 15),
                PhoneNumber = "",
                BirthPlace = "Ha Nam",
                IsGraduated = false
            },
            new Member{
                FirstName = "Thanh",
                LastName = "Do Tien",
                Gender = "Male",
                DOB = new DateTime(1999, 2, 15),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member{
                FirstName = "Anh",
                LastName = "Do Ngoc",
                Gender = "Male",
                DOB = new DateTime(1998, 3, 11),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member{
                FirstName = "Duy",
                LastName = "Pham Tran",
                Gender = "Male",
                DOB = new DateTime(1998, 3, 11),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member{
                FirstName = "Quan",
                LastName = "Pham Dinh",
                Gender = "Male",
                DOB = new DateTime(1996, 3, 11),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member{
                FirstName = "Huy",
                LastName = "Nguyen Quang",
                Gender = "Female",
                DOB = new DateTime(1997, 3, 11),
                PhoneNumber = "",
                BirthPlace = "Bac Giang",
                IsGraduated = false
            }
        };


        static void Main(string[] args)
        {
        //    1. find Male
            var maleMember = GetMale();
            PrintData(maleMember);

           //2. find Oldest
            var OldestMember = GetOldest();
            PrintData(new List<Member> {OldestMember});


            //3. find Fullname
            var fullnames = GetFullName();
            foreach (var fullname in fullnames)
            {
                Console.WriteLine(fullname);
            }

            //4. select BirthYear
            var result = MemberByBirthDay();
            PrintData(result.Item1);
            PrintData(result.Item2);
            PrintData(result.Item3);

            //5. Find By BirthPlace
            var result = GetBirthPlace();
            PrintData(result);

        }

        static List<Member> GetMale(){
            var result = new List<Member>();
            foreach (var member in members)
            {
                if (member.Gender == "Male"){
                    result.Add(member);
                }
            }
            return result;
        }

        static Member GetOldest(){
            var maxAge = members[0].Age;
            var maxAgeIndex = 0;
            for (var i = 0; i < members.Count; i++)
            {
                var member = members[i];
                if (member.Age > maxAge){
                    maxAge = member.Age;
                    maxAgeIndex = i;
                }
            }
            return members[maxAgeIndex];
        }
        static List<string> GetFullName(){
            var result = new List<string>();
            foreach (var member in members){
                result.Add($"{member.LastName} {member.FirstName}");
            }
            return result;
        }

        static Tuple<List<Member>, List<Member>> MemberByBirthDay(){
            var F0 = new List<Member>();
            var F1 = new List<Member>();
            // var F2 = new List<Member>();
            foreach(var member in members){
                var birthYear = member.DOB.Year;
                switch (birthYear)
                {
                    case 2000:
                        F0.Add(member);
                        break;
                    case > 2000:
                        F1.Add(member);
                        break;
                    case < 2000:
                        F2.Add(member);
                        break;
                }
                
                
            }
            return Tuple.Create(F0, F1, F2);
        }

        static List<Member> GetBirthPlace(){
            var result = new List<Member>();
            foreach (var member in members)
            {
                if (member.BirthPlace == "Ha Noi"){
                    result.Add(member);
                }
            }
            return result;
        }



        
        static void PrintData(List<Member> data){
            var index = 0;
            foreach (var item in data ){
                ++index;
                Console.WriteLine($"{index}. {item.LastName} {item.FirstName} - {item.DOB.ToString("dd/MM/yyyy")} - {item.Age}");
            }
        }  
    }
}
