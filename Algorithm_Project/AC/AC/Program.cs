using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//백준 5430번 문제 AC 골드5
namespace AC
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());//testcase가 t개
            List<string> result = new List<string>();//결과값있는 리스트

            for (int i = 0; i < T; i++)
            {
                //에러 및 반전 카운트용 불린변수
                bool Is_error = false;
                bool Is_reversed = false;
                string this_result = "";
                //입력받기
                string func = Console.ReadLine();
                int arr_len = int.Parse(Console.ReadLine());
                string raw_arr = Console.ReadLine();
                //받아온 배열 전처리하기
                string [] preprocessed_arr = raw_arr.Split('[', ']', ',');

                if (preprocessed_arr.Length-2 != arr_len)//실제 받아온 배열의 크기와 받아온 배열크기비교
                {   Is_error = true; 
                    this_result = this_result + "error";
                    result.Add(this_result); 
                    continue;
                }

                List<string> ARR = new List<string>();

                for (int j = 1; j < arr_len+1; j++)//
                    ARR.Add(preprocessed_arr[j]);

                //전처리 끝난 배열에 함수들 적용시키기
                for (int j = 0; j < func.Length; j++) {
                    if (func[j] == 'R')
                        Is_reversed = Is_reversed ? false : true;
                    else if (func[j] == 'D')
                    {
                        if (arr_len == 0)
                        { Is_error = true; break; }
                        else
                            ARR = Delete(ARR, ref arr_len, Is_reversed);
                    }
                }

                //함수 적용시키고 남은 결과 출력.
                if (Is_error)
                    this_result = "error";
                else
                {
                    if (Is_reversed)
                    {
                       this_result = this_result + "[";
                        for (int j = arr_len-1; j >=0; j--)
                        {
                            this_result = this_result + ARR[j];
                            if (j > 0)
                                this_result = this_result + ",";
                        }
                       this_result = this_result + "]";
                    }
                    else
                    {
                        this_result = this_result + "[";
                        for (int j = 0; j < arr_len; j++)
                        {
                            this_result = this_result + ARR[j];
                            if (j < arr_len - 1)
                                this_result = this_result + ",";
                        }
                        this_result = this_result + "]";
                    }
                }
                result.Add(this_result);
            }
            foreach (string output in result) 
                Console.WriteLine(output);
            
            Console.ReadLine();
        }

        static List<string> Delete(List<string> arr, ref int arr_len, bool Is_reversed)
        {
            List<string> Deleted_arr = arr;
            if (!Is_reversed) {
                Deleted_arr.RemoveAt(0);
                arr_len -= 1;
                return Deleted_arr;
            }
            else {
                Deleted_arr.RemoveAt(arr_len-1);
                arr_len -= 1;
                return Deleted_arr;
            }
        }
    }
}
