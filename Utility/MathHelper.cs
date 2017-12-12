using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Utility
{
    public class MathHelper
    {
        
        //const double PI = 3.1415926;



        #region NORMSINV
        /// <summary>
        /// NORMSINV(P)
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double NORMSINV(double p)
        {
            double[] a =
	        {
		        -3.969683028665376e+01,
			    2.209460984245205e+02,
			    -2.759285104469687e+02,
			    1.383577518672690e+02,
			    -3.066479806614716e+01,
			    2.506628277459239e+00
	        };
            double[] b =
	        {
		        -5.447609879822406e+01,
			    1.615858368580409e+02,
			    -1.556989798598866e+02,
			    6.680131188771972e+01,
			    -1.328068155288572e+01
	        };
             double[] c =
	        {
		        -7.784894002430293e-03,
			    -3.223964580411365e-01,
			    -2.400758277161838e+00,
			    -2.549732539343734e+00,
			    4.374664141464968e+00,
			    2.938163982698783e+00
	        };
            double[] d =
	        {
		        7.784695709041462e-03,
			    3.224671290700398e-01,
			    2.445134137142996e+00,
			    3.754408661907416e+00
	        };
            double q, r;
            
            //errno = 0;

            if (p < 0 || p > 1)
            {
                //errno = EDOM;
                return 0.0;
            }
            else if (p == 0)
            {
                //errno = ERANGE;
                return 0.0 /* minus "infinity" */;
            }
            else if (p == 1)
            {
                //errno = ERANGE;
                return 0.0 /* "infinity" */;
            }
            else if (p < 0.02425)
            {
                /* Rational approximation for lower region */
                q = Math.Sqrt(-2 * Math.Log(p));
                return (((((c[0] * q + c[1]) * q + c[2]) * q + c[3]) * q + c[4]) * q + c[5]) /
                    ((((d[0] * q + d[1]) * q + d[2]) * q + d[3]) * q + 1);
            }
            else if (p > 0.97575)
            {
                /* Rational approximation for upper region */
                q = Math.Sqrt(-2 * Math.Log(1 - p));
                return -(((((c[0] * q + c[1]) * q + c[2]) * q + c[3]) * q + c[4]) * q + c[5]) /
                    ((((d[0] * q + d[1]) * q + d[2]) * q + d[3]) * q + 1);
            }
            else
            {
                /* Rational approximation for central region */
                q = p - 0.5;
                r = q * q;
                return (((((a[0] * r + a[1]) * r + a[2]) * r + a[3]) * r + a[4]) * r + a[5]) * q /
                    (((((b[0] * r + b[1]) * r + b[2]) * r + b[3]) * r + b[4]) * r + 1);
            }

        }
        #endregion

        #region LINEST
        /// <summary>
        /// LINEST
        /// </summary>
        /// <param name="x">xs</param>
        /// <param name="y">ys</param>
        /// <returns>返回参数组，第一个值为a，第二个值为b</returns>
        public double[] LINEST(double[] y,double[] x )
        {
            int ii = 0;
            double sum_x = 0;
            double sum_y = 0;
            double sum_xy = 0;
            double sum_x2 = 0;
            double a = 0;
            double b = 0;
            double[] parameter=new double[2];

            int dataCnt = Math.Min(x.Length, y.Length) ;

            if (dataCnt == 1)
            {
                a = 0;
                b = y[0];
                parameter[0] = a;
                parameter[1] = b;
                return parameter;
            }
            else
            {

                for (ii = 0; ii <= dataCnt - 1; ii++)
                {
                    //X和
                    sum_x += x[ii];
                    //Y和
                    sum_y += y[ii];
                    //X*Y和
                    sum_xy += x[ii] * y[ii];
                    //X2和
                    sum_x2 += x[ii] * x[ii];
                }

                //nΣx2-(Σx)2
                double divisor = dataCnt * sum_x2 - sum_x * sum_x;
                // a=(nΣxy - ΣxΣy)/[nΣx2-(Σx)2]
                a = (dataCnt * sum_xy - sum_x * sum_y) / divisor;

                // b=(Σx2Σy - ΣxyΣx)/[nΣx2-(Σx)2]
                b = (sum_x2 * sum_y - sum_xy * sum_x) / divisor;
                parameter[0] = a;
                parameter[1] = b;
                return parameter;

            }
        }
        #endregion

        #region SLOPE
        /// <summary>
        /// SLOPE
        /// </summary>
        /// <param name="x">xs</param>
        /// <param name="y">ys</param>
        /// <returns>返回线性拟合a</returns>
        public double SLOPE(double[] y,double[] x )
        {
            int ii = 0;
            double sum_x = 0;
            double sum_y = 0;
            double sum_xy = 0;
            double sum_x2 = 0;
            double a = 0;
            double b = 0;
            double[] parameter = new double[2];

            int dataCnt = Math.Min(x.Length, y.Length) ;

            if (dataCnt == 1)
            {
                a = 0;
                b = y[0];
                parameter[0] = a;
                parameter[1] = b;
                return parameter[0];
            }
            else
            {

                for (ii = 0; ii <= dataCnt - 1; ii++)
                {
                    //X和
                    sum_x += x[ii];
                    //Y和
                    sum_y += y[ii];
                    //X*Y和
                    sum_xy += x[ii] * y[ii];
                    //X2和
                    sum_x2 += x[ii] * x[ii];
                }

                //nΣx2-(Σx)2
                double divisor = dataCnt * sum_x2 - sum_x * sum_x;
                // a=(nΣxy - ΣxΣy)/[nΣx2-(Σx)2]
                a = (dataCnt * sum_xy - sum_x * sum_y) / divisor;

                // b=(Σx2Σy - ΣxyΣx)/[nΣx2-(Σx)2]
                b = (sum_x2 * sum_y - sum_xy * sum_x) / divisor;
                parameter[0] = a;
                parameter[1] = b;
                return parameter[0];

            }
        }
        #endregion

        #region INTERCEPT
        /// <summary>
        /// INTERCEPT
        /// </summary>
        /// <param name="x">xs</param>
        /// <param name="y">ys</param>
        /// <returns>返回线性拟合b</returns>
        public double INTERCEPT(double[] y,double[] x )
        {
            int ii = 0;
            double sum_x = 0;
            double sum_y = 0;
            double sum_xy = 0;
            double sum_x2 = 0;
            double a = 0;
            double b = 0;
            double[] parameter = new double[2];

            int dataCnt = Math.Min(x.Length, y.Length);

            if (dataCnt == 1)
            {
                a = 0;
                b = y[0];
                parameter[0] = a;
                parameter[1] = b;
                return parameter[1];
            }
            else
            {

                for (ii = 0; ii <= dataCnt - 1; ii++)
                {
                    //X和
                    sum_x += x[ii];
                    //Y和
                    sum_y += y[ii];
                    //X*Y和
                    sum_xy += x[ii] * y[ii];
                    //X2和
                    sum_x2 += x[ii] * x[ii];
                }

                //nΣx2-(Σx)2
                double divisor = dataCnt * sum_x2 - sum_x * sum_x;
                // a=(nΣxy - ΣxΣy)/[nΣx2-(Σx)2]
                a = (dataCnt * sum_xy - sum_x * sum_y) / divisor;

                // b=(Σx2Σy - ΣxyΣx)/[nΣx2-(Σx)2]
                b = (sum_x2 * sum_y - sum_xy * sum_x) / divisor;
                parameter[0] = a;
                parameter[1] = b;
                return parameter[1];

            }
        }
        #endregion

        #region MEDIAN
        /// <summary>
        /// MEDIAN
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public double MEDIAN(double[] arr_original)
        {
            double[] arr = new double[arr_original.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr_original[i];
            }
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = 0; j < arr.Length - 1 - i; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            double a = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = a;
                        }
                    }
                }
            int arrlength = arr.Length;
            if (arrlength % 2 == 0)
            {
                return (arr[arrlength / 2 - 1] + arr[arrlength / 2]) / 2;
            }
            return arr[(arrlength - 1) / 2];

        }
        #endregion

        #region AVERAGE
        /// <summary>
        /// AVERAGE
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public double AVERAGE(double[] arr)
        {
            double sum = 0.0;
            for(int i=0;i<arr.Length;i++)
            {
                sum=sum+arr[i];
            }
            double average = sum / arr.Length;
            return average;
        }
        #endregion

        #region NORMSDIST
        double Normal(double z)
        {
            const double PI = 3.1415926; 
            double temp;
            temp =Math.Exp((-1) * z * z / 2) /Math.Sqrt(2 * PI);
            return temp;
        }
          /***************************************************************/  
        /* 返回标准正态分布的累积函数，该分布的平均值为 0，标准偏差为 1。                           */  
        /***************************************************************/
        public double NORMSDIST(double z)  
        {  
            // this guards against overflow  
            if(z > 6) return 1;  
            if(z < -6) return 0;   
      
                const double gamma =  0.231641900,  
                a1  =  0.319381530,  
                a2  = -0.356563782,  
                a3  =  1.781477973,  
                a4  = -1.821255978,  
                a5  =  1.330274429;   
      
            double k = 1.0 / (1 + Math.Abs(z) * gamma);  
            double n = k * (a1 + k * (a2 + k * (a3 + k * (a4 + k * a5))));  
            n = 1 - Normal(z) * n;  
            if(z < 0)  
                return 1.0 - n;   
      
            return n;  
        }   
 
        #endregion



    }
}
