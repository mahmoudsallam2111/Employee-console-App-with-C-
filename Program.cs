namespace day4_employee_struct
{
    enum Gender
    {
        Male, Female
    }

    [Flags]
    enum securitylevel
    {
        manager=1 , DBA=2, developer=4 , junior=8
    }
    class Hiredate
    {
        int year;
        int month;
        int day;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public int Month
        {
            get { return month; }
            set
            {
                if (value <= 12)
                {
                    month = value;

                }
                else
                {
                    throw new Exception();
                }

            }
        }
        public int Day
        {
            get { return day; }
            set
            {
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 9 || month == 11)
                {
                    if (value <= 31)
                        day = value;
                    else
                        throw new Exception();
                }
                else if (month == 4 || month == 6 || month == 8 || month == 10 || month == 12)
                {
                    if (value < 31)
                        day = value;
                    else
                        throw new Exception();
                }
                else
                    if (value < 29)
                    day = value;
                else
                    throw new Exception();

            }

        }
        public Hiredate()
        {
            this.Day = 0;
            this.Year = 0;
            this.Month = 0;
        }
        public Hiredate(int _year, int _month, int _day)
        {
            this.year = _year;
            if (_month >12)
            {
                throw new Exception();

            }
            else
            {
                this.month = _month;
            }
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 9 || month == 11)
            {
                if (_day <= 31)
                    this.day = _day;
                else
                    throw new Exception();
            }
            else if (month == 4 || month == 6 || month == 8 || month == 10 || month == 12)
            {
                if (_day < 31)
                    this.day = _day;
                else
                    throw new Exception();
            }
            else
                if (_day < 29)
                this.day = _day;
            else
                throw new Exception();

        }

        public override string ToString()
        {
            return $"the year of hire is {year} and month is {month}  and day is {day}";
        }

        
    }
    
    class skill
    {
        public String skillname { get; set; }
        public int skilllevel { get; set; }
        public int skillpoints { get; set; }
        /// <summary>
        /// the is a summary
        /// </summary>
        /// <param name="skillname"> the skillname </param>
        /// <param name="skilllevel"> the skill level</param>
        /// <param name="skillpoints"> the skill points</param>

        public skill(string skillname ,  int skilllevel , int skillpoints)
        {
            this.skillname = skillname;
            this.skilllevel = skilllevel;
            this.skillpoints = skillpoints;
                
        }
        public override string ToString()
        {
            return $"skillname : {skillname}  skilllevel : {skilllevel}  skillpoints : {skillpoints} \n";
        }
    }
    
    class Employee:IComparable<Employee>
    {
        int id;
        securitylevel securitylevel;
        int salary;
        Hiredate hire ;
        Gender gender;
        public skill[] arr { set; get; }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public Hiredate date
        {
            get { return hire; }
            set { hire = value; }
        }


        public Employee(int _id, securitylevel sec_level, int _salary, Hiredate myhire, Gender _gender , skill[] arr  )
        {
            this.id = _id;
            this.securitylevel = sec_level;
            this.salary = _salary;
            this.hire = myhire;
            this.gender = _gender;
            this.arr = arr;
        }

        public override string ToString()
        {
            string txt = $"  the id is {id} and  gender is {gender} and securitylevel is {securitylevel} and salary is {salary}$ && hire date is {hire.Day} / {hire.Month}/ {hire.Year} && skills :: \n ";
            for (int i = 0; i < arr?.Length; i++)
            {
                txt += arr[i].ToString();

            }
            return txt;
        }

        //public int CompareTo(object? obj)
        //{
        //    Employee e = obj as Employee;
        //    //return (this.hire.Year.CompareTo(e.hire.Year));
        //    if(this.hire.Year != e.hire.Year)
        //    {
        //        return (this.hire.Year.CompareTo(e.hire.Year));
        //    }
        //    else
        //    {
        //        if (this.hire.Month != e.hire.Month)
        //        {
        //            return (this.hire.Month.CompareTo(e.hire.Month));

        //        }
        //        else
        //        {
        //            return (this.hire.Day.CompareTo(e.hire.Day));

        //        }
        //    }
        //}

        public int CompareTo(Employee? other)
        {
            if (this.hire.Year !=other.hire.Year)
            {
                return (this.hire.Year.CompareTo(other.hire.Year));
            }
            else
            {
                if (this.hire.Month != other.hire.Month)
                {
                    return (this.hire.Month.CompareTo(other.hire.Month));

                }
                else
                {
                    return (this.hire.Day.CompareTo(other.hire.Day));

                }
            }

        }

        public int this[string skillname]    //// indexer
        {
            get
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].skillname == skillname)
                    {
                        return arr[i].skilllevel;

                    }
                }
                return -2222222; //// nnot found
            }
            set
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].skillname == skillname)
                    {
                        arr[i].skilllevel = value;

                    }

                }
            }
        }
        

        
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            
            //arrskill[0] = new skill("reading", 5, 55);
            //arrskill[1] = new skill("writing", 4, 30);
            //arrskill[2] = new skill("playing", 3, 50);

            //Employee ee = new Employee(1, securitylevel.developer, 555, new Hiredate(2, 5, 5), Gender.Fmale, arrskill);
            //Console.WriteLine(ee["reading"]);

            Console.WriteLine("enter number of employee?? ");
            int size;
            do
            {
                Console.WriteLine("enter a number greater than 0 ");
                bool state = int.TryParse(Console.ReadLine(), out size);
            } while (size == 0);
            
            Employee[] arr = new Employee[size];



            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"enter data of employee {i + 1}");
                Console.WriteLine($"enter the id ");
                int id;
                do
                {
                    Console.WriteLine("id must be integer");

                    bool state = int.TryParse(Console.ReadLine(), out id);


                } while (id <= 0);


                securitylevel sl;
                bool sl_state;

                do
                {
                    Console.WriteLine("enter securityLevel ?? ");
                    Console.WriteLine("choose from { manager , developer , DBA , junior}");
                    string mysl = Console.ReadLine();
                     sl_state = Enum.TryParse<securitylevel>(mysl, out sl);

                } while (sl_state == false);




                Console.WriteLine("enter salary");
                int salary;
                
                do
                {
                    Console.WriteLine("id must be integer");

                    bool state = int.TryParse(Console.ReadLine(), out salary);


                } while (salary <= 0);


                Console.WriteLine("enter year");
                int year;

                do
                {
                    Console.WriteLine(" must be integer!!!!!!!!!!");

                    bool state = int.TryParse(Console.ReadLine(), out year);


                } while (year == 0);


                Console.WriteLine("enter month");
                int month;

                do
                {
                    Console.WriteLine("id must  be between 1 and 12 ");

                    bool state = int.TryParse(Console.ReadLine(), out month);


                } while (month ==0);

                //try
                //{
                //    month = int.Parse(Console.ReadLine());
                //}
                //catch (ArgumentOutOfRangeException ee)
                //{
                //    Console.WriteLine(ee.Message);

                //}
                //finally
                //{

                //}

                Console.WriteLine("enter day");
                int day;

                do
                {
                    Console.WriteLine("must be integer!!!!!!!!!!");

                    bool state = int.TryParse(Console.ReadLine(), out day);


                } while (day <= 0);

                
                
                    
                
               
  
                
                Gender gen;
                bool gender_state;

                do
                {
                    Console.WriteLine("enter sex");
                    string sex = Console.ReadLine();
                    gender_state = Enum.TryParse<Gender>(sex, out gen);

                } while (gender_state == false);
                
                


                Console.WriteLine("enter number of skill eployee have ?? ");
                int arrsize;
                do
                {
                    Console.WriteLine("enter a number greater than 0 ");
                    bool state = int.TryParse(Console.ReadLine(), out arrsize);
                } while (arrsize == 0);

                skill[] arrskill = new skill[arrsize];
                for (int j = 0; j < arrsize; j++)
                {
                    Console.WriteLine("enter skill name???");
                    string skillName = Console.ReadLine();


                    int skill_Level;
                    do
                    {
                        Console.WriteLine("enter skill_level???");
                        bool state = int.TryParse(Console.ReadLine(), out skill_Level);

                    } while (skill_Level == 0);

                    int skill_points;
                    do
                    {
                        Console.WriteLine("enter skill_points ???");
                        bool state = int.TryParse(Console.ReadLine(), out skill_points);

                    } while (skill_points == 0);
                    arrskill[j] = new skill(skillName, skill_Level, skill_points);
                    

                }




                arr[i] = new Employee(id, sl, salary, new Hiredate(year, month, day),gen , arrskill);

            }

            Array.Sort(arr);
            Console.WriteLine("-------------------------------------------------");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"the data of employee {i + 1} is : ");
                Console.WriteLine(arr[i].ToString());
                Console.WriteLine(" ");
            }

        }
    }
}