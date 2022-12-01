using Nancy.Json;
using System;
using System.Net;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //生成Json序列化对象
            JavaScriptSerializer jss = new JavaScriptSerializer();

            //请求的URL地址
            string url1 = "https://localhost:44305/WebService1.asmx/GetJson";
            //string url1 = "http://10.20.72.223:12333/WebService1.asmx/GetJson";

            //创建Student对象
            Student stu = new Student();

            //Student对象赋值（可以用从WinForm传递来的值代替）
            stu.Id = 1;
            stu.UserName = "李小龙";
            stu.Pwd = "123456";
            stu.Age = 20;
            stu.Sex = "男";

            //创建WebClient对象
            WebClient wc = new WebClient();
            
            //设置请求地址
            string url = url1;

            //设置编码格式和请求头传输数据格式
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Content-Type", "application/json");

            //请求数据并返回结果
            string result = wc.UploadString(url, jss.Serialize(stu));

            //打印结果
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }

    //声明Student类，也可以封装从WinForm传递来的数据
    class Student {
        private int id;
        private string userName;
        private string pwd;
        private int age;
        private string sex;

        public Student()
        {
          
        }

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public int Age { get => age; set => age = value; }
        public string Sex { get => sex; set => sex = value; }
    }
}
