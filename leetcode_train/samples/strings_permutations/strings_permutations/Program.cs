/*
 * Created by SharpDevelop.
 * User: epiro
 * Date: 20.04.2021
 * Time: 16:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace strings_permutations
{
	class Program
	{
		static void printArr(string[] a, int n)
	    {
	        for (int i = 0; i < n; i++)
	            Console.Write(a[i] + ",");
	        Console.WriteLine();
	    }
		
		static void heapPermutation(string[] a, int size, int n)
	    {
	        // if size becomes 1 then prints the obtained
	        // permutation
	        if (size == 1)
	            printArr(a, n);
	 
	        for (int i = 0; i < size; i++) {
	            heapPermutation(a, size - 1, n);
	 
	            // if size is odd, swap 0th i.e (first) and
	            // (size-1)th i.e (last) element
	            if (size % 2 == 1) {
	                string temp = a[0];
	                a[0] = a[size - 1];
	                a[size - 1] = temp;
	            }
	 
	            // If size is even, swap ith and
	            // (size-1)th i.e (last) element
	            else {
	                string temp = a[i];
	                a[i] = a[size - 1];
	                a[size - 1] = temp;
	            }
	        }
	    }
		
		public static void Main(string[] args)
		{
			var array = new string [] { "pdf", "doc", "docx", "word", "excel", "xlsx", "powerpoint", "pptx", "tex", "html", "jpg", "png", "tiff", "ppt", "bmp", "cgm", "csv", "xml", "xps", "epub", "latex", "mhtml", "mht", "svg", "emf", "txt", "pdfa1a", "pdfa1b", "pdfa2a", "pdfa3a", "ps", "eps", "pcl", "md", "srt", "zip", "all", "7z", "tar", "gz", "bz2", "rar", "rtf", "xls", "image", "gif" };
			
			heapPermutation(array, array.Length, array.Length);
				
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}