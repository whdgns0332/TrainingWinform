﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 100, y = 0, value;

            try
            {
                value = x / y;
                Console.Write($"{x} / {y} = {value}");
                throw new Exception("1. 사용자 에러");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("2. y의 값을 0보다 크게 입력하세요");
            }
            catch (Exception ex)
            {
                Console.WriteLine("3. " + ex.Message);
            }
            finally
            {
                Console.WriteLine("4. 프로그램을 종료했습니다.");
            }
        }
    }
}
