using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mandatory1.ViewModels
{
    public class CipherModel
    {
        [Required]
        [Display(Name = "Text to use cipher on")]
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
            string processedString = "";
            switch (cipher)
            {
                case "shift":
                    int shift = (int.Parse(secret)+ char.MaxValue)% char.MaxValue;
                    if (type == "dec")
                    {
                       shift = decimal.ToInt32(decimal.Negate(shift));
                    }                   

                    for (int i = 0; i < input.Length; i++)
                    {
                        processedString += (char)((input[i] + shift) % char.MaxValue);
                    }

                    break;
                case "vigenere":
                    int index = 0;
                    foreach(char currInput in input)
                    {
                        int secretAtIndex = secret[index];
                        if (type == "dec") { secretAtIndex = decimal.ToInt32(decimal.Negate(secretAtIndex)); }
                        processedString += (char)((currInput + secretAtIndex) % char.MaxValue);
                        index = (index < secret.Length - 1) ? index = index + 1 : index = 0;
                    }
                    break;
                case "gcd":
                    int r = -1;
                    int a = int.Parse(input);
                    int b = int.Parse(secret);
                    while (b > 0)
                    {
                        r =  a%b;
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
