using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mandatory1.ViewModels
{
    public class CipherModel
    {
        private static string originalCh = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz~@`!#$%^&*+=-[]\\\';,/{}|\":.<>?() 0123456789"; // For reference only
        private static string feed = "%xEml;4ePJTcItg}XV\"h>3\\psHy'/bY1[{ f=N@~G6q50*C7z:(O|QkMnFZBoLjD]&d?RA,)S+8iKa^u29<#w$rW.v`U-!";
        private static List<char> feedList = new List<char>(feed.ToCharArray());
        [Required]
        [Display(Name = "Text to use cipher on")]
        [RegularExpression("^[a-zA-Z0-9?><;:,(){}\\[\\]\\-_+=!~ .`@?#/$%\\^&*|'\\\\]*$", ErrorMessage = "Some of the characters you have entered are not allowed!")]
        public string input { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string secret { get; set; }

        [Required]
        public string type { get; set; }
        public string Output { get { return output; } }
        private string output;
        public void setOutput(string output)
        {
            this.output = output;
        }

        public void process(string cipher)
        {
            List<char> inputList = new List<char>(input.ToCharArray());
            string processedString = "";
            switch (cipher)
            {
                case "shift":
                    int shift = int.Parse(secret);
                    if (type == "dec")
                    {
                        shift = shift * -1;
                    }
                    

                    for (int i = 0; i < inputList.Count; i++)
                    {
                        processedString += feedList[System.Math.Abs(feedList.IndexOf(inputList[i]) + shift) % feed.Length];
                    }
                    
                    break;
                case "vigenere":
                    List<char[]> alphabetsList = new List<char[]>(secret.Length);
                    //Create alphabets array to use 
                    for(int i = 0; i < secret.Length; i++)
                    {
                        alphabetsList.Add(new char[feedList.Count]);
                        int alpha_index = feedList.IndexOf(secret[i]);
                        for(int j = 0; j < feedList.Count; j++)
                        {
                            alphabetsList[i][(j+alpha_index)%feedList.Count] = feedList[j];
                        }
                    }
                   // process
                    int index = 0;
                    for(int i = 0; i < inputList.Count; i++)
                    {
                        if (type == "enc") {
                           processedString += alphabetsList[index % alphabetsList.Count][feedList.IndexOf(inputList[i])];
                        } else
                        {
                            processedString += feedList[(new String(alphabetsList[index % alphabetsList.Count])).IndexOf(inputList[i])];
                        }
                        index++;
                    }
                    break;
                case "gcd":
                    int r = -1;
                    int a = int.Parse(input);
                    int b = int.Parse(secret);
                    while (b > 0)
                    {
                        r =  a%b; //this means (modulo) in both c# and javascript.
                        a = b;
                        b = r;
                    }

                    processedString = a.ToString();
                    break;
                default:
                    processedString = "Incorrect cipher name!";
                    break;
            }
            setOutput(processedString);

        }

        
    }

 
}
